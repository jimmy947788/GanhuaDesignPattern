using Ganhua.EventTickets.DataContract;
using Ganhua.EventTickets.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganhua.EventTickets.Service
{
    public static class TicketReservationExtensionMethods
    {
        public static ReserveTicketResponse ConvertToReserveTicketResponse(this TicketReservation ticketReservation)
        {
            ReserveTicketResponse response = new ReserveTicketResponse();

            response.EventId = ticketReservation.Event.Id.ToString();
            response.EventName = ticketReservation.Event.Name;
            response.NoOfTickets = ticketReservation.TicketQuantity;
            response.ExpirationDate = ticketReservation.ExpiryTime;
            response.ReservationNumber = ticketReservation.Id.ToString();

            return response;
        }
    }
}
