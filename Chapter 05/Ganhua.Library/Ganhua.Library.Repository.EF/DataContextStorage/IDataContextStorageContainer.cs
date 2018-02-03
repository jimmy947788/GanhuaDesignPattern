using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganhua.Library.Repository.EF.DataContextStorage
{
    public interface IDataContextStorageContainer
    {
        LibraryDataContext GetDataContext();
        void Store(LibraryDataContext libraryDataContext);
    }
}
