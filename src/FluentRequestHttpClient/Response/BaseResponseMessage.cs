using System.Net;

namespace FluentRequestHttpClient.Response
{
    public class BaseResponseMessage
    {
        public bool IsSuccessStatusCode { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public object Result { get; set; }
    }
}