using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Portfolio.Models
{
    public class Project
    {
        //public string Id { get; set; }
        //public string ZipCode { get; set; }
        //public string Business { get; set; }
        //public string Name { get; set; }

        public static List<Project> GetProjects()
        {
            //https://api.github.com/users/nsanders9022/repos

            stargazers_count": 1
            return null;
        }

        //public static List<Yelp> GetReviews(string business, string zipcode)
        //{
        //    var client = new RestClient("http://api.yelp.com/v3");
        //    var request = new RestRequest("businesses/search", Method.GET);
        //    request.AddParameter("term", business);
        //    request.AddParameter("location", zipcode);
        //    request.AddParameter("Authorization", "Bearer -Da4abtiOYeUJlX7M5lM58akmknszNhKyaVXWBGIS3-798urLmCGsonAX-ong3puatOKeHIr4K9YauuC6UhsQGekZ_1JmbZs96wOR_t0TGTaQxLUoTXA1oYbRYwUWXYx", ParameterType.HttpHeader);
        //    var response = new RestResponse();
        //    Task.Run(async () =>
        //    {
        //        response = await GetResponseContentAsync(client, request) as RestResponse;
        //    }).Wait();
        //    //Console.WriteLine(response);
        //    JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
        //    string jsonOutput = jsonResponse["businesses"].ToString();
        //    //Console.WriteLine(jsonOutput);
        //    var businessList = JsonConvert.DeserializeObject<List<Yelp>>(jsonOutput);
        //    Console.WriteLine(businessList[0].Name);
        //    return businessList;

        //    //return jsonResponse.GetValue("businesses").ToString();
        //}

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
