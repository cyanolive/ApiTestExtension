using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTestExtension.DataStructure.XMLAnalyzer
{
    public class XMLApiRequest
    {
        public RequestType Type;
        public HashSet<XMLRequestParam> RequestParams = new HashSet<XMLRequestParam>();
    }

    public enum RequestType
    {
        GET,
        POST
    }
}
