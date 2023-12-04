namespace Tickets.API
{
    public class TicketDto
    {
        public DateTime CreationDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Governorate { get; set; }
        public string City { get; set; }
        public string District { get; set; }
    }
}
