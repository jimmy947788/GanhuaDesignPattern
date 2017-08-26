using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ganhua.DesignPattern.AppService
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string RRP { get; set; }
        public string SellingPrice { get; set; }
        public string Discount { get; set; }
        public string Savings { get; set; }
    }
}