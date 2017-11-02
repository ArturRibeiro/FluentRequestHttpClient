using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentRequestHttpClient.Request;
using FluentRequestHttpClient.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FluentRequestHttpClient.Extensions
{
    public static class HttpResponseMessageExtensions
    {
        public static async Task<TResponse> ReadResponse<TRequest, TResponse>(this HttpResponseMessage responseMessage)
            where TRequest : BaseRequestMessage
            where TResponse : BaseResponseMessage, new()

        {
            using (var stream = await responseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false))
            {
                using (var sr = new StreamReader(stream))
                {
                    using (var jsonReader = new JsonTextReader(sr))
                    {
                        var serializer = new JsonSerializer();

                        serializer.Converters.Add(new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy HH:mm:ss" });

                        //serializer.Converters.Add(new JsonDecimalConverterss());

                        return serializer.Deserialize<TResponse>(jsonReader);
                    }
                }
            }
        }

        public static async Task<TResponse> ReadResponse2<TRequest, TResponse>(this HttpResponseMessage responseMessage)
            where TRequest : BaseRequestMessage
            where TResponse : BaseResponseMessage, new()
        {
            var json = await responseMessage.Content.ReadAsStringAsync();

            var response = new TResponse { Result = JsonConvert.DeserializeObject<IList<TResponse>>(json) };
            response.StatusCode = response.StatusCode;

            return response;
        }
    }
}