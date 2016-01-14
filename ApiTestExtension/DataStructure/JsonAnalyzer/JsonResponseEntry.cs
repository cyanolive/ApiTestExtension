using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiTestExtension.DataStructure;

namespace ApiTestExtension.DataStructure.JsonAnalyzer
{
    public class JsonResponseEntry
    {
        public enum ResponseEntryType
        {
            LIST_ENTRY,
            LIST_STRING,
            LIST_NULL,
            DICT_NULL,
            DICT,
            STRING,
            INT,
            NULL
        }

        public String key;
        public ResponseEntryType type;
        public List<Dictionary<String, JsonResponseEntry>> listEntry = new List<Dictionary<String, JsonResponseEntry>>();
        public List<String> listString = new List<string>();
        public Dictionary<String, JsonResponseEntry> subEntry = new Dictionary<string, JsonResponseEntry>();
        public String stringValue;
        public long intValue;
    }
}
