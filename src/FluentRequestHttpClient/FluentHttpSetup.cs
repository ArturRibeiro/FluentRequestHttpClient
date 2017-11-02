using System;
using System.Collections.Generic;
using FluentRequestHttpClient.Enuns;
using FluentRequestHttpClient.Parameters;

namespace FluentRequestHttpClient
{
    public class FluentHttpSetup
    {
        public FluentHttpSetup()
        {
            this.HttpVerb = HttpVerb.Undefined;
            this.DefaultRequestHeaders = new Dictionary<string, string>();
            this.Arguments = new ParameterQueryStringCollection();
        }

        public ParameterQueryStringCollection Arguments { get; internal set; }

        public IDictionary<string, string> DefaultRequestHeaders { get; internal set; }

        public Uri Uri { get; internal set; }

        public string Rota { get; internal set; }

        public int? Timeout { get; internal set; }

        public HttpVerb HttpVerb { get; internal set; }
    }
}