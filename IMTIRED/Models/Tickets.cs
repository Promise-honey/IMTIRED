namespace IMTIRED.Models
{
    public partial class Ticket
    {
        public int TicketId { get; set; }
        public int? AttractionId { get; set; }
        public int? TicketbookingId { get; set; }
        public decimal? Price { get; set; }
        public string TicketType { get; set; }

        // Add the ItemName property for consistency with your code
        public string ItemName { get; set; }  // This will be the ticket's name or description

        // Add the Quantity property to track the number of tickets
        public int Quantity { get; set; }  // This will hold the number of tickets selected
    }
}

    public class TicketModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; } = 0;
    }

