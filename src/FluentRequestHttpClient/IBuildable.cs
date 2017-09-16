using System;

namespace FluentHttpClient
{
	public interface IBuildable<TResponse, TRequest> :  IDisposable
	{
		//BuilderSettings BuilderSettings { get; set; }
		TResponse Build();
	}
}