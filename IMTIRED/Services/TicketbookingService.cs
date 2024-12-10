using IMTIRED.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMTIRED.Services
{
    public class TicketbookingService
    {
        private readonly TlS2302374webContext _context;
        private static List<TicketModel> _basket = new List<TicketModel>(); // Static to retain state

        public TicketbookingService(TlS2302374webContext context)
        {
            _context = context;
        }

        // Method to add tickets to the basket
        public void AddTicketsToBasket(List<TicketModel> tickets, DateTime visitDate)
        {
            _basket.Clear(); // Optionally, clear the basket before adding (you can modify based on your need)
            foreach (var ticket in tickets)
            {
                if (ticket.Quantity > 0)
                {
                    _basket.Add(ticket); // Add tickets to the basket
                }
            }
        }

        // Method to calculate the total cost of the tickets in the basket
        public decimal CalculateTotalCost()
        {
            return _basket.Sum(t => t.Quantity * t.Price); // Sum based on quantity and price
        }

        // Mock payment method
        public void ProcessPayment(decimal totalCost)
        {
            Console.WriteLine($"Payment processed: {totalCost:C}"); // Here you'd integrate with a real payment gateway
        }

        // Method to get the contents of the basket
        public List<TicketModel> GetBasketContents()
        {
            return _basket;
        }

        // Optional: Clear the basket after payment
        public void ClearBasket()
        {
            _basket.Clear();
        }

        // Method to create a booking (this is the missing method you need)
        public async Task<bool> CreateBooking(TicketBookingRequest request)
        {
            try
            {
                // Simulate booking logic
                await Task.Delay(500); // Simulate a delay (e.g., calling an API or saving data)

                // Add business logic to store the booking in your database or process it as needed

                return true; // Return true if the booking is successful
            }
            catch (Exception)
            {
                // Handle any errors during booking
                return false;
            }
        }
    }
}
