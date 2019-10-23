using PetStore.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using PetStore.Filters;

namespace PetStore.Filters
{
	/// <summary>
	/// Filter that catches all exceptions that are thrown from code.
	/// </summary>
	public class ExceptionFilter : ExceptionFilterAttribute
	{
		/// <summary>
		/// This method will be invoked when exception occurs.
		/// </summary>
		/// <param name="context">Contains all informations about request that has been made.</param>
		public override void OnException(ExceptionContext context)
		{
			// Creating view-model that will be used in Error view.
			Error err = ExceptionMiddleware.HandleException(context.Exception);

			// Indicates that thrown exception is handled.
			context.ExceptionHandled = true;

			context.Result = new ViewResult()
			{
				ViewName = "Error",
				ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary()) { Model = err }
			};

		}
	}
}
