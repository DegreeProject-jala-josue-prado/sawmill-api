using Microsoft.EntityFrameworkCore;
using yume_api.src.repository.entities;
using yume_api.src.repository.repositories.interfaces;

namespace yume_api.src.repository.repositories.concrets
{
    public class WoodSummaryRepository : BaseRepository<WoodSummary>, IWoodSummaryRepository
    {
        public WoodSummaryRepository(BaseContext context) : base(context)
        { }

        public async Task<IList<WoodSummary>> GetAllAsync()
        {
            return await _context.Set<WoodSummary>().ToListAsync();
        }

        public async Task<IList<WoodSummary>> GetByMonthAndCategoryAsync(string month, string category)
        {
            return await _context.Set<WoodSummary>()
                .Where(w => w.Month == month && w.Category == category)
                .ToListAsync();
        }

    }
}