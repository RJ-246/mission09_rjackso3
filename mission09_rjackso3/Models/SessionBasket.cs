using System;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using mission09_rjackso3.Infrastructure;

namespace mission09_rjackso3.Models
{
	public class SessionBasket : Basket
	{
		public static Basket GetBasket(IServiceProvider services)
		{
			ISession session = services.GetRequiredService<IHttpContextAccessor>().HttpContext.Session;

			SessionBasket sessionBasket = session?.GetJson<SessionBasket>("Basket") ?? new SessionBasket();

			sessionBasket.session = session;

			return sessionBasket;
		}

        [JsonIgnore]
		public ISession session { get; set; }

        public override void AddItem(Book bo, int qty)
        {
            base.AddItem(bo, qty);
            session.SetJson("Basket", this);
        }

        public override void RemoveItem(Book book)
        {
            base.RemoveItem(book);
            session.SetJson("Basket", this);
        }

        public override void ClearBasket()
        {
            base.ClearBasket();
            session.Remove("Basket");
        }
    }
}

