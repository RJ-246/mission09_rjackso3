using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mission09_rjackso3.Models;
using mission09_rjackso3.Models.ViewModels;
//using mission09_rjackso3.Models;

namespace mission09_rjackso3.Controllers
{
    public class HomeController : Controller
    {
        
        public HomeController(IBookRepository temp) => repo = temp;
        private IBookRepository repo;

        public IActionResult Index(string category, int pageNum = 1)
        {
            int pageSize = 10;
            var data = new BooksViewModel
            {
                Books = repo.Books
                .Where(b => b.Category == category || category == null)
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),
                PageInfo = new PageInfo
                {
                    TotalBookNum = (category == null ? repo.Books.Count() : repo.Books.Where(b=> b.Category == category).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(data);
        }

    }
}

