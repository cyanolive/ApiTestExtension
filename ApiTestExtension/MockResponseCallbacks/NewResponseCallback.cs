using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTestExtension.MockResponseCallbacks
{
    class NewResponseCallback : IMockResponseCallback
    {
        String destResponseBody;

        public NewResponseCallback(String destResponseBody)
        {
            this.destResponseBody = destResponseBody;
        }

        public string analyzeResponse(string orgResponseBody)
        {
            return destResponseBody;
        }
    }
}
