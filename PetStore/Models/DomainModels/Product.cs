using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.Models.DomainModels
{
	/// <summary>
	/// Product model in database.
	/// </summary>
	public class Product : Entity
	{
		/// <summary>
		/// Name of the product.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Description of product.
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Type of the product.
		/// </summary>
		public ProductType Type { get; set; }
	}

	/// <summary>
	/// Represents types of product in store.
	/// </summary>
	public enum ProductType
	{
		Pet,
		Toy
	}
}
