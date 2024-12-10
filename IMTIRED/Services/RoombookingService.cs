using Microsoft.EntityFrameworkCore;
using IMTIRED.Models;

namespace IMTIRED.Services
{
    public class RoombookingService
    {
        private readonly TlS2302374webContext _context;

        public RoombookingService(TlS2302374webContext context)
        {
            _context = context;
        }

        public async Task AddRoombookingAsync(Customer customer, Room room, DateTime startDate, int duration)
        {
            Roombooking newRoombooking = new Roombooking
            {
                Customer = customer,
                Room = room,
                CheckInDate = DateOnly.FromDateTime(startDate),
                CheckOutDate = DateOnly.FromDateTime(startDate.AddDays(duration)),
                BookingStatus = "Pending", // Default status
                TotalPrice = 0.0m // Default price, adjust as needed
            };

            // Check if room is already booked on the selected date
            var existingBooking = await _context.Roombookings
                .Where(r => r.CustomerId == customer.CustomerId &&
                            r.RoomId == room.RoomId &&
                            r.CheckInDate == DateOnly.FromDateTime(startDate))
                .FirstOrDefaultAsync();

            if (existingBooking == null)
            {
                await _context.Roombookings.AddAsync(newRoombooking);
                await _context.SaveChangesAsync();
            }
            else
            {
                // You can choose to handle this scenario as per your business logic
                Console.WriteLine("Room already booked for the selected date.");
            }
        }

        public async Task<List<Roombooking>> GetRoombookingsFromCustomer(Customer customer)
        {
            return await _context.Roombookings
                .Where(rb => rb.CustomerId == customer.CustomerId)
                .ToListAsync();
        }

        // Overload to fetch bookings by customer ID
        public async Task<List<Roombooking>> GetRoombookingsFromCustomer(int customerId)
        {
            return await _context.Roombookings
                .Where(rb => rb.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task DeleteBooking(Roombooking roombooking)
        {
            _context.Roombookings.Remove(roombooking);
            await _context.SaveChangesAsync();
        }

        // Fetch room by number
        public async Task<Room?> GetRoomByNumber(string roomNumber)
        {
            if (int.TryParse(roomNumber, out int parsedRoomNumber))
            {
                return await _context.Rooms
                    .FirstOrDefaultAsync(r => r.RoomNumber == parsedRoomNumber);
            }
            else
            {
                throw new ArgumentException("Invalid room number format. Room number must be a valid integer.");
            }
        }

        // Fetch room by room type (new method to fetch by type)
        public async Task<Room?> GetRoomByType(string roomType)
        {
            return await _context.Rooms
                .FirstOrDefaultAsync(r => r.RoomType.Equals(roomType, StringComparison.OrdinalIgnoreCase));
        }
    }
}
