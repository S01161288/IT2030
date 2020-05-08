using MVCMusicStoreApplication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCMusicStoreApplication.Models
{
    public class ShoppingCart
    {
        MVCMusicStoreDB db = new MVCMusicStoreDB();
        public string ShoppingCartId;
        public static ShoppingCart GetCart(HttpContextBase context)
        {
            ShoppingCart cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCardId(context);
            return cart;
        }

        private string GetCardId(HttpContextBase context)
        {
            const string CartSessionId = "CartId";
            string cartId;

            if (context.Session[CartSessionId] == null)
            {
                //Create a new cart id
                cartId = Guid.NewGuid().ToString();

                //Save to the session date.
                context.Session[CartSessionId] = cartId;
            }
            else
            {
                //Return the existing cart id
                cartId = context.Session[CartSessionId].ToString();
            }

            return cartId;
        }

        public List<Cart> GetCartItems()
        {
            return db.Carts.Where(c => c.CartId == this.ShoppingCartId).ToList();
        }

        public decimal GetCartTotal()
        {
            decimal? total = (from cartItem in db.Carts
                              where cartItem.CartId == this.ShoppingCartId
                              select cartItem.AlbumSelected.Price * (int?)cartItem.Count).Sum();
            return total ?? decimal.Zero;
        }

        public void AddToCart(int albumId)
        {
            Cart cartItem = db.Carts.SingleOrDefault(c => c.CartId == this.ShoppingCartId && c.AlbumId == albumId);
            if (cartItem == null)
            {
                //Item is not cart; add new cart item
                cartItem = new Cart()
                {
                    CartId = this.ShoppingCartId,
                    AlbumId = albumId,
                    Count = 1,
                    DateCreated = DateTime.Now
                };
                db.Carts.Add(cartItem);
            }
            else
            {
                //Item is already; increaes item count (quantity)
                cartItem.Count++;
            }

            db.SaveChanges();
        }

        public int RemoveFromCart(int recordId)
        {
            Cart cartItem = db.Carts.SingleOrDefault(c => c.CartId == this.ShoppingCartId && c.RecordId == recordId);
            if (cartItem == null)
            {
                throw new NullReferenceException();
            }

            int newCount;

            if (cartItem.Count > 1)
            {
                //The count > 1; decrement count
                cartItem.Count--;
                newCount = cartItem.Count;
            }
            else
            {
                //The count <=0; remove cart item
                db.Carts.Remove(cartItem);
                newCount = 0;
            }

            db.SaveChanges();

            return newCount;
        }
    }


}