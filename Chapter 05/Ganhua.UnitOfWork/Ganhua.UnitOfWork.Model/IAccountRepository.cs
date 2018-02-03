using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganhua.UnitOfWork.Model
{
    public interface IAccountRepository
    {
        void Save(Account account);
        void Add(Account account);
        void Remove(Account account);
    }
}
