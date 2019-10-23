using PetStore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PetStore.Exceptions
{
	public static class ExceptionMiddleware
	{
		/// <summary>
		/// Handles all exceptions within app and shows error page with information about error.
		/// </summary>
		/// <param name="statusCode"></param>

		public static Error HandleException(Exception exception)
		{
			if (exception is ElementNotFoundException)
				return new Error() { StatusCode = HttpStatusCode.NotFound, Message = exception.Message };
			else return new Error() { StatusCode = HttpStatusCode.InternalServerError, Message = exception.Message };
		}
	}
}
