using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using mission09_rjackso3.Infrastructure;
using mission09_rjackso3.Models;

namespace mission09_rjackso3.Pages
{
	public class ShoppingCartModel : PageModel
    {
        //Create a new repo for getting book data
        private IBookRepository repo { get; set; }
        public ShoppingCartModel(IBookRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }

        //set up basket and return url
        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }


        public void OnGet(string returnUrl)
        {
            //Adds a new basket if one doesn't currently exist in the session (not needed with session basket
            //basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(int bookID, string returnUrl)
        {
            //Gets the book from the submitted form
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookID);

            //Creates a new basket if one doesn't exist in the session (not needed with session basket)
            //basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();

            //adds the book to the basket
            basket.AddItem(b, 1);

            
            //sets the newly updated basket to the session (not needed with session basket)
            //HttpContext.Session.SetJson("basket", basket);

            //returns the page
            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(int bookID, string returnUrl)
        {
            basket.RemoveItem(basket.Items.First(x => x.book.BookId == bookID).book);
            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
