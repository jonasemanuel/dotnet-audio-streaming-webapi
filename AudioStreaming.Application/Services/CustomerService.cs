using AudioStreaming.Domain;
using AudioStreaming.Infrastructure;

namespace AudioStreaming.Application;

public class CustomerService
{
    private readonly CustomerRepository _customerRepository;
    private readonly PlanRepository _planRepository;

    public CustomerService(CustomerRepository customerRepository, PlanRepository planRepository)
    {
        _customerRepository = customerRepository;
        _planRepository = planRepository;
    }
}
