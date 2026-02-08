using TicketFlow.Api.Models;

namespace TicketFlow.Api.Repositories;

public interface ISeatRepository
{
    Task<IEnumerable<Seat>> GetAllAsync();
    Task<Seat?> GetByIdAsync(int id);
    Task UpdateAsync(Seat seat);
}