using IMTIRED.Models;
using Microsoft.EntityFrameworkCore;

namespace IMTIRED.Services
{
    public class TicketService
    {
        private readonly TlS2302374webContext _context;
        public TicketService(TlS2302374webContext context)
        {
            _context = context;
        }
        public async Task<List<Ticket>> GetTicketsAsync()
        {
            return await _context.Tickets.ToListAsync();
        }
        public async Task AddTicketAsync(Ticket newTicket)
        {
            await _context.Tickets.AddAsync(newTicket);
            await _context.SaveChangesAsync();
        }
    }
}
