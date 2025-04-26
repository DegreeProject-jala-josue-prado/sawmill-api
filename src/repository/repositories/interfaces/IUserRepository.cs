using yume_api.src.repository.entities;

namespace yume_api.src.repository.repositories.interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<int> Login(string email, string password);
        Task<User> GetByEmail(string email);
    }
}
