using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganhua.IdentityMap.Model
{
    public interface IEmployeeRepository
    {
        Employee FindBy(Guid Id);
    }
}
