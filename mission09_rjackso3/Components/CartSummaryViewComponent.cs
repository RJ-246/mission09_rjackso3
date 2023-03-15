using System;
using Microsoft.AspNetCore.Mvc;
using mission09_rjackso3.Models;
namespace mission09_rjackso3.Components

{
	public class CartSummaryViewComponent : ViewComponent
	{
		private Basket basket;
		public CartSummaryViewComponent(Basket b)
		{
			basket = b;
		}

		public IViewComponentResult Invoke()
		{
			return View(basket);
		}
	}
}

