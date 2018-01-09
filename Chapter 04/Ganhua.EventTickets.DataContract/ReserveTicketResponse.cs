using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Ganhua.EventTickets.DataContract
{
    [DataContract]
    public class ReserveTicketResponse : Response
    {
        [DataMember]
        public string ReservationNumber { get; set; }

        [DataMember]
        public DateTime ExpirationDate { get; set; }

        [DataMember]
        public String EventName { get; set; }

        [DataMember]
        public String EventId { get; set; }

        [DataMember]
        public int NoOfTickets { get; set; }
    }
}
