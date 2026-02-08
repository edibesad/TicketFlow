namespace TicketFlow.Api.Models;

public class Seat
{

    public int Id { get; set; }
    public string Section { get; set; } = String.Empty;
    public String SeatNumber { get; set; } = String.Empty;
    public bool IsBooked { get; set; }
    public DateTime? BookedAt { get; set; }
}