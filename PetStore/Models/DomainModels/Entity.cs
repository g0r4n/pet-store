using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.Models.DomainModels
{

	/// <summary>
	/// Used as base model for all database models.
	/// </summary>
	public class Entity
	{
		/// <summary>
		/// Id of a record in database.
		/// </summary>
		public int Id { get; set; }
	}
}
