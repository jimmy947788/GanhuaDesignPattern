using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganhua.DesignPattern.Model
{
    public interface IDiscountStrategy
    {
        decimal ApplyExtraDiscountsTo(decimal OriginalSalePrice);
    }
}
