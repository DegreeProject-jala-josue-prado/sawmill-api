using MediatR;
using yume_api.src.repository.entities;

namespace yume_api.src.managers.hadlers.user.get
{
    public class GetUserMiddleData : IRequest<User>
    {
        public string Email { get; set; } = "";
        public GetUserMiddleData(string email)
        {
            Email = email;
        }

    }
}
