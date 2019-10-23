using PetStore.Db;
using PetStore.Models.DomainModels;
using PetStore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace PetStore.Services
{
	/// <summary>
	/// Defines instance of management service.
	/// For more info about methods, <see cref="IManagementService"/>.
	/// </summary>
	public class ManagementService : IManagementService
	{
		public IRepository<Product> Products { get; private set; }

		public IRepository<Order> Orders { get; private set; }

		public ManagementService(IRepository<Product> products, IRepository<Order> orders)
		{
			Products = products;
			Orders = orders;
		}

		public async Task<Product> GetProductAsync(int id) => await Products.GetByIdAsync(id);

		public async Task<IPagedList<Product>> GetProductsAsync(int pageIndex, int pageSize)
		{
			IPagedList<Product> paginatedProducts = await Products.List().ToPagedListAsync(pageIndex, pageSize);
			return paginatedProducts;
		}

		public async Task AddProductAsync(Product product) => await Products.AddAsync(product);

		public async Task RemoveProductAsync(int productId) => await Products.DeleteAsync(productId);

		public async Task UpdateProductAsync(int productId, Product product) => await Products.UpdateAsync(productId, product);

		public async Task<IPagedList<Order>> GetOrders(int pageIndex, int pageSize)
		{
			IPagedList<Order> paginatedProducts = await Orders.List().ToPagedListAsync(pageIndex, pageSize);
			return paginatedProducts;
		}

		public async Task<Order> GetOrder(int orderId) => await Orders.GetByIdAsync(orderId);
	}
}
