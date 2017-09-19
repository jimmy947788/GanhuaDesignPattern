using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganhua.DesignPattern.DTO
{
    public class BookedLeave
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int DaysTaken { get; set; }
    }
}
