namespace TicketFlow.Api.DTOs;

public record SeatDto(int Id, string Section, string SeatNumber, bool IsBooked);