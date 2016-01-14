using ApiTestExtension.DataStructure.Matcher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTestExtension.DataStructure
{
    public class XMLResponseItem
    {
        public ResponseItemType Type;
        public String ItemName;
        public String ItemRemark;
        public bool IsEntryList;
        public JsonXMLItemMatcher.ItemMatchResult matchResult = JsonXMLItemMatcher.ItemMatchResult.DEFAULT;
        public Dictionary<String, XMLResponseItem> SubItems = new Dictionary<String, XMLResponseItem>();
    }

    public enum ResponseItemType
    {
        INT,
        LIST,
        STRING,
        DICT
    }
}
