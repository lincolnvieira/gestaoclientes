using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GestaoCliente.FacilAssist.Util
{
    public static class CallApi
    {
        public async static Task<string> GetInfo(string endpoint)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(endpoint);
                return await response.Content.ReadAsStringAsync();
            }
        }

        public async static Task<HttpResponseMessage> InsertAlterInfo(string message, HttpMethod metodo, string endpoint)
        {
            using (var client = new HttpClient())
            {
                HttpRequestMessage request = new HttpRequestMessage(metodo, endpoint)
                {
                    Content = new StringContent(message, Encoding.UTF8, "application/json")
                };
                return await client.SendAsync(request);
            }
        }
        public async static Task<HttpResponseMessage> DeleteInfo(string endpoint)
        {
            using (var client = new HttpClient())
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, endpoint);
                return await client.SendAsync(request);
            }
        }
    }
}