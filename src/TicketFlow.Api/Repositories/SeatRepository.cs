using Microsoft.EntityFrameworkCore;
using TicketFlow.Api.Models;
using TicketFlow.Api.Repositories;
using TicketFlow.Api.Services;

public class SeatRepository : ISeatRepository
{

    private readonly AppDbContext _context;

    public SeatRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Seat>> GetAllAsync()
    {
        return await _context.Seats.OrderBy(s => s.SeatNumber).ToListAsync();
    }

    public async Task<Seat?> GetByIdAsync(int id)
    {
        return await _context.Seats.FindAsync(id);
    }

    public async Task UpdateAsync(Seat seat)
    {
        _context.Seats.Update(seat);
        await _context.SaveChangesAsync();
    }
}