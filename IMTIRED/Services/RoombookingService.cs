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
            Roombooking newRoombooking = new Roombooking();
            newRoombooking.Customer = customer;
            newRoombooking.Room = room;
            newRoombooking.StartDate = startDate;
            newRoombooking.EndDate = startDate.AddDays(duration);
            newRoombooking.BookingStatus = "Pending";  // Example: Default BookingStatus if not provided
            newRoombooking.TotalPrice = 0.0m; // Example: Set a default TotalPrice if needed

            var temp = await _context.Roombookings.Where(r => r.CustomerId == customer.CustomerId &&
                                                                 r.RoomId == room.RoomId &&
                                                                 r.StartDate == newRoombooking.StartDate).FirstOrDefaultAsync();
            if (temp == null)
            {
                await _context.Roombookings.AddAsync(newRoombooking);
                await _context.SaveChangesAsync();
            }
            else
            {
                Console.WriteLine("Could not book room");
            }
        }

        public async Task<List<Roombooking>> GetRoombookingsFromCustomer(Customer customer)
        {
            return await _context.Roombookings.Where(rb => rb.CustomerId == customer.CustomerId).ToListAsync();
        }

        public async Task<List<Roombooking>> GetRoombookingsFromCustomer(int id)
        {
            return await _context.Roombookings.Where(rb => rb.CustomerId == id).ToListAsync();
        }

        public async Task DeleteBooking(Roombooking roombooking)
        {
            _context.Roombookings.Remove(roombooking);
            await _context.SaveChangesAsync();
        }

        // Method to fetch a room by its RoomNumber
        public async Task<Room?> GetRoomByNumber(string roomNumber)
        {
            return await _context.Rooms
                                 .FirstOrDefaultAsync(r => r.RoomNumber == roomNumber);
        }
    }
}

