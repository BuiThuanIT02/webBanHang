using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Sach.Models.EF
{
    public class CartItem
    {
        public Sach sach { get; set; }
        public int Quantity { get; set; }

    }
}