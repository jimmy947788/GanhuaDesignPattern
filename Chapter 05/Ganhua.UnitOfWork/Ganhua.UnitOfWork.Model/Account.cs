using Ganhua.UnitOfWork.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganhua.UnitOfWork.Model
{
    public class Account : IAggregateRoot
    {
        public decimal Balance{ get; set; }
    }
}
