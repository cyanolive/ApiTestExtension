using ApiTestExtension.DataStructure.Matcher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTestExtension.DataStructure.XMLAnalyzer
{
    public class XMLApiResponse
    {
        public ResponseType Type;
        public JsonXMLMatcher.MatchResult matchResult = JsonXMLMatcher.MatchResult.DEFAULT;
        public Dictionary<String, XMLResponseItem> Items = new Dictionary<String, XMLResponseItem>();
    }

    public enum ResponseType
    {
        JSON,
        RAW,
        JSON_LIST
    }
}
