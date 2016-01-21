using ApiTestExtension.DataStructure;
using ApiTestExtension.DataStructure.JsonAnalyzer;
using ApiTestExtension.DataStructure.XMLAnalyzer;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ApiTestExtension.Utils
{
    public class XMLUtil
    {
        public static Dictionary<String, XMLApiItem> analyzeXML(FileInfo fi)
        {
            Dictionary<String, XMLApiItem> apiItems = new Dictionary<string, XMLApiItem>();
            XmlDocument xmldoc = new XmlDocument();

            xmldoc.Load(fi.FullName);
            XmlNode root = xmldoc.SelectSingleNode("root");

            XMLApiItem apiItem = new XMLApiItem();
            foreach (XmlNode apiNode in root.SelectNodes("api"))
            {
                //获取product属性                
                apiItem.Product = root.Attributes["product"].Value;
                //解析API参数
                apiItem.Name = apiNode.SelectSingleNode("name").InnerText;
                apiItem.Apiurl = apiNode.SelectSingleNode("apiulr").InnerText;
                apiItem.Function = apiNode.SelectSingleNode("function").InnerText;
                if (apiNode.SelectSingleNode("scene") != null)
                {
                    apiItem.Scene = apiNode.SelectSingleNode("scene").InnerText;
                }
                apiItem.MenuFolder = apiNode.SelectSingleNode("menuFolder").InnerText;
                apiItem.MenuText = apiNode.SelectSingleNode("menuText").InnerText;

                //解析Request
                XmlNode xnRequestNode = apiNode.SelectSingleNode("request");
                switch (xnRequestNode.Attributes["type"].Value)
                {
                    case "GET":
                        apiItem.Request.Type = RequestType.GET;
                        break;
                    case "POST":
                        apiItem.Request.Type = RequestType.POST;
                        break;
                    default:
                        break;
                }
                XmlNodeList xnlRequestParams = xnRequestNode.SelectNodes("param");
                foreach (XmlNode xnRequestParam in xnlRequestParams)
                {
                    XMLRequestParam requestParam = new XMLRequestParam();
                    switch (xnRequestParam.Attributes["type"].Value)
                    {
                        case "int":
                            requestParam.Type = RequestParamType.INT;
                            break;
                        case "string":
                            requestParam.Type = RequestParamType.STRING;
                            break;
                        default:
                            break;
                    }
                    requestParam.Compulsory = xnRequestParam.Attributes["compulsory"].Value == "true" ? true : false;
                    requestParam.ParaName = xnRequestParam.SelectSingleNode("paraname").InnerText;
                    requestParam.ParaInstruction = xnRequestParam.SelectSingleNode("paraInstruction").InnerText;
                    apiItem.Request.RequestParams.Add(requestParam);
                }

                //解析Response
                XmlNode xnResponseNode = apiNode.SelectSingleNode("response");
                switch (xnResponseNode.Attributes["type"].Value)
                {
                    case "json":
                        apiItem.Response.Type = ResponseType.JSON;
                        break;
                    case "json_list":
                        apiItem.Response.Type = ResponseType.JSON_LIST;
                        break;
                    case "raw":
                        apiItem.Response.Type = ResponseType.RAW;
                        break;
                    default:
                        break;
                }
                XmlNodeList xnlSubItems = xnResponseNode.SelectNodes("item");
                if (xnlSubItems.Count > 0)
                {
                    foreach (XmlNode xnSubItem in xnlSubItems)
                    {
                        XMLResponseItem responseItem = getResponseItem(xnSubItem);
                        apiItem.Response.Items.Add(responseItem.ItemName, responseItem);
                    }
                }

                apiItems.Add(apiItem.Apiurl, apiItem);
                apiItem = new XMLApiItem();
            }
            
            return apiItems;
        }

        static XMLResponseItem getResponseItem(XmlNode xnResponseItem)
        {
            XMLResponseItem responseItem = new XMLResponseItem();
            switch (xnResponseItem.Attributes["type"].Value)
            {
                case "int":
                    responseItem.Type = ResponseItemType.INT;
                    break;
                case "string":
                    responseItem.Type = ResponseItemType.STRING;
                    break;
                case "list":
                    responseItem.Type = ResponseItemType.LIST;
                    break;
                case "dict":
                    responseItem.Type = ResponseItemType.DICT;
                    break;
                default:
                    break;
            }
            responseItem.ItemName = xnResponseItem.SelectSingleNode("name").InnerText;
            responseItem.ItemRemark = xnResponseItem.SelectSingleNode("remark").InnerText;
            if (xnResponseItem.SelectSingleNode("list") == null)
            {
                responseItem.IsEntryList = false;
                XmlNodeList xnlSubItems = xnResponseItem.SelectNodes("item");
                if (xnlSubItems.Count > 0)
                {
                    foreach (XmlNode xnSubItem in xnlSubItems)
                    {
                        XMLResponseItem subResponseItem = getResponseItem(xnSubItem);
                        responseItem.SubItems.Add(subResponseItem.ItemName, subResponseItem);
                    }
                }
            }
            else
            {
                responseItem.IsEntryList = true;
                XmlNodeList xnlSubItems = xnResponseItem.SelectNodes("list/item");
                if (xnlSubItems.Count > 0)
                {
                    foreach (XmlNode xnSubItem in xnlSubItems)
                    {
                        XMLResponseItem subResponseItem = getResponseItem(xnSubItem);
                        responseItem.SubItems.Add(subResponseItem.ItemName, subResponseItem);
                    }
                }
            }
            return responseItem;
        }
    }
}
