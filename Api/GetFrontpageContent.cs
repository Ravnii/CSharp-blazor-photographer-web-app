using System;
using System.Net;
using BlazorApp.Shared;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Api
{
    public class GetFrontpageContent
    {
        private readonly ILogger _logger;

        public GetFrontpageContent(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<GetFrontpageContent>();
        }

        [Function("GetFrontpageContent")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var result = new FrontpageContent { Title = GetHeadline(), Summary = GetSummary() };

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.WriteAsJsonAsync(result);

            return response;
        }

        private string GetHeadline()
        {
            return "Fotograf med plads til både små og store";
        }
        private string GetSummary()
        {
            return "Fotograf Vicki har mere end 10 års erfaring. Med eget studio kan der tages billeder i rolige omgivelse der, eller det kan være som udkørende fotograf";
        }
    }
}
