using System;
using System.Linq;

namespace mission09_rjackso3.Models
{
	public interface IPurchaseRepository
	{
		IQueryable<Purchase> Purchases { get; }
		void SavePurchase(Purchase purchase);
	}
}

