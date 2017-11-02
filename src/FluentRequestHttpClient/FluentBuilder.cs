using FluentRequestHttpClient.Intefarces;

namespace FluentRequestHttpClient
{
	public static class FluentBuilder
	{
		public static ISingleObjectBuilder CreateNew()
		{
			return new FluentRequestBuilder();
		}

	    public static ISingleObjectBuilder CreateNewList()
	    {
	        return new FluentRequestBuilder();
	    }
	}
}