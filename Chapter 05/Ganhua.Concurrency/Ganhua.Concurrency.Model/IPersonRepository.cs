using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganhua.Concurrency.Model
{
    public interface IPersonRepository
    {
        void Add(Person person);
        void Save(Person person);
        Person FindBy(Guid Id);
    }
}
