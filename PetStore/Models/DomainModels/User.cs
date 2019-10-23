using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.Models.DomainModels
{
	/// <summary>
	/// Model of a user in database.
	/// </summary>
	public class User : Entity
	{
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Email { get; set; }

		public string PhoneNumber { get; set; }

		public string CreditCardNumber { get; set; }


		// =========== Properties below have no usage, at least for the current app state. ===========
		// =========== If regular user's begin to authenticate themselves, admins will be saved to db. ===========
		// =========== After that, properties below will be used. ===========

		/// <summary>
		/// True, if user is admin.
		/// </summary>
		public bool IsAdmin { get; set; }

		/// <summary>
		/// Auth0 user id of registered user.
		/// </summary>
		public string Auth0Id { get; set; }
	}
}
