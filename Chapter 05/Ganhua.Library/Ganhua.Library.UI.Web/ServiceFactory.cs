using Ganhua.Library.Infrastructure.UnitofWork;
using Ganhua.Library.Model;
using Ganhua.Library.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Ganhua.Library.UI.Web
{
    public static class ServiceFactory
    {
        public static LibraryService CreateLibraryService()
        {
            IUnitOfWork uow;
            IBookRepository bookRespository;
            IBookTitleRepository bookTitleRepository;
            IMemberRepository memberRespository;

            string persistenceStrategy = ConfigurationManager.AppSettings["PersistenceStrategy"];

            if (persistenceStrategy == "EF")
            {
                uow = new Repository.EF.EFUnitOfWork();
                bookRespository = new Repository.EF.Repositories.BookRepository(uow);
                bookTitleRepository = new Repository.EF.Repositories.BookTitleRepository(uow);
                memberRespository = new Repository.EF.Repositories.MemberRepository(uow);
            }
            else
            {
                uow = new Repository.NHibernate.NHUnitOfWork();
                bookRespository = new Repository.NHibernate.Repositories.BookRepository(uow);
                bookTitleRepository = new Repository.NHibernate.Repositories.BookTitleRepository(uow);
                memberRespository = new Repository.NHibernate.Repositories.MemberRepository(uow);
            }

            return new LibraryService(bookTitleRepository, bookRespository, memberRespository, uow);
        }
    }
}