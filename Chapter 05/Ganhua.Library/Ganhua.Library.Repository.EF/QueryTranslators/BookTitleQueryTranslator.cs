using Ganhua.Library.Infrastructure.Query;
using Ganhua.Library.Model;
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganhua.Library.Repository.EF.QueryTranslators
{
    public class BookTitleQueryTranslator : QueryTranslator
    {
        public ObjectQuery<BookTitle> Translate(Query query)
        {
            ObjectQuery<BookTitle> bookTitleQuery;

            if (query.IsNamedQuery())
            {
                bookTitleQuery = FindEFQueryFor(query);
            }
            else
            {
                StringBuilder queryBuilder = new StringBuilder();
                IList<ObjectParameter> paraColl = new List<ObjectParameter>();
                CreateQueryAndObjectParameters(query, queryBuilder, paraColl);

                bookTitleQuery = DataContextFactory.GetDataContext().BookTitles
                  .Where(queryBuilder.ToString(), paraColl.ToArray()).OrderBy(String.Format("it.{0} desc", query.OrderByProperty.PropertyName));

            }

            return bookTitleQuery;
        }

        private ObjectQuery<BookTitle> FindEFQueryFor(Query query)
        {
            // No complex queries have been defined in this sample.
            throw new NotImplementedException();
        }
    }
}
