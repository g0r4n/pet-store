using Microsoft.EntityFrameworkCore;
using PetStore.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.Db
{
	/// <summary>
	/// Represents reference to 'Order' table in database.
	/// </summary>
	public class OrderRepository : SqlRepository<Order>
	{
		public OrderRepository(PetStoreContext context) : base(context) => Table = context.Order;

		/// <summary>
		/// For now, there is no definition for updating order.
		/// </summary>
		public override Task UpdateAsync(int id, Order item)
		{
			throw new NotImplementedException();
		}
	}
}
