using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Web.Http;

namespace GroupFunctions
{
    // This function takes in a number and returns OKobject result only if the number is prime number.
    public static class ConditionalFunction
    {
        public static bool isPrime(int number) {
            int i = 2;
            while ( i < (number/2)) {
                if (number % i == 0) {
                    return false;
                }
                i++;
            }
            return true;       
        }
        [FunctionName("ConditionalFunction")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string number = req.Query["number"];
            int num;

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            number = data.number;
            num = int.Parse(number);
            string responseMessage = "You didnt pass a prime number";
            if (num != 0) {
                if (isPrime(num)) {
                    responseMessage = "Passed a prime number";
                    return new OkObjectResult(responseMessage);
                }
            }
            return new BadRequestObjectResult(responseMessage);
        }
    }
}
