using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Extensions.DependencyInjection;

namespace com.opusmagus
{
    public class ProcessOrder
    {
        private static IServiceProvider serviceProvider;
        static ProcessOrder() {
            //serviceProvider = AppConfig.CreateServiceProvider();
        }

        [FunctionName("process_order")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req, ILogger log, IOrderPersister orderPersister)
        {
            log.LogInformation("Processing order...");            
            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;
            
            //var orderPersister = serviceProvider.GetService<IOrderPersister>();
            if(orderPersister != null)
                log.LogInformation($"Found an order persister of type {orderPersister.ToString()}");

            log.LogInformation("Processing order done!");            
            return (ActionResult)new OkObjectResult($"Done!");
        }
    }
}
