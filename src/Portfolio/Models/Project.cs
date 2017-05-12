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
        public string Name { get; set; }

        public static List<Project> GetProjects()
        {
            var client = new RestClient("https://api.github.com/");
            var request = new RestRequest("users/nsanders9022/starred", Method.GET);
            request.AddHeader("User-Agent", "nsanders9022");
            request.AddHeader("Accept", "application/vnd.github.v3+json");
            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();

            var jsonResponse = JsonConvert.DeserializeObject<JArray>(response.Content);
            //Console.WriteLine("json response: " + jsonResponse);
            string jsonOutput = jsonResponse.ToString();
            var projectList = JsonConvert.DeserializeObject<List<Project>>(jsonOutput);
            //Console.WriteLine("json output: " + projectList[0].name);
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
