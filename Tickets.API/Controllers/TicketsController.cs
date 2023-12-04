using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tickets.Service.Interfaces;

namespace Tickets.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketsService _ticketsService;

        public TicketsController(ITicketsService ticketsService)
        {
            _ticketsService = ticketsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TicketEntity>>> GetTickets(int take,int skip)
        {
            return Ok(await _ticketsService.GetTicketsAsync(take,skip));
        }
        [HttpPost("create")]
        public async Task CreateTicket(TicketDto ticketDto)
        {
             Ok( _ticketsService.CreateTicketAsync(new TicketEntity()
             {
                 City = ticketDto.City,
                 CreationDate = ticketDto.CreationDate,
                 District = ticketDto.District,
                 Governorate = ticketDto.Governorate,
                 PhoneNumber = ticketDto.PhoneNumber
             })
            );
        }
    }
}
