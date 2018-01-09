using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganhua.EventTickets.Service
{
    public class ErrorLog
    {
        public static string GenerateErrorRefMessageAndLog(Exception exception)
        {
            // Here we would log the error and the unique reference id
            return String.Format("If you wish to contact us please quote reference '{0}'", Guid.NewGuid().ToString());
        }
    }
}
