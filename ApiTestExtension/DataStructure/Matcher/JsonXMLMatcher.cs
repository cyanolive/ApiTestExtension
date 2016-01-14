using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTestExtension.DataStructure.Matcher
{
    public class JsonXMLMatcher
    {
        public enum MatchResult
        {
            DEFAULT = -1,
            MATCH_PARTLY,
            MATCH,
            LIST_OR_DICT_NULL,
            NOT_MATCH
        }

        public Dictionary<String, JsonXMLItemMatcher> jsonItemMatchStatus =
            new Dictionary<string, JsonXMLItemMatcher>();

        public HashSet<String> xmlEntryNotFound = new HashSet<string>();

        public HashSet<String> jsonEntryNotFound = new HashSet<string>();

        public MatchResult matchResult = MatchResult.DEFAULT;

        public String strResult;

        public override string ToString()
        {
            return strResult;
        }

        public String matchResultToString()
        {
            switch (matchResult)
            {
                case MatchResult.LIST_OR_DICT_NULL:
                    return "LIST_OR_DICT_NULL";
                case MatchResult.MATCH_PARTLY:
                    return "MATCH_PARTLY";
                case MatchResult.NOT_MATCH:
                    return "NOT_MATCH";
                default:
                    return "TYPE_ERROR";
            }
        }
    }
}
