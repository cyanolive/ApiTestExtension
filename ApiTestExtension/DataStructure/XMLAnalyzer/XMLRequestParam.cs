using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTestExtension.DataStructure.XMLAnalyzer
{
    public class XMLRequestParam
    {
        public RequestParamType Type;
        public bool Compulsory;
        public String ParaName;
        public String ParaInstruction;
    }

    public enum RequestParamType
    {
        INT,
        STRING
    }
}
