using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FluentRequestHttpClient.Request;
using FluentRequestHttpClient.Response;

namespace FluentRequestHttpClient
{
    public class FluentGetRequest
    {
        private readonly FluentHttpSetup _setup;

        public FluentGetRequest(FluentHttpSetup setup)
        {
            _setup = setup;
        }


        public async Task<HttpResponseMessage> ExecuteAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_setup.Uri, _setup.Rota);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.Timeout = new TimeSpan(_setup.Timeout.Value);

                var uri = _setup.Arguments.Count > 0 ? $"{_setup.Rota}?{_setup.Arguments}" : _setup.Rota;

                return await client.GetAsync(uri);
            }

            //using (var client = new HttpClient { BaseAddress = _setup.Uri })
            //{
            //    client.DefaultRequestHeaders.Accept.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //    //client.Timeout = new TimeSpan(this.timeout);

            //    var url = _setup.Arguments.Count > 0 ? $"{_setup.Rota}?{_setup.Arguments.ToString()}" : _setup.Rota;

            //    return await client.GetAsync(url);
            //}
        }

    }
}