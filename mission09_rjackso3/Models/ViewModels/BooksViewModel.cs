﻿using System;
using System.Linq;
namespace mission09_rjackso3.Models.ViewModels
{
	public class BooksViewModel
	{
		public IQueryable<Book> Books { get; set; }
		public PageInfo PageInfo { get; set; }
		public Basket Basket { get; set; }
	}
}

