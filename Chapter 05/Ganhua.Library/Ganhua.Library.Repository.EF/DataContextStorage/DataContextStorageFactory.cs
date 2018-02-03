using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;

namespace Ganhua.Library.Repository.EF.DataContextStorage
{
    public class DataContextStorageFactory
    {
        public static IDataContextStorageContainer _dataContectStorageContainer;

        public static IDataContextStorageContainer CreateStorageContainer()
        {
            if (_dataContectStorageContainer == null)
            {
                if (HttpContext.Current == null)
                    _dataContectStorageContainer = new ThreadDataContextStorageContainer();
                else
                    _dataContectStorageContainer = new HttpDataContextStorageContainer();
            }

            return _dataContectStorageContainer;
        }
    }
}
