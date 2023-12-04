using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.Service.Interfaces
{
    public interface ITicketsService
    {
        Task<IReadOnlyList<TicketEntity>> GetTicketsAsync(int take, int skip);
        Task CreateTicketAsync(TicketEntity ticketEntity);
    }
}
