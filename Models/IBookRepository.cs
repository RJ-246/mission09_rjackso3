using System;
using System.Linq;

namespace mission09_rjackso3.Models
{
	public interface IBookRepository
	{
		IQueryable<Book> Books { get; }
	}
}

