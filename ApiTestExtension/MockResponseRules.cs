using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTestExtension
{
    class MockResponseRules
    {
        String ruleName;
        String apiPattern;
        OpeartionType operationType;
        APIPatternType patternType;
        ILogger logger;
        IMockResponseCallback responseCallback;

        public String RuleName
        {
            get { return ruleName; }
        }

        public String ApiPattern
        {
            get { return apiPattern; }
        }

        public MockResponseRules(String ruleName, String apiPattern, OpeartionType operationType,
            APIPatternType patternType, ILogger logger, IMockResponseCallback responseCallback)
        {
            this.ruleName = ruleName;
            this.apiPattern = apiPattern;
            this.operationType = operationType;
            this.apiPattern = apiPattern;
            this.patternType = patternType;
            this.logger = logger;
            this.responseCallback = responseCallback;
        }

        public MockResponseRules(String ruleName, OpeartionType operationType, ILogger logger)
        {
            this.ruleName = ruleName;
            this.operationType = operationType;
            this.logger = logger;
        }

        public enum OpeartionType
        {
            NEW_RESPONSE = 0,
            REPLACE_RESPONSE,
            REMOVE = 100
        };

        public enum APIPatternType
        {
            NORMAL = 0,
            REGULAR
        };

        public String MockedResponse(String orgResponse)
        {
            if (responseCallback != null)
            {
                return responseCallback.analyzeResponse(orgResponse);
            }
            else
            {
                logger.Log("Invalid operation type, use original ResponseBody.");
                return orgResponse;
            }
        }
    }
}
