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
        public static XMLApiItem analyzeXML(FileInfo fi)
        {
            XMLApiItem apiItem = new XMLApiItem();
            XmlDocument xmldoc = new XmlDocument();

            xmldoc.Load(fi.FullName);
            //获取product属性
            XmlNode root = xmldoc.SelectSingleNode("root");
            apiItem.Product = root.Attributes["product"].Value;

            //解析API参数
            apiItem.Name = xmldoc.SelectSingleNode("root/api/name").InnerText;
            apiItem.Apiurl = xmldoc.SelectSingleNode("root/api/apiulr").InnerText;
            apiItem.Function = xmldoc.SelectSingleNode("root/api/function").InnerText;
            if (xmldoc.SelectSingleNode("root/api/scene") != null)
            {
                apiItem.Scene = xmldoc.SelectSingleNode("root/api/scene").InnerText;
            }
            apiItem.MenuFolder = xmldoc.SelectSingleNode("root/api/menuFolder").InnerText;
            apiItem.MenuText = xmldoc.SelectSingleNode("root/api/menuText").InnerText;

            //解析Request
            XmlNode xnRequestNode = root.SelectSingleNode("api/request");
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
            XmlNode xnResponseNode = root.SelectSingleNode("api/response");
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
            return apiItem;
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
