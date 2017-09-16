using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;

namespace FluentApiRestFull
{
	public class Rest : IRest
	{
		#region Propriedades

		//public HttpClient BaseClient
		//{
		//    get;
		//}

		public int TimeoutMilliseconds { get; internal set; }

		public string Schema { get; internal set; }

		public string Parameter { get; internal set; }

		public string Uri { get; internal set; }

		#endregion



		public IRest Authenticate(string scheme, string parameter)
		{
			//this.BaseClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(scheme, parameter);
			this.Schema = scheme;
			this.Parameter = parameter;

			return this;
		}

		public IRest WithTimeout(int timeout) => WithTimeout(this.TimeoutMilliseconds = timeout);

		//public IRest WithTimeout(int milliseconds)
		//      {
		//          //this.BaseClient.Timeout = TimeSpan.FromMilliseconds(milliseconds);

		//          this.TimeoutMilliseconds = milliseconds;
		//          return this;
		//      }

		public void Dispose()
		{
			//BaseClient?.Dispose();
			GC.SuppressFinalize(this);
		}


		#region Métodos Privados

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

	public interface IRest : IDisposable
	{
		//HttpClient BaseClient { get; }

		int TimeoutMilliseconds { get; }

		string Schema { get; }

		string Parameter { get; }

		string Uri { get; }

		IRest Authenticate(string scheme, string parameter);


		IRest WithTimeout(int value);
	}
}