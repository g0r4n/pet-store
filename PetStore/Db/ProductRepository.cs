using PetStore.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.Db
{
	/// <summary>
	/// Reference to 'Product' table in database.
	/// </summary>
	public class ProductRepository : SqlRepository<Product>
	{
		public ProductRepository(PetStoreContext context) : base(context) => Table = context.Product;

		/// <summary>
		/// Updates provided product.
		/// </summary>
		/// <param name="id">Id of a product that will be updated.</param>
		/// <param name="item">Information for updating product.</param>
		/// <returns></returns>
		public async override Task UpdateAsync(int id, Product item)
		{
			Table.Update(item);
			await Database.SaveChangesAsync();
		}
	}
}
