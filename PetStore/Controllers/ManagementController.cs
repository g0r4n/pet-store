using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetStore.Models.DomainModels;
using PetStore.Models.ViewModels;
using PetStore.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace PetStore.Controllers
{
	/// <summary>
	/// Contains all endpoinds that only admin can access.
	/// </summary>
	[Authorize]
	public class ManagementController : Controller
    {
		/// <summary>
		/// Reference to a service that contains all actions that admin can invoke.
		/// </summary>
		public IManagementService ManagementService { get; private set; }

		public ManagementController(IManagementService managementService) => ManagementService = managementService;

		/// <summary>
		/// Page where paged list of products is shown.
		/// Because of admin privileges, different actions on products are possible.
		/// </summary>
		public async Task<IActionResult> Index(int pageIndex = 1)
		{
			IPagedList<Product> products = await ManagementService.GetProductsAsync(pageIndex, 5);
			return View(products);
		}


		/// <summary>
		/// Endpoint for creating new product.
		/// </summary>
		/// <param name="product">Information about new product.</param>
		[HttpPost]
		public async Task<IActionResult> CreateProduct(Product product)
		{
			await ManagementService.AddProductAsync(product);
			return RedirectToAction("Index", "Management");
		}

		/// <summary>
		/// Shows page where product details are shown.
		/// Admin can change details about product.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<IActionResult> ProductDetails(int id)
		{
			Product product = await ManagementService.GetProductAsync(id);
			return View(product);
		}

		/// <summary>
		/// Endpoint used for removing product from database.
		/// </summary>
		/// <param name="id">Id of a product that will be removed.</param>
		/// <returns></returns>
		public async Task<IActionResult> Remove(int id)
		{
			await ManagementService.RemoveProductAsync(id);
			return RedirectToAction("Index", "Management");
		}

		/// <summary>
		/// Endpoint for updating existing product.
		/// </summary>
		/// <param name="product">Information about product that will be updated.</param>
		public async Task<IActionResult> UpdateProduct(Product product)
		{
			await ManagementService.UpdateProductAsync(product.Id, product);
			return RedirectToAction("Index", "Management");
		}

		/// <summary>
		/// Shows paged list of all customers orders.
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <returns></returns>
		public async Task<IActionResult> Orders(int pageIndex = 1)
		{
			IPagedList<Order> orders = await ManagementService.GetOrders(pageIndex, 5);
			return View(orders);
		}

		/// <summary>
		/// Shows details of particular order.
		/// </summary>
		/// <param name="id">Id of an order for which details will be shown.</param>
		/// <returns></returns>
		public async Task<IActionResult> OrderDetails(int id)
		{
			Order order = await ManagementService.GetOrder(id);
			return View(order);
		}
	}
}