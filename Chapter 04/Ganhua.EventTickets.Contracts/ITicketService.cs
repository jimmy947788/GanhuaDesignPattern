using Ganhua.EventTickets.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Ganhua.EventTickets.Contracts
{
    [ServiceContract(Namespace = "http://Ganhua.EventTickets/")]
    public interface ITicketService
    {
        [OperationContract()]
        ReserveTicketResponse ReserveTicket(ReserveTicketRequest reserveTicketRequest);

        [OperationContract()]
        PurchaseTicketResponse PurchaseTicket(PurchaseTicketRequest purchaseTicketRequest);
    }
}
