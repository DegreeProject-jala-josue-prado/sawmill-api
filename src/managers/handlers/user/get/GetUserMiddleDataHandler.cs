using MediatR;
using yume_api.src.repository.entities;
using yume_api.src.repository.repositories.interfaces;

namespace yume_api.src.managers.hadlers.user.get
{
    public class GetUserMiddleDataHandler : IRequestHandler<GetUserMiddleData, User>
    {
        private readonly IUserRepository _repository;
        public GetUserMiddleDataHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<User> Handle(GetUserMiddleData request, CancellationToken cancellationToken)
        {
            return await _repository.GetByEmail(request.Email);
        }
    }
}