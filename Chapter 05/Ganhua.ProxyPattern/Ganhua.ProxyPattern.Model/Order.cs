using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganhua.ProxyPattern.Model
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
