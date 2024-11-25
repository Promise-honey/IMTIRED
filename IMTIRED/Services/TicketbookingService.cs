using IMTIRED.Models;
using Microsoft.EntityFrameworkCore;

namespace IMTIRED.Services
{
    public class TicketbookingService
    {
        private readonly TlS2302374webContext _context;
        public TicketbookingService(TlS2302374webContext context)
        {
            _context = context;
        }
        public async Task<List<Ticketbooking>> GetTicketbookingsAsync()
        {
            return await _context.Ticketbookings.ToListAsync();
        }
        public async Task AddTicketbookingAsync(Ticketbooking newTicketbooking)
        {
            await _context.Ticketbookings.AddAsync(newTicketbooking);
            await _context.SaveChangesAsync();
        }

    }
}