using System;
namespace ApiTestExtension
{
    interface IMockResponseCallback
    {
        string analyzeResponse(String orgResponseBody);
    }
}
