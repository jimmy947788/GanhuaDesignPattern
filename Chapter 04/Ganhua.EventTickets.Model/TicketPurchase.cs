using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganhua.EventTickets.Model
{
    public class TicketPurchase
    {
        public Guid Id { get; set; }
        public Event Event { get; set; }
        public int TicketQuantity { get; set; }
    }
}
