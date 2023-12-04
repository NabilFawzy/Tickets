using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Tickets.Repository;
using Tickets.Repository.Data;
using Tickets.Repository.Interfaces;
using Tickets.Service;
using Tickets.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TicketsContext>(opt => {
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<ITicketsService, TicketsService>();
builder.Services.AddCors(options =>

{

    options.AddPolicy(

        name: "AllowOrigin",

        builder =>
        {

            builder.AllowAnyOrigin()

                            .AllowAnyMethod()

                            .AllowAnyHeader() ;

        });

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowOrigin");
app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<TicketsContext>();
var logger = services.GetRequiredService<ILogger<Program>>();


try
{
    await context.Database.MigrateAsync();
    await DataSeedContext.SeedDataAsync(context);
}
catch (Exception ex)
{
    logger.LogError(ex, "An error occured during migration");
}


app.Run();
