using System;
using System.Collections.Generic;
using System.Linq;
using eCommerce.Model;

namespace eCommerce.WebUI.Models.Shopping
{
    public class Cart
    {
        private List<CartItem> _cartItems = new List<CartItem>();

        public void AddItem(FOOD food, int quantity)
        {
            CartItem item = _cartItems.Where(p => p.Food.ID == food.ID).FirstOrDefault();
            if (item == null)
            {
                _cartItems.Add(new CartItem(){Food = food,Quantity = quantity});
            }
            else
            {
                item.Quantity += quantity;
            }
        }

        public void UpdateQuantity(FOOD food,int quantity)
        {
            CartItem item = null;
            foreach (CartItem cartItem in Items)
            {
                if (cartItem.Food.ID == food.ID)
                {
                    item = cartItem;
                    break;
                }
            }
            item.Quantity = quantity;
        }

        public void RemoveItem(FOOD food)
        {
            _cartItems.RemoveAll(p => p.Food.ID == food.ID);
        }

        public Decimal ComputeTotalValue()
        {
            return (decimal)_cartItems.Sum(p => p.Food.Price*p.Quantity);
        }

        public void Clear()
        {
            _cartItems.Clear();
        }

        public IEnumerable<CartItem> Items
        {
            get { return _cartItems; }
        } 
    }
}
