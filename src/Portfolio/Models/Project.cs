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
        public string Id { get; set; }
        public string Url { get; set; }
        public string Stars { get; set; }

        public static List<Project> GetProjects()
        {
            var client = new RestClient("https://api.github.com");
            var request = new RestRequest("users/nsanders9022/repos", Method.GET);
            request.AddParameter("Authorization", "Bearer -3e765e54f6c06bc73d85f4fdc7139abfcc1004e7", ParameterType.HttpHeader);
            request.AddParameter("content type", "application/json", ParameterType.HttpHeader);
            //request.AddParameter("Accept", "application/vnd.github.v3+json", ParameterType.HttpHeader);
            //request.AddParameter("sort", "stars");
            //request.AddParameter("order", "desc");
            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            Console.WriteLine("jsonresponse is " + jsonResponse);

            string jsonOutput = jsonResponse["repos"].ToString();
            //Console.WriteLine(jsonOutput);
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
