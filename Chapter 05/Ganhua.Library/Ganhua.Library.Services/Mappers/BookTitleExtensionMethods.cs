using Ganhua.Library.Model;
using Ganhua.Library.Services.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganhua.Library.Services.Mappers
{
    public static class BookTitleExtensionMethods
    {
        public static BookTitleView ConvertToBookTitleView(this BookTitle bookTitle)
        {
            return new BookTitleView
            {
                ISBN = bookTitle.ISBN,
                Title = bookTitle.Title
            };
        }

        public static IList<BookTitleView> ConvertToBookTitleViews(this IEnumerable<BookTitle> bookTitles)
        {
            IList<BookTitleView> bookViews = new List<BookTitleView>();
            foreach (BookTitle bookTitle in bookTitles)
            {
                bookViews.Add(bookTitle.ConvertToBookTitleView());
            }

            return bookViews;
        }
    }
}
