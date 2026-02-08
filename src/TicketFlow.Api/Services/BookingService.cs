using StackExchange.Redis;
using TicketFlow.Api.DTOs;
using TicketFlow.Api.Repositories;

namespace TicketFlow.Api.Services;

public class BookingService(ISeatRepository repository, IConnectionMultiplexer redis) : IBookingService
{

    private readonly ISeatRepository _repository = repository;
    private readonly IConnectionMultiplexer _redis = redis;

    public async Task<BookingResult> BookSeatAsync(int seatId)
    {
        var redisDb = _redis.GetDatabase();

        string lockKey = $"lock:seat:{seatId}";
        string token = Guid.NewGuid().ToString();

        if (!await redisDb.LockTakeAsync(lockKey, token, TimeSpan.FromSeconds(5)))
        {
            return new BookingResult(false, "System is busy, please try again.");
        }

        try
        {
            var seat = await _repository.GetByIdAsync(seatId);
            if (seat == null)
                return new BookingResult(false, "Seat not found");

            if (seat.IsBooked)
                return new BookingResult(false, "Seat already taken");

            seat.IsBooked = true;
            seat.BookedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(seat);

            return new BookingResult(true, $"Seat {seat.SeatNumber} successfully booked");
        }
        finally
        {
            await redisDb.LockReleaseAsync(lockKey, token);
        }

    }

    public async Task<IEnumerable<SeatDto>> GetSeatsAsync()
    {
        var seats = await _repository.GetAllAsync();
        return seats.Select(s => new SeatDto(s.Id, s.Section, s.SeatNumber, s.IsBooked));
    }

}