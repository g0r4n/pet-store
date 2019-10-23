using AutoMapper;
using PetStore.Db;
using PetStore.Models.DomainModels;
using PetStore.Models.ViewModels.InputViewModels;
using PetStore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace PetStore.Services
{
	/// <summary>
	/// Defines instance of user service.
	/// For more info about methods, <see cref="IUserService"/>.
	/// </summary>
	public class UserService : IUserService
	{
		public IRepository<Product> Products { get; private set; }
		public IRepository<Order> Orders { get; private set; }
		public IRepository<User> Users { get; private set; }
		public IMapper Mapper { get; private set; }

		public UserService(IMapper mapper, IRepository<Product> products, IRepository<Order> orders, IRepository<User> users)
		{
			Mapper = mapper;
			Products = products;
			Orders = orders;
			Users = users;
		}

		public async Task BuyProductAsync(OrderInputViewModel order)
		{
			// Mapping order information(which contains user information) to user domain model.
			var newUser = Mapper.Map<User>(order);

			var newOrder = new Order()
			{
				User = newUser,
				OrderDate = DateTime.UtcNow,
				OrderItems = new List<OrderItem>()
			};


			newOrder.OrderItems.Add(new OrderItem()
			{
				Order = newOrder,
				ProductId = order.ProductId
			});
		
			// Saving information about order to all repositories.
			await Orders.AddAsync(newOrder);
		}

		public async Task<Product> GetProductAsync(int id) => await Products.GetByIdAsync(id);

		public async Task<IPagedList<Product>> GetProductsAsync(int pageIndex, int pageSize)
		{
			IPagedList<Product> paginatedTeams = await Products.List().ToPagedListAsync(pageIndex, pageSize);
			return paginatedTeams;
		}
	}
}
