using PetStore.Models.DomainModels;
using PetStore.Models.ViewModels.InputViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace PetStore.Services.Interfaces
{
	/// <summary>
	/// Defines all actions that any user service must provide.
	/// </summary>
	public interface IUserService
	{
		/// <summary>
		/// Confirms order and regulates payment.
		/// </summary>
		/// <param name="order">Information about order.</param>
		Task BuyProductAsync(OrderInputViewModel order);

		/// <summary>
		/// Gets list of available products.
		/// </summary>
		/// <param name="pageIndex">Number of the requested page.</param>
		/// <param name="pageSize">Number of elements that needs to be provided.</param>
		Task<IPagedList<Product>> GetProductsAsync(int pageIndex, int pageSize);

		/// <summary>
		/// Gets infor about particular product.
		/// </summary>
		/// <param name="id">Id of a requested product.</param>
		/// <returns></returns>
		Task<Product> GetProductAsync(int id);
	}
}
