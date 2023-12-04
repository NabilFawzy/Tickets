using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.Repository.Interfaces
{
    public interface ITicketRepository
    {
        Task<IReadOnlyList<TicketEntity>> GetTicketsAsync(int take, int skip);
        Task CreateTicketAsync(TicketEntity ticketEntity);

    }
}
