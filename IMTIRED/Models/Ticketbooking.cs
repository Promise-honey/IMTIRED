using IMTIRED.Models;

public partial class Ticketbooking
{
    public int TicketbookingId { get; set; }
    public int CustomerId { get; set; }
    public DateOnly Date { get; set; } // Date for the zoo visit
    public DateTime DateBooked { get; set; } // Date when the booking was made

    // Add CustomerName and BookingDate
    public string CustomerName { get; set; } // Store customer name
    public DateTime BookingDate { get; set; } // Store the date when the booking was made

    // Add ticket count properties
    public int AdultTickets { get; set; }
    public int ChildTickets { get; set; }
    public int StudentTickets { get; set; }
    public int Toddler1and2Tickets { get; set; }

    public virtual Customer Customer { get; set; } = null!;
}


namespace IMTIRED.Models
{
    public class TicketBookingRequest
    {
        public string TicketType { get; set; }
        public int NumberOfTickets { get; set; }
        public DateTime VisitDate { get; set; }
    }
}
