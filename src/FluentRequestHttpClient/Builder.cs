namespace FluentHttpClient
{

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TResponse">Remover TResponse, não precisa trafegar em todas as classes</typeparam>
    /// <typeparam name="TRequest"></typeparam>
	public static class Builder<TResponse, TRequest>
	{
		public static ISingleObjectBuilder<TResponse, TRequest> CreateNew()
		{
			return new ObjectBuilder<TResponse, TRequest>();
		}
	}
}