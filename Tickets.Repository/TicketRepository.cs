
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.Repository.Data;
using Tickets.Repository.Interfaces;

namespace Tickets.Repository
{
    public class TicketRepository : ITicketRepository
    {
        private readonly TicketsContext _ticketsContext;

        public TicketRepository(TicketsContext ticketsContext)
        {
            _ticketsContext = ticketsContext;
        }

        public async Task CreateTicketAsync(TicketEntity ticketEntity)
        {
            await _ticketsContext.Tickets.AddAsync(ticketEntity);

            await _ticketsContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<TicketEntity>> GetTicketsAsync(int take,int skip)
        {
           var tickets= await _ticketsContext.Tickets.ToListAsync();

            return tickets.Skip(skip).Take(take).ToList();
        }
    }
}
