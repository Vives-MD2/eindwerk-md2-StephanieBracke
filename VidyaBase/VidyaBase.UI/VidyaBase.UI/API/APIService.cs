using System;
using System.Net.Http; // Httpclient
using Refit; // ReFit

namespace VidyaBase.UI.API
{
    public class APIService<T> : IDisposable
    {
        private HttpClient httpClient;
        public T myService;
        public APIService(string url)
        {
            Console.WriteLine("Creating ApiService");

            //Client handler om SSL verificatie te negeren
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            httpClient = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri(url)
            };


            Console.WriteLine("Creating RESTService in ApiService");
            myService = RestService.For<T>(httpClient); //Onze ReFit Service
        }
        public void Dispose()
        {
            Console.WriteLine("disposing ApiService");
            httpClient.Dispose();
        }
    }
}
