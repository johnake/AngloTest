using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Diagnostics;
using AngloAmers.Model;
using System.Net;
using AngloAmers.Service;

namespace AngloAmers.Actions
{
    public class GetRequests
    {
        private static HttpClient client;
        public Car _car;
        public IList<Car> car;
        public int _responseCode;

        public GetRequests()
        {
            RunAsync();
        }

        static void RunAsync()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:54356/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IList<Car>> GetCarByType(string type)
        {
            String resource = "Cars/" + type;
            car = null;
            HttpResponseMessage response = await client.GetAsync(resource);
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                try
                {
                    car = JsonConvert.DeserializeObject<IList<Car>>(result);
                }
                catch (Exception ex)
                {
                    Debug.Write("Unable to deserialize object: " + ex.Message);
                }
            }

            if (response == null)
            {
                return null;
            }

            return car;
        }

        public async Task<int> GetCarByTypeResponseCode(string type)
        {
            String resource = "Cars/" + type;
            car = null;
            HttpResponseMessage response = await client.GetAsync(resource);

            _responseCode = (int)response.StatusCode;

            return _responseCode;

        }
    }
}

