using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace FluentRequestHttpClient.Parameters
{
    public sealed class ParameterQueryStringCollection : List<ParameterQueryString>
    {
        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var kvp in this)
            {
                if (sb.Length > 0) { sb.Append("&"); }

                sb.AppendFormat($"{System.Net.WebUtility.UrlEncode(kvp.Name)}={System.Net.WebUtility.UrlEncode(kvp.Value.ToString())}");
            }
            return sb.ToString();
        }

        public new void Add(string name, object value)
        {
            this.Add(ParameterQueryString.Factor.Create(name, value));
        }

    }
}
