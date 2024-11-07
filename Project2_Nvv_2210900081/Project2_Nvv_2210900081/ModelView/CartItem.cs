using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project2_Nvv_2210900081.ModelView
{
    public class CartItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Qty { get; set; }
        public float Price { get; set; }
        public float Total { get; set; } 
    }
}