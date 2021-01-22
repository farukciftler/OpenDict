using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;

namespace OpenDict.Helpers
{
    public class HttpHelper
    {
        readonly IConfiguration configuration;
        readonly HttpContextAccessor _httpContextAccessor;
        public HttpHelper (IConfiguration configuration, HttpContextAccessor httpContextAccessor)
        {
            this.configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public T GetApiEndpoint<T>(string apiendpoint)
        {
            var url = "http://" + _httpContextAccessor.HttpContext.Request.Host + apiendpoint;
            IRestClient restClient = new RestClient(url);
            IRestRequest restRequest = new RestRequest();
            var restResponse = restClient.Get(restRequest);
            var deserializedObject = JsonConvert.DeserializeObject<T>(restResponse.Content);

            return deserializedObject;
        }
        public T PostMethod<T>(object obj, string uri, string bearerToken = null, Dictionary<string, string> headers = null)
        {
            var client = new RestClient( uri);
            var request = new RestRequest(Method.POST) { RequestFormat = DataFormat.Json };
            if (bearerToken != null)
            {
                request.AddHeader("Authorization", string.Format("Bearer {0}", bearerToken));
                request.AddHeader("Accept", "application/json; charset=utf-8");


            }
            else
            {
                request.AddHeader("Accept", "application/json; charset=utf-8");
            }

            var result = GetResult<T>(client, request, obj, headers);

            return result;
        }

        private  T GetResult<T>(RestClient client, RestRequest request, object obj = null, Dictionary<string, string> headers = null)
        {

            if (headers != null) //Add headers to request if header exists
            {
                foreach (var header in headers)
                {
                    request.AddHeader(header.Key, header.Value);
                    request.AddHeader("Accept", "application/json; charset=utf-8");
                }
            }

            if (obj != null) //Add to request if there is an object to be sent to the service for operations such as post, put, delete.
            {
                request.AddJsonBody(obj);

            }
            //Send request to service via client
            var response = client.Execute(request);


            return JsonConvert.DeserializeObject<T>(response.Content, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

        }
    }
}
