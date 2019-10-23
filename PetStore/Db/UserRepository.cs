using PetStore.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.Db
{
	/// <summary>
	/// Reference to 'User' table in database.
	/// </summary>
	public class UserRepository : SqlRepository<User>
	{
		public UserRepository(PetStoreContext context) : base(context) => Table = context.User;


		/// <summary>
		/// For now, there is no definition for updating customer.
		/// </summary>
		/// <param name="id"></param>
		/// <param name="item"></param>
		/// <returns></returns>
		public override Task UpdateAsync(int id, User item)
		{
			throw new NotImplementedException();
		}
	}
}
