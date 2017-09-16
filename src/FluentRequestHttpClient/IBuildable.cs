using System;

namespace FluentRequestHttpClient
{
	public interface IBuildable<TResponse, TRequest> :  IDisposable
	{
		//BuilderSettings BuilderSettings { get; set; }
		TResponse Build();
	}
}