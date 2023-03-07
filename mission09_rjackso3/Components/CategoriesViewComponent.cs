using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using mission09_rjackso3.Models;

namespace mission09_rjackso3.Components
{
	public class CategoriesViewComponent : ViewComponent
	{
		//creates a new repo
		private IBookRepository repo { get; set; }

		public CategoriesViewComponent(IBookRepository temp)
		{
			repo = temp;
		}

		public IViewComponentResult Invoke()
		{
			// Adds the filtered category to the viewbag so we can use it to highlight the button on the page
            ViewBag.SelectedCategory = RouteData?.Values["Category"];

			var categories = repo.Books
				.Select(b => b.Category)
				.Distinct()
				.OrderBy(b => b);

			return View(categories);
        }
	}
}

