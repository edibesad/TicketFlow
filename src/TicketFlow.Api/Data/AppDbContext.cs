using Microsoft.EntityFrameworkCore;
using TicketFlow.Api.Models;

namespace TicketFlow.Api.Services;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Seat> Seats
    {
        get; set;

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var seats = new List<Seat>();
        for (int i = 1; i <= 100; i++)
        {
            seats.Add(new Seat { Id = i, Section = "A", SeatNumber = $"A{i}", IsBooked = false });
        }

        modelBuilder.Entity<Seat>().HasData(seats);
    }

}