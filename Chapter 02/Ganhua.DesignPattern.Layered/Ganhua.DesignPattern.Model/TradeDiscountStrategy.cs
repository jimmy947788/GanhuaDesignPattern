using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganhua.DesignPattern.Model
{
    public class TradeDiscountStrategy : IDiscountStrategy
    {
        public decimal ApplyExtraDiscountsTo(decimal OriginalSalePrice)
        {
            decimal price = OriginalSalePrice;

            price = price * 0.95M;

            return price;
        }
    }
}
