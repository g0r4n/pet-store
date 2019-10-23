using PetStore.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace PetStore.Services.Interfaces
{
	/// <summary>
	/// Defines all actions that any admin management service must provide.
	/// </summary>
	public interface IManagementService
	{
		/// <summary>
		/// Gets paged list of products.
		/// </summary>
		/// <param name="pageIndex">Number of the requested page.</param>
		/// <param name="pageSize">Number of elements that needs to be provided.</param>
		Task<IPagedList<Product>> GetProductsAsync(int pageIndex, int pageSize);

		/// <summary>
		/// Gets one particular product.
		/// </summary>
		/// <param name="id">Id of a requested product.</param>
		Task<Product> GetProductAsync(int id);

		/// <summary>
		/// Adds new product to repository.
		/// </summary>
		/// <param name="product">Product that will be added to repository.</param>
		Task AddProductAsync(Product product);

		/// <summary>
		/// Removes product from repository.
		/// </summary>
		/// <param name="productId">Id of a product that will be removed.</param>
		Task RemoveProductAsync(int productId);

		/// <summary>
		/// Updates product in repository.
		/// </summary>
		/// <param name="productId">Id of a product that will be updated.</param>
		/// <param name="product">New information about product.</param>
		Task UpdateProductAsync(int productId, Product product);

		/// <summary>
		/// Gets order from repository.
		/// </summary>
		/// <param name="orderId">Id of a requested order.</param>
		Task<Order> GetOrder(int orderId);

		/// <summary>
		/// Gets paged list of orders.
		/// </summary>
		/// <param name="pageIndex">Number of the requested page.</param>
		/// <param name="pageSize">Number of elements that needs to be provided.</param>
		Task<IPagedList<Order>> GetOrders(int pageIndex, int pageSize);


	}
}
