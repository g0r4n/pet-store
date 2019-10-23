using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.Models.DomainModels
{
	/// <summary>
	/// Used for 'many to many' table between 'Order' and 'Product'.
	/// </summary>
	public class OrderItem
	{
		public int OrderId { get; set; }
		public virtual Order Order { get; set; }

		public int ProductId { get; set; }
		public virtual Product Product { get; set; }

		public int Quantity { get; set; }
	}
}
