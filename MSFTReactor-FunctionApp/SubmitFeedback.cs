using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Models;
using BL;

namespace MSFTReactor_FunctionApp
{
    public static class SubmitFeedback
    {
        [FunctionName("SubmitFeedback")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "TestDemo")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            string responseMessage = "";
            try
            {
                Feedback data = JsonConvert.DeserializeObject<Feedback>(requestBody);
                Business business = new Business();
                business.SubmitFeedback(data);
                responseMessage = "Thank you for the feedback.";
                
            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult("Please try again later");
            }

            return new OkObjectResult(responseMessage);
        }
    }
}
