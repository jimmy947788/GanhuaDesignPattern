using Ganhua.Library.Model;
using Ganhua.Library.Services.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganhua.Library.Services.Mappers
{
    public static class BookExtensionMethods
    {
        public static BookView ConvertToBookView(this Book book)
        {
            return new BookView
            {
                Id = book.Id.ToString(),
                ISBN = book.Title.ISBN,
                Title = book.Title.Title,
                OnLoanTo = FormatMemberNameFrom(book.OnLoanTo)
            };
        }

        private static string FormatMemberNameFrom(Member member)
        {
            if (member != null)
                return String.Format("{0} {1}", member.FirstName, member.LastName);
            else
                return "";
        }

        public static IList<BookView> ConvertToBookViews(this IEnumerable<Book> books)
        {
            IList<BookView> bookViews = new List<BookView>();
            foreach (Book book in books)
            {
                bookViews.Add(book.ConvertToBookView());
            }

            return bookViews;
        }
    }
}
