using Microsoft.EntityFrameworkCore;
using yume_api.src.repository.entities;
using yume_api.src.repository.repositories.interfaces;

namespace yume_api.src.repository.repositories.concrets
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(BaseContext context) : base(context)
        { }
        public async Task<User> GetByEmail(string email)
        {
            var response = await _context.Set<User>().FirstAsync(entity => entity.Email.Equals(email));

            return response;
        }

        public Task<int> Login(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}