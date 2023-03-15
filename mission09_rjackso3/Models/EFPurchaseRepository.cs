using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace mission09_rjackso3.Models
{
	public class EFPurchaseRepository : IPurchaseRepository
	{
        private BookstoreContext context;
        public EFPurchaseRepository(BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<Purchase> Purchases => context.Purchases.Include(x => x.Lines).ThenInclude(x => x.book);

        public void SavePurchase(Purchase purchase)
        {
            context.AttachRange(purchase.Lines.Select(x => x.book));

            //Adds the purchase to the DB if it doesn't exist
            if (purchase.PurchaseID == 0)
            {
                context.Purchases.Add(purchase);
            }
            context.SaveChanges();
        }
    }
}

