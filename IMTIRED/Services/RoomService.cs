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
        public async Task<List<Room>> GetRoomsAsync()
        {
            return await _context.Rooms.ToListAsync();
        }
        public async Task<Room> GetRoomAsync(string roomNumber)
        {
            return await _context.Rooms.FirstAsync(r => r.RoomNumber == roomNumber);
        }

    }
}
