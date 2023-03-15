using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace mission09_rjackso3.Models
{
	public class Basket
	{
		public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();
		public virtual void AddItem(Book bo, int qty)
		{
			//Makes a line item with a book object matching the bookID passed to it
			BasketLineItem lineItem = Items
				.Where(b => b.book.BookId == bo.BookId)
				.FirstOrDefault();

			if (lineItem == null)
			{
				//Adds a new basketline item to Items if it doesnt already exist
				Items.Add(new BasketLineItem
				{
					book = bo,
					Quantity = qty
				});
			}
			else
			{
				//adds to quantity if the book already exists in cart
				lineItem.Quantity += qty;
			}
		}

		public virtual void RemoveItem(Book book)
		{
			Items.RemoveAll(x => x.book.BookId == book.BookId);
		}

		public virtual void ClearBasket()
		{
			Items.Clear();
		}

		public double CalculateTotal()
		{
			double sum = (Items.Sum(x => x.Quantity * x.book.Price));
			return sum;
		}
		public int Count()
		{
			int count = Items.Count;
			return count;
		}
	}

	public class BasketLineItem
	{
		[Key]
		public int LineID { get; set; }
		public Book book { get; set; }
		public int Quantity { get; set; }
	}
}

