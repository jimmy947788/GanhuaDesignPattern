using Ganhua.Library.Infrastructure.UnitofWork;
using Ganhua.Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganhua.Library.Repository.NHibernate.Repositories
{
    public class MemberRepository : Repository<Member, Guid>, IMemberRepository
    {
        public MemberRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        { }
    }
}
