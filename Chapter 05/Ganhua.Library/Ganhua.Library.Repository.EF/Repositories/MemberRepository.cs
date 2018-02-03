using Ganhua.Library.Infrastructure.UnitofWork;
using Ganhua.Library.Model;
using Ganhua.Library.Repository.EF.QueryTranslators;
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganhua.Library.Repository.EF.Repositories
{
    public class MemberRepository : Repository<Member, Guid>, IMemberRepository
    {
        public MemberRepository(IUnitOfWork uow) : base(uow)
        { }

        public override Member FindBy(Guid Id)
        {
            return GetObjectSet().FirstOrDefault<Member>(m => m.Id == Id);
        }

        public override IQueryable<Member> GetObjectSet()
        {
            return DataContextFactory.GetDataContext().CreateObjectSet<Member>();
        }

        public override string GetEntitySetName()
        {
            return "Members";
        }

        public override ObjectQuery<Member> TranslateIntoObjectQueryFrom(Infrastructure.Query.Query query)
        {
            return new MemberQueryTranslator().Translate(query);
        }
    }
}
