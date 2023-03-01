using System;
namespace mission09_rjackso3.Models.ViewModels
{
	public class PageInfo
	{
		public int TotalBookNum { get; set; }
		public int BooksPerPage { get; set; }
		public int CurrentPage { get; set; }
		public int TotalPages => (int)Math.Ceiling((double)TotalBookNum / BooksPerPage);
	}
}

