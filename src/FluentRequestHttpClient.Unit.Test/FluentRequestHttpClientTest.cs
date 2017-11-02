using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Xunit;
using FluentRequestHttpClient;
using FluentRequestHttpClient.Enuns;
using FluentRequestHttpClient.Response;
using FluentRequestHttpClient.Parameters;

namespace FluentRequestHttpClient.Unit.Test
{

    public class CommentMessageResponse : BaseResponseMessage
    {
        public string postId { get; set; }

    }

    public class CommentMessageRequest
    {
        public string postId { get; set; }
    }

    //var ob = new ObjectBuilder<PessoaMessaResponse, PessoaMessaRequest>();
    //var ob = new ObjectBuilder<PessoaMessaResponse, PessoaMessaRequest>();

    public class FluentRequestHttpClientTest
    {
        [Theory]
        [InlineData(HttpVerb.Get, "https://jsonplaceholder.typicode.com/", "comments", 1)]
        public void ExecuteGetWithArguments(HttpVerb verb, string uri, string rota, string parameter)
        {
            //ParameterQueryString

            var result = FluentBuilder<CommentMessageResponse, CommentMessageRequest>
                .CreateNew()
                .Authenticate("usuario", "senha")
                    .WithHeader("MerchantKey", "7b379c45-57d6-4508-ae56-29bb0b3c9741")
                    .WithTimeout(1000)
                    .WithArguments(x => ParameterQueryString.Factor.Create("nome", "1"))
                    .AddUri(uri)
                    .AddRota(rota)
                    .SetVerb(HttpVerb.Get)
                .GetAsync()
                .Result;

            //Assert.True(result.IsSuccessStatusCode);
        }

        [Theory]
        [InlineData(HttpVerb.Get, "https://jsonplaceholder.typicode.com/", "posts")]
        [InlineData(HttpVerb.Get, "https://jsonplaceholder.typicode.com/", "posts/1")]
        [InlineData(HttpVerb.Get, "https://jsonplaceholder.typicode.com/", "posts/1/comments")]
        public void ExecuteGet(HttpVerb verb, string uri, string rota)
        {
            var result = FluentBuilder<CommentMessageResponse, CommentMessageRequest>
                .CreateNew()
                .Authenticate("usuario", "senha")
                    .WithHeader("", "")
                    .WithTimeout(1000)
                    .AddUri(uri)
                    .AddRota(rota)
                    .SetVerb(HttpVerb.Get)
                .GetAsync()
                .Result;

            //Assert.True(result.IsSuccessStatusCode);
        }

        [Theory]
        [InlineData(HttpVerb.Put, "", "", "https://jsonplaceholder.typicode.com/", "posts/1")]
        public void ExecutePutWithArguments(HttpVerb verb, string user, string password, string uri, string rota)
        {
            var result = FluentBuilder<CommentMessageResponse, CommentMessageRequest>
                .CreateNew()
                    .Authenticate(user, password)
                    .WithHeader("", "")
                    .AddUri(uri)
                    .AddRota(rota)
                    .SetVerb(verb)
                .GetAsync()
                .Result;

            //Assert.True(result.IsSuccessStatusCode);
        }
    }
}
