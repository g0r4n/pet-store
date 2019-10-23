using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.Models.DomainModels
{
	/// <summary>
	/// Order model in db.
	/// </summary>
	public class Order : Entity
	{
		/// <summary>
		/// Id of a user that places order.
		/// </summary>
		public int UserId { get; set; }
		public virtual User User { get; set; }

		/// <summary>
		/// Date when order was placed.
		/// </summary>
		public DateTime OrderDate { get; set; }

		/// <summary>
		/// Reference to all items within order.
		/// </summary>
		public virtual ICollection<OrderItem> OrderItems { get; set; }
	}
}
