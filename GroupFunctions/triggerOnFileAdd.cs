using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace GroupFunctions
{
    public static class triggerOnFileAdd
    {
        [FunctionName("triggerOnFileAdd")]
        public static void Run([BlobTrigger("samples-workitems/{name}", Connection = "fileAdd")]Stream myBlob, string name, ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
            log.LogInformation($"I just am executing the default template created by Visual Studio2019");
        }
    }
}
