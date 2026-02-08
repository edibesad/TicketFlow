using Microsoft.AspNetCore.Mvc;
using TicketFlow.Api.Services;

namespace TicketFlow.Api.Conrollers;

[ApiController]
[Route("api/[controller]")]
public class BookingController : ControllerBase
{
    private readonly IBookingService _bookingService;

    public BookingController(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    [HttpGet]
    public async Task<IActionResult> GetSeats()
    {
        var seats = await _bookingService.GetSeatsAsync();
        return Ok(seats);
    }

    [HttpPost("book/{seatId}")]
    public async Task<IActionResult> BookSeat(int seatId)
    {
        var result = await _bookingService.BookSeatAsync(seatId);
        if (!result.Success)
        {
            if (result.Message.Contains("busy")) return Conflict(new { message = result.Message });
        }

        return Ok(new { message = result.Message });
    }

}