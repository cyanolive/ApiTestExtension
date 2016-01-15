using ApiTestExtension.DataStructure;
using ApiTestExtension.DataStructure.JsonAnalyzer;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using ApiTestExtension.DataStructure.Matcher;
using System.Text;
using ApiTestExtension.DataStructure.XMLAnalyzer;

namespace ApiTestExtension.Utils
{
    public class JsonUtil
    {
        public static JsonXMLMatcher matchJsonWithXML(Dictionary<String, JsonResponseEntry> jsonResponseEntry,
            Dictionary<String, XMLResponseItem> xmlResponseItems, bool isRootList)
        {
            JsonXMLMatcher matcher = new JsonXMLMatcher();

            Dictionary<String, XMLResponseItem> xmlResponseItemsCopy = new Dictionary<String, XMLResponseItem>(xmlResponseItems);

            //如果是List节点需要遍历每一个List内容来判断XML匹配
            if (jsonResponseEntry.Count == 1 && jsonResponseEntry.ContainsKey("") && jsonResponseEntry[""].type == JsonResponseEntry.ResponseEntryType.LIST_ENTRY)
            {
                if (isRootList)
                {
                    matcher = matchJsonWithXML(jsonResponseEntry[""].subEntry, xmlResponseItems, false);
                }
                else
                {
                    matcher.matchResult = JsonXMLMatcher.MatchResult.NOT_MATCH;
                    matcher.strResult = "Json type is List but do not match with the XML";
                }
            }
            else
            {
                //遍历每一个json中的数据格式，和XML对比，找到差异和是否有json中多余的部分，
                //匹配成功则在XML对象中移除相关Key，剩余的便是XML有但是json没有的部分了
                foreach (String key in jsonResponseEntry.Keys)
                {
                    if (xmlResponseItemsCopy.ContainsKey(key))
                    {
                        JsonXMLItemMatcher result = matchJsonEntryWithXMLItem(jsonResponseEntry[key], xmlResponseItems[key]);
                        matcher.jsonItemMatchStatus.Add(key, result);
                    }
                    else
                    {
                        matcher.jsonEntryNotFound.Add(key);
                    }
                    xmlResponseItemsCopy.Remove(key);
                }

                foreach (String key in xmlResponseItemsCopy.Keys)
                {
                    matcher.xmlEntryNotFound.Add(key);
                }

                //处理当前Matcher的匹配结果
                int jsonEntryNotFoundCount = matcher.jsonEntryNotFound.Count;
                int xmlEntryNotFound = matcher.xmlEntryNotFound.Count;
                //json有没有被覆盖的数据（通常有问题，需要更新XML）
                if (jsonEntryNotFoundCount > 0)
                {
                    matcher.matchResult = JsonXMLMatcher.MatchResult.NOT_MATCH;
                    matcher.strResult += "XML has items missing:";
                    foreach (String key in matcher.jsonEntryNotFound)
                    {
                        matcher.strResult += key + ",";
                    }
                    matcher.strResult += "\n";
                }
                //XML有没有被覆盖到的数据（常见的，定义的规则中是有字段不是必须返回的）
                else if (xmlEntryNotFound > 0)
                {
                    matcher.matchResult = JsonXMLMatcher.MatchResult.MATCH_PARTLY;
                    matcher.strResult += "Json has items missing:";
                    foreach (String key in matcher.xmlEntryNotFound)
                    {
                        matcher.strResult += key + ",";
                    }
                    matcher.strResult += "\n";
                }
                //针对每个匹配的item再做下对比
                foreach (String jsonItemKey in matcher.jsonItemMatchStatus.Keys)
                {
                    JsonXMLItemMatcher result = matcher.jsonItemMatchStatus[jsonItemKey];
                    switch (result.itemMatchResult)
                    {
                        case JsonXMLItemMatcher.ItemMatchResult.STRING_MATCHED:
                        case JsonXMLItemMatcher.ItemMatchResult.LIST_ENTRY_MATCHED:
                        case JsonXMLItemMatcher.ItemMatchResult.DICT_MATCHED:
                        case JsonXMLItemMatcher.ItemMatchResult.INT_MATCHED:
                        case JsonXMLItemMatcher.ItemMatchResult.NULL_MATCHED:
                            if (matcher.matchResult == JsonXMLMatcher.MatchResult.DEFAULT)
                            {
                                matcher.matchResult = JsonXMLMatcher.MatchResult.MATCH;
                            }
                            break;
                        case JsonXMLItemMatcher.ItemMatchResult.DICT_NULL:
                            if (matcher.matchResult <= JsonXMLMatcher.MatchResult.MATCH)
                            {
                                matcher.matchResult = JsonXMLMatcher.MatchResult.LIST_OR_DICT_NULL;
                            }
                            break;
                        case JsonXMLItemMatcher.ItemMatchResult.LIST_NULL:
                            if (matcher.matchResult <= JsonXMLMatcher.MatchResult.MATCH)
                            {
                                matcher.matchResult = JsonXMLMatcher.MatchResult.LIST_OR_DICT_NULL;
                            }
                            break;
                        case JsonXMLItemMatcher.ItemMatchResult.TYPE_NOT_MATCH:
                            matcher.matchResult = JsonXMLMatcher.MatchResult.NOT_MATCH;
                            break;
                        case JsonXMLItemMatcher.ItemMatchResult.LIST_OR_DICT_PARTLY_MATCHED:
                            matcher.matchResult = JsonXMLMatcher.MatchResult.MATCH_PARTLY;
                            break;
                        default:
                            break;
                    }
                    matcher.strResult += result.ToString();
                }
                xmlResponseItemsCopy = null;
            }

            return matcher;
        }

        static String XMLResponseItemTypeToString(ResponseItemType type)
        {
            switch (type)
            {
                case ResponseItemType.DICT:
                    return "DICT";
                case ResponseItemType.INT:
                    return "INT";
                case ResponseItemType.LIST:
                    return "LIST";
                case ResponseItemType.STRING:
                    return "STRING";
                default:
                    return "UNKNOWN";
            }
        }

        static JsonXMLItemMatcher matchJsonEntryWithXMLItem(JsonResponseEntry jsonEntry, XMLResponseItem xmlItem)
        {
            String itemKey = xmlItem.ItemName;
            JsonXMLItemMatcher itemMatcher = new JsonXMLItemMatcher();
            switch (jsonEntry.type)
            {
                case JsonResponseEntry.ResponseEntryType.DICT:
                    if (xmlItem.Type == ResponseItemType.DICT)
                    {
                        JsonXMLMatcher matcher = matchJsonWithXML(jsonEntry.subEntry, xmlItem.SubItems, false);
                        switch (matcher.matchResult)
                        {
                            case JsonXMLMatcher.MatchResult.LIST_OR_DICT_NULL:
                                itemMatcher.itemMatchResult = JsonXMLItemMatcher.ItemMatchResult.DICT_NULL;
                                itemMatcher.strResult = itemKey + "->dict null\n    " + matcher.ToString().Replace("\n", "\n    ");
                                break;
                            case JsonXMLMatcher.MatchResult.MATCH:
                                itemMatcher.itemMatchResult = JsonXMLItemMatcher.ItemMatchResult.DICT_MATCHED;
                                break;
                            case JsonXMLMatcher.MatchResult.MATCH_PARTLY:
                                itemMatcher.itemMatchResult = JsonXMLItemMatcher.ItemMatchResult.LIST_OR_DICT_PARTLY_MATCHED;
                                itemMatcher.strResult = itemKey + "-> dict partly match\n    " + matcher.ToString().Replace("\n", "\n    ");
                                break;
                            case JsonXMLMatcher.MatchResult.NOT_MATCH:
                                itemMatcher.strResult = itemKey + "-> Not match\n    " + matcher.ToString().Replace("\n", "\n    ");
                                itemMatcher.itemMatchResult = JsonXMLItemMatcher.ItemMatchResult.TYPE_NOT_MATCH;
                                break;
                        }
                    }
                    else
                    {
                        itemMatcher.strResult = itemKey + "-> Type not match in xml is "
                            + XMLResponseItemTypeToString(xmlItem.Type)
                            + " but in json is DICT\n";
                        itemMatcher.itemMatchResult = JsonXMLItemMatcher.ItemMatchResult.TYPE_NOT_MATCH;
                    }
                    break;
                case JsonResponseEntry.ResponseEntryType.DICT_NULL:
                    if (xmlItem.Type == ResponseItemType.DICT)
                    {
                        itemMatcher.itemMatchResult = JsonXMLItemMatcher.ItemMatchResult.DICT_NULL;
                        itemMatcher.strResult = itemKey + "-> Dict null\n";
                    }
                    else
                    {
                        itemMatcher.strResult = itemKey + "-> Type not match in xml is"
                            + XMLResponseItemTypeToString(xmlItem.Type)
                            + "but in json is DICT_NULL\n";
                        itemMatcher.itemMatchResult = JsonXMLItemMatcher.ItemMatchResult.TYPE_NOT_MATCH;
                    }
                    break;
                case JsonResponseEntry.ResponseEntryType.LIST_ENTRY:
                    if (xmlItem.Type == ResponseItemType.LIST)
                    {
                        JsonXMLMatcher matcher = matchJsonWithXML(jsonEntry.listEntry[0], xmlItem.SubItems, false);
                        switch (matcher.matchResult)
                        {
                            case JsonXMLMatcher.MatchResult.LIST_OR_DICT_NULL:
                                itemMatcher.itemMatchResult = JsonXMLItemMatcher.ItemMatchResult.DICT_NULL;
                                itemMatcher.strResult = itemKey + "->list null\n" + matcher.ToString().Replace("\n", "\n    ");
                                break;
                            case JsonXMLMatcher.MatchResult.MATCH:
                                itemMatcher.itemMatchResult = JsonXMLItemMatcher.ItemMatchResult.DICT_MATCHED;
                                break;
                            case JsonXMLMatcher.MatchResult.MATCH_PARTLY:
                                itemMatcher.itemMatchResult = JsonXMLItemMatcher.ItemMatchResult.LIST_OR_DICT_PARTLY_MATCHED;
                                itemMatcher.strResult = itemKey + "-> List partly match\n    " + matcher.ToString().Replace("\n", "\n    ");
                                break;
                            case JsonXMLMatcher.MatchResult.NOT_MATCH:
                                itemMatcher.strResult = itemKey + "-> Not match\n    " + matcher.ToString().Replace("\n", "\n    ");
                                itemMatcher.itemMatchResult = JsonXMLItemMatcher.ItemMatchResult.TYPE_NOT_MATCH;
                                break;
                        }
                    }
                    else
                    {
                        itemMatcher.strResult = itemKey + "-> Type not match in xml is "
                            + XMLResponseItemTypeToString(xmlItem.Type)
                            + " but in json is LIST_ENTRY\n";
                        itemMatcher.itemMatchResult = JsonXMLItemMatcher.ItemMatchResult.TYPE_NOT_MATCH;
                    }
                    break;
                case JsonResponseEntry.ResponseEntryType.LIST_STRING:
                    if (xmlItem.Type == ResponseItemType.LIST)
                    {
                        itemMatcher.itemMatchResult = JsonXMLItemMatcher.ItemMatchResult.LIST_STRING_MATCHED;
                    }
                    else
                    {
                        itemMatcher.strResult = itemKey + "-> Type not match in xml is "
                            + XMLResponseItemTypeToString(xmlItem.Type)
                            + " but in json is LIST_STRING\n";
                        itemMatcher.itemMatchResult = JsonXMLItemMatcher.ItemMatchResult.TYPE_NOT_MATCH;
                    }
                    break;
                case JsonResponseEntry.ResponseEntryType.LIST_NULL:
                    if (xmlItem.Type == ResponseItemType.LIST)
                    {
                        itemMatcher.itemMatchResult = JsonXMLItemMatcher.ItemMatchResult.LIST_NULL;
                        itemMatcher.strResult = itemKey + "-> List null\n";
                    }
                    else
                    {
                        itemMatcher.strResult = itemKey + "-> Type not match in xml is "
                            + XMLResponseItemTypeToString(xmlItem.Type)
                            + " but in json is LIST_NULL\n";
                        itemMatcher.itemMatchResult = JsonXMLItemMatcher.ItemMatchResult.TYPE_NOT_MATCH;
                    }
                    break;
                case JsonResponseEntry.ResponseEntryType.STRING:
                    if (xmlItem.Type == ResponseItemType.STRING)
                    {
                        itemMatcher.itemMatchResult = JsonXMLItemMatcher.ItemMatchResult.STRING_MATCHED;
                    }
                    else
                    {
                        itemMatcher.strResult = itemKey + "-> Type not match in xml is "
                            + XMLResponseItemTypeToString(xmlItem.Type)
                            + " but in json is STRING\n";
                        itemMatcher.itemMatchResult = JsonXMLItemMatcher.ItemMatchResult.TYPE_NOT_MATCH;
                    }
                    break;
                case JsonResponseEntry.ResponseEntryType.INT:
                    if (xmlItem.Type == ResponseItemType.INT)
                    {
                        itemMatcher.itemMatchResult = JsonXMLItemMatcher.ItemMatchResult.INT_MATCHED;
                    }
                    else
                    {
                        itemMatcher.strResult = itemKey + "-> Type not match in xml is "
                            + XMLResponseItemTypeToString(xmlItem.Type)
                            + " but in json is INT\n";
                        itemMatcher.itemMatchResult = JsonXMLItemMatcher.ItemMatchResult.TYPE_NOT_MATCH;
                    }
                    break;
                case JsonResponseEntry.ResponseEntryType.NULL:
                    if (xmlItem.Type == ResponseItemType.INT || xmlItem.Type == ResponseItemType.STRING)
                    {
                        itemMatcher.itemMatchResult = JsonXMLItemMatcher.ItemMatchResult.NULL_MATCHED;
                    }
                    else
                    {
                        itemMatcher.strResult = itemKey + "-> Type not match in xml is "
                            + XMLResponseItemTypeToString(xmlItem.Type)
                            + " but in json is NULL\n";
                        itemMatcher.itemMatchResult = JsonXMLItemMatcher.ItemMatchResult.TYPE_NOT_MATCH;
                    }
                    break;
                default:
                    break;
            }

            if (itemMatcher.itemMatchResult > xmlItem.matchResult)
            {
                xmlItem.matchResult = itemMatcher.itemMatchResult;
            }
            return itemMatcher;
        }

        public static Dictionary<String, JsonResponseEntry> analyzeResponseEntry(JToken jToken)
        {
            Dictionary<String, JsonResponseEntry> responseEntry = new Dictionary<string, JsonResponseEntry>();

            if (jToken is JArray)
            {
                //约定key为""且dict仅有1项表示被解析的JToken是一个Array，暂时仅支持ENTRY_LIST的根
                String key = "";
                JsonResponseEntry entry = new JsonResponseEntry();
                JArray ja = jToken as JArray;
                if (ja.Count != 0)
                {
                    if (ja[0] is JObject)
                    {
                        entry.type = JsonResponseEntry.ResponseEntryType.LIST_ENTRY;
                        List<Dictionary<String, JsonResponseEntry>> list = new List<Dictionary<string, JsonResponseEntry>>();
                        for (int i = 0; i < ja.Count; i++)
                        {
                            JObject jo = (JObject)ja[i];
                            list.Add(analyzeResponseEntry(jo));
                        }
                        entry.listEntry = list;
                        responseEntry.Add(key, entry);
                    }
                }
            }
            else if (jToken is JObject)
            {
                foreach (JProperty jpItem in ((JObject)jToken).Children())
                {
                    String key = jpItem.Name;
                    JToken jt = jpItem.Value;
                    String value = jpItem.Value.ToString();
                    JsonResponseEntry entry = new JsonResponseEntry();
                    entry.key = key;

                    //null类型
                    if (jpItem.Value is JValue && ((JValue)(jpItem.Value)).Value == null)
                    {
                        entry.type = JsonResponseEntry.ResponseEntryType.NULL;
                    }
                    //dict类型,内容为空
                    else if (value == "{}")
                    {
                        entry.type = ApiTestExtension.DataStructure.JsonAnalyzer.JsonResponseEntry.ResponseEntryType.DICT_NULL;
                    }
                    //value为String空
                    else if (value == "")
                    {
                        entry.type = JsonResponseEntry.ResponseEntryType.STRING;
                        entry.stringValue = value;
                    }
                    //dict类型
                    else if (jpItem.Value is JObject)
                    {
                        entry.type = JsonResponseEntry.ResponseEntryType.DICT;
                        Dictionary<String, JsonResponseEntry> subEntry = new Dictionary<string, JsonResponseEntry>();
                        entry.subEntry = analyzeResponseEntry(JObject.Parse(value));
                    }
                    //list类型
                    else if (jpItem.Value is JArray)
                    {
                        JArray ja = JArray.Parse(value);
                        if (ja.Count == 0)
                        {
                            entry.type = JsonResponseEntry.ResponseEntryType.LIST_NULL;
                        }
                        else
                        {
                            if (ja[0] is JObject)
                            {
                                entry.type = JsonResponseEntry.ResponseEntryType.LIST_ENTRY;
                                List<Dictionary<String, JsonResponseEntry>> list = new List<Dictionary<string, JsonResponseEntry>>();
                                for (int i = 0; i < ja.Count; i++)
                                {
                                    JObject jo = (JObject)ja[i];
                                    list.Add(analyzeResponseEntry(jo));
                                }
                                entry.listEntry = list;
                            }
                            else
                            {
                                entry.type = JsonResponseEntry.ResponseEntryType.LIST_STRING;
                                List<String> list = new List<string>();
                                for (int i = 0; i < ja.Count; i++)
                                {
                                    list.Add(ja[i].ToString());
                                }
                                entry.listString = list;
                            }
                        }
                    }
                    else
                    {
                        //Int类型
                        try
                        {
                            entry.type = JsonResponseEntry.ResponseEntryType.INT;
                            entry.intValue = long.Parse(value);
                        }
                        //String类型
                        catch
                        {
                            entry.type = JsonResponseEntry.ResponseEntryType.STRING;
                            entry.stringValue = value;
                        }
                    }
                    responseEntry.Add(key, entry);
                }
            }

            return responseEntry;
        }

        public static JObject assembleJson(Dictionary<String, JsonResponseEntry> responseEntries)
        {
            JObject returnObject = new JObject();
            foreach (String key in responseEntries.Keys)
            {
                returnObject.Add(jsonResponseEntryToJson(responseEntries[key]));
            }
            return returnObject;
        }

        static JProperty jsonResponseEntryToJson(JsonResponseEntry responseEntry)
        {
            JArray array = new JArray();
            switch (responseEntry.type)
            {
                case JsonResponseEntry.ResponseEntryType.DICT:
                    JObject jObject = new JObject();
                    return new JProperty(responseEntry.key, assembleJson(responseEntry.subEntry));
                case JsonResponseEntry.ResponseEntryType.DICT_NULL:
                    return new JProperty(responseEntry.key, new JObject());
                case JsonResponseEntry.ResponseEntryType.LIST_ENTRY:
                    foreach (Dictionary<String, JsonResponseEntry> subListEntries in responseEntry.listEntry)
                    {
                        array.Add(assembleJson(subListEntries));
                    }
                    return new JProperty(responseEntry.key, array);
                case JsonResponseEntry.ResponseEntryType.LIST_NULL:
                    return new JProperty(responseEntry.key, new JArray());
                case JsonResponseEntry.ResponseEntryType.LIST_STRING:
                    foreach (String str in responseEntry.listString)
                    {
                        array.Add(new JValue(StringToUnicode(str)));
                    }
                    return new JProperty(responseEntry.key, array);
                case JsonResponseEntry.ResponseEntryType.STRING:
                    return new JProperty(responseEntry.key, new JValue(StringToUnicode(responseEntry.stringValue)));
                case JsonResponseEntry.ResponseEntryType.INT:
                    return new JProperty(responseEntry.key, new JValue(responseEntry.intValue));
                case JsonResponseEntry.ResponseEntryType.NULL:
                    return new JProperty(responseEntry.key, new JValue("").Value = null);
                default:
                    return null;
            }
        }



        /// <summary>
        /// 字符串转为UniCode码字符串
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        static String StringToUnicode(String s)
        {
            char[] charbuffers = s.ToCharArray();
            byte[] buffer;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < charbuffers.Length; i++)
            {
                if (charbuffers[i] > 128)
                {
                    buffer = System.Text.Encoding.Unicode.GetBytes(charbuffers[i].ToString());
                    sb.Append(@"\" + String.Format("u{0:X2}{1:X2}", buffer[1], buffer[0]).ToLower());
                }
                else
                {
                    sb.Append(charbuffers[i].ToString());
                }
            }
            return sb.ToString();
        }
    }
}
