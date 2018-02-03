using Ganhua.Library.Services.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganhua.Library.Services.Messages
{
    public class FindMembersResponse : ResponseBase
    {
        public IEnumerable<MemberView> MembersFound { get; set; }
    }
}
