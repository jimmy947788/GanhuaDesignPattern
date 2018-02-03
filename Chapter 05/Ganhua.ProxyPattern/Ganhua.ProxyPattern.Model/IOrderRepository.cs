using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganhua.ProxyPattern.Model
{
    public interface IOrderRepository
    {
        IEnumerable<Order> FindAllBy(Guid customerId);
    }
}
