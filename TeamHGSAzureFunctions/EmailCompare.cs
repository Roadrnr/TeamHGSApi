using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace TeamHGSAzureFunctions
{
    public static class EmailCompare
    {
        [FunctionName("Compare")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            // parse query parameter
            var email1 = req.GetQueryNameValuePairs()
                .FirstOrDefault(q => string.Compare(q.Key, "email1", StringComparison.OrdinalIgnoreCase) == 0)
                .Value;

            var email2 = req.GetQueryNameValuePairs()
                .FirstOrDefault(q => string.Compare(q.Key, "email2", StringComparison.OrdinalIgnoreCase) == 0)
                .Value;

            if (email1 == null)
            {
                // Get request body
                dynamic data = await req.Content.ReadAsAsync<object>();
                email1 = data?.email1;
                email2 = data?.email2;
            }

            var returnObj = new ReturnObject();

            if (string.IsNullOrWhiteSpace(email2)) return req.CreateResponse(HttpStatusCode.OK, returnObj);

            var comparison = string.Equals(email1, email2, StringComparison.OrdinalIgnoreCase);
            returnObj.Result = comparison;
            if (comparison)
            {
                returnObj.ResultStatus = 1;
                returnObj.ResultValue = "Match";
            }
            else
            {
                returnObj.ResultStatus = 2;
                returnObj.ResultValue = "No Match";
            }

            return email1 == null
                ? req.CreateResponse(HttpStatusCode.BadRequest, "Please pass 2 emails, named email1 and email2, on the query string or in the request body")
                : req.CreateResponse(HttpStatusCode.OK, returnObj);
        }
    }
}
