using MediatR;
using yume_api.src.repository.entities;

namespace yume_api.src.managers.hadlers.user.get
{
    public class GetWoodSummaryMiddleData : IRequest<WoodSummary>
    {
        public Guid Id { get; set; }
        public GetWoodSummaryMiddleData(Guid id)
        {
            Id = id;
        }

    }
}
