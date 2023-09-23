using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Sach.Models.EF
{
    public class OrderDetail
    {
        public int sachId { get; set; }

        public string sachName{get;set;}
        public double PriceBuy { get; set; }
        public int Sale { get; set; }
        public int QuantityBuy { get; set; }
     
    }
}