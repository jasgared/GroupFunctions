using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace GroupFunctions
{
    public static class JustPrint
    {
        [FunctionName("JustPrint")]
        public static async Task<IActionResult> FirstFunction(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            // Two operators here
            // 1. ?? --> null-coalescing operator --> op1 ?? op2
            // Takes op1 value if its not-null
            // else takes the op2 value.
            // 2. ? --> implies that the name of data object can be null.
            name = name ?? data?.name;

            // This is usual terinary operator
            // Checking for name if null or not and printing message accordingly.
            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";
            string data1 = "@{'number':'11'}";
            //req.Body = data1;
            HttpRequestMessage httpreq = new HttpRequestMessage();
            httpreq.Content = new StringContent("{\"number\":\"11\"}", Encoding.UTF8, "application/json");
            //var response = ConditionalFunction.Run(httpreq, log);
            //Console.WriteLine(response);
            return new OkObjectResult(responseMessage);
        }

        [FunctionName("JustPrint2")]
        public static async Task<IActionResult> SecondFunction(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            // Two operators here
            // 1. ?? --> null-coalescing operator --> op1 ?? op2
            // Takes op1 value if its not-null
            // else takes the op2 value.
            // 2. ? --> implies that the name of data object can be null.
            name = name ?? data?.name;

            // This is usual terinary operator
            // Checking for name if null or not and printing message accordingly.
            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";
            string data1 = "@{'number':'11'}";
            //req.Body = data1;
            HttpRequestMessage httpreq = new HttpRequestMessage();
            httpreq.Content = new StringContent("{\"number\":\"11\"}", Encoding.UTF8, "application/json");
            //var response = ConditionalFunction.Run(httpreq, log);
            //Console.WriteLine(response);
            return new OkObjectResult(responseMessage);
        }

    }
}
