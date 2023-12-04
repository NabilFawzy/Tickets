
using Domain.Entities;
using Tickets.Repository.Interfaces;
using Tickets.Service.Interfaces;

namespace Tickets.Service
{
    public class TicketsService : ITicketsService
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketsService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task CreateTicketAsync(TicketEntity ticketEntity)
        {
            await _ticketRepository.CreateTicketAsync(ticketEntity);
        }

        public async Task<IReadOnlyList<TicketEntity>> GetTicketsAsync(int take, int skip)
        {
            return await _ticketRepository.GetTicketsAsync( take,  skip);
        }
    }
}
