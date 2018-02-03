using Ganhua.Library.Infrastructure.Query;
using Ganhua.Library.Infrastructure.UnitofWork;
using Ganhua.Library.Model;
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganhua.Library.Repository.EF.Repositories
{
    public class BookTitleRepository : Repository<BookTitle, string>, IBookTitleRepository
    {
        public BookTitleRepository(IUnitOfWork uow)
            : base(uow)
        { }

        public override BookTitle FindBy(string Id)
        {
            return GetObjectSet().FirstOrDefault<BookTitle>(b => b.ISBN == Id);
        }

        public override IQueryable<BookTitle> GetObjectSet()
        {
            return DataContextFactory.GetDataContext().CreateObjectSet<BookTitle>();
        }

        public override string GetEntitySetName()
        {
            return "BookTitles";
        }

        public override ObjectQuery<BookTitle> TranslateIntoObjectQueryFrom(Query query)
        {
            throw new NotImplementedException();
        }
    }
}
