using Microsoft.EntityFrameworkCore;
using IMTIRED.Models;

namespace IMTIRED.Services
{
    public class RoomService
    {
        private readonly TlS2302374webContext _context;

        public RoomService(TlS2302374webContext context)
        {
            _context = context;
        }

        // Get all rooms asynchronously
        public async Task<List<Room>> GetRoomsAsync()
        {
            return await _context.Rooms.ToListAsync();
        }

        // Get a specific room asynchronously, assuming roomNumber is an integer
        public async Task<Room> GetRoomAsync(string roomNumber)
        {
            // Ensure roomNumber is converted to an integer
            if (int.TryParse(roomNumber, out int roomNumberInt))
            {
                // Query the room with the converted integer roomNumber
                return await _context.Rooms.FirstOrDefaultAsync(r => r.RoomNumber == roomNumberInt);
            }
            else
            {
                // Handle invalid room number input (non-numeric value)
                throw new ArgumentException("Invalid room number format.");
            }
        }
    }
}

