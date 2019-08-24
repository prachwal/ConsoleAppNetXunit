using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class MyTestClass
    {
        private readonly HttpClient httpClient;

        public MyTestClass(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Rootobject> GetSomethingRemoteAsync(string url)
        {
            HttpResponseMessage response = await this.httpClient.GetAsync($"http://test.com/{url}");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<List<Class1>>(responseBody);
            return new Rootobject() { Property1 = res};
        }
    }

    public class Rootobject
    {
        public List<Class1> Property1 { get; set; }
    }

    public class Class1
    {
        public int id { get; set; }
        public string value { get; set; }
    }


}