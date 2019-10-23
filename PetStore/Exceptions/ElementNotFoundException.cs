using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.Exceptions
{
	/// <summary>
	/// Thrown when element cannot be found in requested collection.
	/// </summary>
	public class ElementNotFoundException : Exception
	{
		public ElementNotFoundException(string message) : base(message)	{}
	}
}
