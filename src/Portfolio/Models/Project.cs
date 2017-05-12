using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;

namespace Portfolio.Models
{
    public class Project
    {
        public string Url { get; set; }
        public string Stars { get; set; }
        public string HtmlUrl { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        public static List<Project> GetProjects()
        {
            var client = new RestClient("https://api.github.com/");
            var request = new RestRequest("search/repositories", Method.GET);
            request.AddParameter("q", "nsanders9022");
            request.AddParameter("sort", "stars");
            request.AddParameter("order", "desc");
            request.AddParameter("per_page", "3");
            request.AddHeader("Authorization", "token 083a431b2e212e15bb31ff3f7c9ee4ca00527a9f");
            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();

            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            Console.WriteLine("json response " + jsonResponse);
            string jsonOutput = jsonResponse["repos"].ToString();
            
            var projectList = JsonConvert.DeserializeObject<List<Project>>(jsonOutput);
            return projectList;
        }

        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response =>
            {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }
    }
}
