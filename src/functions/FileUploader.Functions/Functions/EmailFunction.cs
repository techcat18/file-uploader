using System.Threading.Tasks;
using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FileUploader.Functions.Functions;

public static class EmailFunction
{
    [FunctionName("EmailFunction")]
    public static async Task RunAsync([QueueTrigger("myqueue", Connection = "")] string myQueueItem, ILogger log)
    {
        log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        
    }
}