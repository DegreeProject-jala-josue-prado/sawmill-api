using yume_api.src.repository.entities;

namespace yume_api.src.repository.repositories.interfaces
{
    public interface IWoodSummaryRepository : IBaseRepository<WoodSummary>
    {
        Task<IList<WoodSummary>> GetAllAsync();
        Task<IList<WoodSummary>> GetByMonthAndCategoryAsync(string month, string category);
    }
}
