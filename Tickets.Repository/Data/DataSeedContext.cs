using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Tickets.Repository.Data
{
    public class DataSeedContext
    {
        public static async Task SeedDataAsync(TicketsContext context)
        {
            if (!context.Tickets.Any())
            {
                var ticketsData = CreateTickets();

                context.Tickets.AddRange(ticketsData);
            }
            if (context.ChangeTracker.HasChanges())
                await context.SaveChangesAsync();
        }
        public static List<TicketEntity> CreateTickets()
        {
            List<TicketEntity> tickets = new List<TicketEntity>();
            for(int i=1;i<=50;i++)
            {
                var ticket= new TicketEntity()
                {
                        PhoneNumber="01234567890",
                        City="Shoubra",
                        Governorate="Cairo",
                        District="First",
                        CreationDate= GetDataTime(),
                };
                tickets.Add(ticket);
            }
            return tickets;
        }

        public static DateTime GetDataTime()
        {
            Random rnd = new Random();
            int option= rnd.Next(1,5);


          
            if(option == 1) //time before 15 minutes
            {
                return DateTime.Now.AddMinutes(15);
            }
            else if(option == 2) //time before 30 minutes
            {
                return DateTime.Now.AddMinutes(30);
            }
            else if (option == 3) //time before 45 minutes
            {
                return DateTime.Now.AddMinutes(45);
            }
            else if (option == 4) //time before 60 minutes
            {
                return DateTime.Now.AddMinutes(60);
            }
            else
            {
                return DateTime.Now.AddHours(2);
            }
        }

    }
}
