using IMTIRED.Models;
using Microsoft.EntityFrameworkCore;

namespace IMTIRED.Services
{
    public class AttractionService
    {
        private readonly TlS2302374webContext _context;
        public AttractionService(TlS2302374webContext context)
        {
            _context = context;
        }
        public async Task<List<Attraction>> GetAttractionsAsync()
        {
            return await _context.Attractions.ToListAsync();
        }
    }
}