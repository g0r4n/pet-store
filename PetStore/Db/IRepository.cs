using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.Db
{
	/// <summary>
	/// Interface that should be inherited by all repositories.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IRepository<T>
	{
		/// <summary>
		/// Returns object from collection with given id.
		/// </summary>
		/// <param name="id">Id of a needed document.</param>
		Task<T> GetByIdAsync(int id);

		/// <summary>
		/// Adds new item in collection.
		/// </summary>
		/// <param name="item">Item that needs to be added to collection.</param>
		Task AddAsync(T item);

		/// <summary>
		/// Updates item that has given id with new item that was provided.
		/// </summary>
		/// <param name="id">Id of a document that needs to be updated.</param>
		Task UpdateAsync(int id, T item);

		/// <summary>
		/// Deletes item with provided id from collection.
		/// </summary>
		/// <param name="id">Id of the document that needs to be deleted.</param>
		Task DeleteAsync(int id);

		/// <summary>
		/// Queries the database with provided expression.
		/// </summary>
		/// <param name="expression">Expression that will be used for querying the database.</param>
		IQueryable<T> Query(Func<T, bool> expression);

		/// <summary>
		/// Returns collection as enumerable.
		/// </summary>
		IEnumerable<T> List();
	}
}
