using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetStore.Models.DomainModels;
using PetStore.Models.ViewModels.InputViewModels;
using PetStore.Services.Interfaces;
using X.PagedList;

namespace PetStore.Controllers
{
	public class HomeController : Controller
	{
		/// <summary>
		/// Reference to a service that contains all operations that regular user can invoke.
		/// </summary>
		public IUserService UserService { get; private set; }

		public HomeController(IUserService userService) => UserService = userService;

		/// <summary>
		/// Shows page where paged list of products is shown.
		/// </summary>
		public async Task<IActionResult> Index(int pageIndex = 1)
		{
			IPagedList<Product> listOfProducts = await UserService.GetProductsAsync(pageIndex, 5);
			return View(listOfProducts);
		}

		/// <summary>
		/// Shows page where form for customer's information is shown.
		/// </summary>
		/// <param name="id">Id of a product that's been requested.</param>
		/// <returns></returns>
		public IActionResult Buy(int id)
		{
			ViewBag.ProductId = id;
			return View();
		}

		/// <summary>
		/// Endpoint that saves customer's order to database.
		/// </summary>
		/// <param name="input">Customer's info provided on registration form.</param>
		/// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> Buy(OrderInputViewModel input)
		{
			if (!ModelState.IsValid) return View("Buy", input);
			await UserService.BuyProductAsync(input);
			return View("Confirmation");
		}

	}
}
