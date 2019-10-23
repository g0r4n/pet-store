using System.Net;

namespace PetStore.Filters
{
	/// <summary>
	/// When some error within program occurs, error view will use this model for storaging needed error details.
	/// </summary>
	public class Error
	{
		/// <summary>
		/// Message that will be displayed in Error view.
		/// </summary>
		public string Message { get; set; }

		/// <summary>
		/// Status code that server sends to client.
		/// </summary>
		public HttpStatusCode StatusCode { get; set; }
	}
}