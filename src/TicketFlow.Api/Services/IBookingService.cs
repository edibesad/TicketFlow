using TicketFlow.Api.DTOs;

namespace TicketFlow.Api.Services;

public interface IBookingService
{
    Task<IEnumerable<SeatDto>> GetSeatsAsync();
    Task<BookingResult> BookSeatAsync(int seatId);
}

public record BookingResult(bool Success, string Message);