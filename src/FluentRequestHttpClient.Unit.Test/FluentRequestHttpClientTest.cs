using System.Net;
using Xunit;
using FluentRequestHttpClient.Enuns;
using FluentRequestHttpClient.Response;
using FluentRequestHttpClient.Parameters;
using FluentRequestHttpClient.Request;

namespace FluentRequestHttpClient.Unit.Test
{

    public class CommentMessageResponse : BaseResponseMessage
    {
        public string postId { get; set; }

    }

    public class CommentMessageRequest : BaseRequestMessage
    {
        public string postId { get; set; }
    }

    public class FluentRequestHttpClientTest
    {
        [Theory]
        [InlineData(HttpVerb.Get, "https://jsonplaceholder.typicode.com/", "comments", 1)]
        public void ExecuteGetWithArguments(HttpVerb verb, string uri, string rota, string parameter)
        {
            var result = FluentBuilder
                .CreateNewList()
                    .Authenticate("usuario", "senha")
                    .WithHeader("MerchantKey", "7b379c45-57d6-4508-ae56-29bb0b3c9741")
                    .WithTimeout(1000)
                    .WithArguments(x => ParameterQueryString.Factor.Create("nome", "1"))
                    .AddUri(uri)
                    .AddRota(rota)
                    .SetVerb(HttpVerb.Get)
                .GetAsync<CommentMessageRequest, CommentMessageResponse>()
                .Result;

            Assert.True(result.IsSuccessStatusCode);
            Assert.Equal(result.StatusCode, HttpStatusCode.OK);
        }

        [Theory]
        [InlineData(HttpVerb.Get, "https://jsonplaceholder.typicode.com/", "posts")]
        [InlineData(HttpVerb.Get, "https://jsonplaceholder.typicode.com/", "posts/1")]
        [InlineData(HttpVerb.Get, "https://jsonplaceholder.typicode.com/", "posts/1/comments")]
        public void ExecuteGet(HttpVerb verb, string uri, string rota)
        {
            var result = FluentBuilder
                .CreateNew()
                .Authenticate("usuario", "senha")
                    .WithHeader("", "")
                    .WithTimeout(1000)
                    .AddUri(uri)
                    .AddRota(rota)
                    .SetVerb(HttpVerb.Get)
                .GetAsync<CommentMessageRequest, CommentMessageResponse>()
                .Result;

            Assert.True(result.IsSuccessStatusCode);
            Assert.Equal(result.StatusCode, HttpStatusCode.OK);
        }

        [Theory]
        [InlineData(HttpVerb.Put, "", "", "https://jsonplaceholder.typicode.com/", "posts/1")]
        public void ExecutePutWithArguments(HttpVerb verb, string user, string password, string uri, string rota)
        {
            var result = FluentBuilder
                .CreateNew()
                    .Authenticate(user, password)
                    .WithHeader("", "")
                    .AddUri(uri)
                    .AddRota(rota)
                    .SetVerb(verb)
                .GetAsync<CommentMessageRequest, CommentMessageResponse>()
                .Result;

            Assert.True(result.IsSuccessStatusCode);
            Assert.Equal(result.StatusCode, HttpStatusCode.OK);
        }
    }
}
