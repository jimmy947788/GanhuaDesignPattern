using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganhua.ProxyPattern.Model
{
    public interface ICustomerRespository
    {
        Customer FindBy(Guid id);
    }
}
