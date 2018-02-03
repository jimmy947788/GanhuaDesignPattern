using Ganhua.Library.Infrastructure.UnitofWork;
using Ganhua.Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganhua.Library.Repository.NHibernate.Repositories
{
    public class BookTitleRepository : Repository<BookTitle, string>, IBookTitleRepository
    {
        public BookTitleRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        { }
    }
}
