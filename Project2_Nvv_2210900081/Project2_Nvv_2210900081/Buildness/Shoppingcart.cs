using Project2_Nvv_2210900081.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project2_Nvv_2210900081.Buildness
{
    public class Shoppingcart
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public void AddToCart( CartItem item)
        {
            var existingitem = Items.FirstOrDefault(i => i.Id == item.Id);
            if (existingitem == null)
            {
                existingitem.Qty += item.Qty;
            }
            else
            {
                Items.Add(item);
            }
        }

        public void UpdateToCart(int id, int qty)
        {
            var existingitem = Items.FirstOrDefault(i => i.Id == id);
            if (existingitem != null)
            {
                existingitem.Qty = qty;
            }
        }
        public void RemoveItemCart(int productId)
        {
            var itemToRemove = Items.FirstOrDefault(i =>i.Id == productId);
            if (itemToRemove != null)
            {
                Items.Remove(itemToRemove);
            }
        }

        public float GetTotalPrice()
        {
            return Items.Sum(i => i.Price * i.Qty);
        }
    }
}