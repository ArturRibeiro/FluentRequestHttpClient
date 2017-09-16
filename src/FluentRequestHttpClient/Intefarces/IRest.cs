using System;
using System.Collections.Generic;

namespace FluentRequestHttpClient.Intefarces
{
	public interface IRest : IDisposable
	{
		//HttpClient BaseClient { get; }

		Dictionary<string, string> Headers { get; }

		TimeSpan TimeOut { get; }

		string Schema { get; }

		string Parameter { get; }

		Uri Uri { get; }

		IRest Authenticate(string scheme, string parameter);

		IRest WithTimeout(int value);

		IRest WithHeader(string key, string value);

		IRest WithBaseUrl(string url);
	}
}