using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ApiTestExtension.DataStructure.XMLAnalyzer
{
    public class XMLApiItem
    {
        public String Name;
        public String Apiurl;
        public String Function;
        public String Scene;
        public String MenuFolder;
        public String MenuText;
        public String Product;
        public XMLApiRequest Request = new XMLApiRequest();
        public XMLApiResponse Response = new XMLApiResponse();      
    }
}
