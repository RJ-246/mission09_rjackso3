using System;
using System.Linq;

namespace mission09_rjackso3.Models
{
	public class BookRepository : IBookRepository
	{
		private BookstoreContext context { get; set; }
		public BookRepository(BookstoreContext temp) => context = temp;
		public IQueryable<Book> Books => context.Books;
	}
}

