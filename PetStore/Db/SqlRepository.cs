using Microsoft.EntityFrameworkCore;
using PetStore.Exceptions;
using PetStore.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.Db
{
	/// <summary>
	/// Represents abstraction of every SQL Repository (Table) used within application.
	/// </summary>
	abstract public class SqlRepository<T> : IRepository<T> where T : Entity
	{
		/// <summary>
		/// Database used for manipulating data within app.
		/// </summary>
		public DbContext Database { get; private set; }

		/// <summary>
		/// Reference to table that is used for communication, used in derived classes.
		/// </summary>
		public DbSet<T> Table { get; set; }

		public SqlRepository(DbContext context) => Database = context;

		/// <summary>
		/// Gets element by id in the database.
		/// </summary>
		/// <param name="id">Id of requested element in database.</param>
		/// <exception cref="ElementNotFoundException">Thrown when element with provided id does not exist.</exception>
		public async Task<T> GetByIdAsync(int id)
		{
			T item = await Table.FirstOrDefaultAsync(i => i.Id == id);
			if (item == null)
				throw new ElementNotFoundException("Element with provided id does not exist in requested collection (for example: database table).");
			return item;
		}

		/// <summary>
		/// Adds new element to database.
		/// </summary>
		/// <param name="item">Item that will be added to database.</param>
		public async Task AddAsync(T item)
		{
			await Table.AddAsync(item);
			await Database.SaveChangesAsync();
		}

		/// <summary>
		/// Deletes element from database.
		/// </summary>
		/// <param name="id">Id of an element that will be removed.</param>
		public async Task DeleteAsync(int id)
		{
			Table.Remove(await GetByIdAsync(id));
			await Database.SaveChangesAsync();
		}

		/// <summary>
		/// Updates element in database with provided id.
		/// </summary>
		/// <param name="id">Id of an element that will be updated.</param>
		/// <param name="item">Contains all necessary for update.</param>
		abstract public Task UpdateAsync(int id, T item);

		/// <summary>
		/// Method used for querying the database with custom expression.
		/// </summary>
		/// <param name="expression">Custom expression used for querying the db.</param>
		public IQueryable<T> Query(Func<T, bool> expression) => Table.Where(expression).AsQueryable();

		/// <summary>
		/// Returns table as enumerable.
		/// </summary>
		/// <returns></returns>
		public IEnumerable<T> List() => Table.AsEnumerable();
	}
}
