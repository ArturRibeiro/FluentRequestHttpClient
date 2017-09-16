using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using FluentHttpClient.Intefarces;

namespace FluentHttpClient
{
	public class Rest : IRest
	{
		#region Propriedades

		//public HttpClient BaseClient
		//{
		//    get;
		//}

		public Dictionary<string, string> Headers { get; internal set; }

		public TimeSpan TimeOut { get; internal set; }

		public string Schema { get; internal set; }

		public string Parameter { get; internal set; }

		public Uri Uri { get; internal set; }

		#endregion

		public Rest()
		{
			this.Headers = new Dictionary<string, string>();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="scheme"></param>
		/// <param name="parameter"></param>
		/// <returns></returns>
		public IRest Authenticate(string scheme, string parameter)
		{
			//this.BaseClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(scheme, parameter);
			this.Schema = scheme;
			this.Parameter = parameter;

			return this;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="timeout"></param>
		/// <returns></returns>
		public IRest WithTimeout(int timeout) => WithTimeout(TimeSpan.FromSeconds(timeout));

		/// <summary>
		/// 
		/// </summary>
		/// <param name="key"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public IRest WithHeader(string key, string value)
		{
			if (this.Headers.ContainsKey(key))
				this.Headers[key] = value;
			else
				this.Headers.Add(key, value);

			return this;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="url"></param>
		/// <returns></returns>
		public IRest WithBaseUrl(string url)
		{
			var uri = new Uri(url);

			this.Uri = this.NormaliseUrl(uri);

			return this;
		}

		public void Dispose()
		{
			//BaseClient?.Dispose();
			GC.SuppressFinalize(this);
		}


		#region Métodos Privados

		private IRest WithTimeout(TimeSpan timeout)
		{
			//this.BaseClient.Timeout = TimeSpan.FromMilliseconds(milliseconds);

			this.TimeOut = timeout;
			return this;
		}

		private Uri NormaliseUrl(Uri uri)
		{
			if (uri == null) return null;

			// make sure directory paths end with a slash to avoid unintuitive behaviour
			var builder = new UriBuilder(uri);
			if (!uri.AbsolutePath.EndsWith("/") && !Path.HasExtension(uri.AbsolutePath))
			{
				builder.Path += "/";
				uri = builder.Uri;
			}

			return uri;
		}

		#endregion
	}
}