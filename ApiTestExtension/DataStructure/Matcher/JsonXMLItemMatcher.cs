using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTestExtension.DataStructure.Matcher
{
    public class JsonXMLItemMatcher
    {
        public enum ItemMatchResult
        {
            DEFAULT = -1,
            LIST_NULL,
            DICT_NULL,
            LIST_OR_DICT_PARTLY_MATCHED,
            NULL_MATCHED,
            INT_MATCHED,
            STRING_MATCHED,
            LIST_ENTRY_MATCHED,
            LIST_STRING_MATCHED,
            DICT_MATCHED,
            TYPE_NOT_MATCH = 100
        }

        public String strResult = "";
        public ItemMatchResult itemMatchResult = ItemMatchResult.TYPE_NOT_MATCH;

        public override string ToString()
        {
            return strResult;
        }
    }
}
