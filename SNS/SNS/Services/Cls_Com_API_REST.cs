using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;

namespace SNS.Services
{
    public class Cls_Com_API_REST
    {
        //public static HttpClient client = new HttpClient();
        public const double Timeout_sec = 1;

        public Cls_Com_API_REST()
        {

        }

        public static async Task<string> PostAsync_REST(Uri url, StringContent content)
        {
            HttpClient client = new HttpClient();//Creation du client HTTP
            client.Timeout = TimeSpan.FromSeconds(Timeout_sec);
            //POST
            //HttpResponseMessage response = await client.PostAsync(url, content).ConfigureAwait(false);
            HttpResponseMessage response = await client.PostAsync(url, content).ConfigureAwait(false);

            //Resupere le resultat en objet JSON au format string
            string result = await response.Content.ReadAsStringAsync();

            return result;
        }

        public static async Task<string> PutAsync_REST(Uri url, StringContent content)
        {
            HttpClient client = new HttpClient();//Creation du client HTTP
            client.Timeout = TimeSpan.FromSeconds(Timeout_sec);
            //POST
            //HttpResponseMessage response = await client.PutAsync(url, content).ConfigureAwait(false);
            HttpResponseMessage response = await client.PutAsync(url, content).ConfigureAwait(false);
            //Resupere le resultat en objet JSON au format string
            string result = await response.Content.ReadAsStringAsync();

            return result;
        }

        public static async Task<string> GetAsync_REST(Uri url)
        {
            string result = null;
            HttpClient client = new HttpClient();//Creation du client HTTP
            client.Timeout = TimeSpan.FromSeconds(Timeout_sec);
            //HttpResponseMessage response = await client.GetAsync(url).ConfigureAwait(false);
            HttpResponseMessage response = await client.GetAsync(url).ConfigureAwait(false);
            //Resupere le resultat en objet JSON au format string
            result = await response.Content.ReadAsStringAsync();


            return result;
        }

        public static async Task<HttpStatusCode> CheckGet(Uri url)
        {
            HttpClient client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(Timeout_sec);

            HttpResponseMessage response = await client.GetAsync(url).ConfigureAwait(false);
            return response.StatusCode;
        }



        ~Cls_Com_API_REST() { }

    }
}
