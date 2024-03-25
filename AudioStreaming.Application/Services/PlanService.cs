using AudioStreaming.Domain;
using AudioStreaming.Infrastructure;

namespace AudioStreaming.Application;

public class PlanService
{
    private readonly PlanRepository _planRepository;

    public PlanService(PlanRepository planRepository)
    {
        _planRepository = planRepository;
    }

    public IEnumerable<ResponsePlanDTO> GetAll()
    {
        return _planRepository.GetAll().Select(plan => new ResponsePlanDTO{
            Id = plan.Id.ToString(),
            Name = plan.Name,
            Price = plan.Price
        }).ToList();
    }

    public void Create(RequestPlanDTO request)
    {
        Plan plan = new Plan(request.Name, request.Price);
        _planRepository.Add(plan);
    }
}
