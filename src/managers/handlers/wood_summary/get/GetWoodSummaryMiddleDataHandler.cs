using MediatR;
using yume_api.src.repository.entities;
using yume_api.src.repository.repositories.interfaces;

namespace yume_api.src.managers.hadlers.user.get
{
    public class GetWoodSummaryMiddleDataHandler : IRequestHandler<GetWoodSummaryMiddleData, WoodSummary>
    {
        private readonly IWoodSummaryRepository _repository;
        public GetWoodSummaryMiddleDataHandler(IWoodSummaryRepository repository)
        {
            _repository = repository;
        }

        public async Task<WoodSummary> Handle(GetWoodSummaryMiddleData request, CancellationToken cancellationToken)
        {
            return await _repository.GetById(request.Id);
        }
    }
}