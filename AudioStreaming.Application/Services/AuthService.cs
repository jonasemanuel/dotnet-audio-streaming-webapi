using AudioStreaming.Domain;
using AudioStreaming.Http;
using AudioStreaming.Infrastructure;

namespace AudioStreaming.Application;

public class AuthService
{
    private readonly CustomerRepository _customerRepository;
    private readonly PlanRepository _planRepository;

    public AuthService(CustomerRepository customerRepository, PlanRepository planRepository)
    {
        _customerRepository = customerRepository;
        _planRepository = planRepository;
    }

    public bool Authenticate(string email, string password)
    {
        Customer customer = _customerRepository.GetByEmail(email);
        return customer.Password.Value == password;
    }

    public void Create(CadasterUserDTO cadasterUserDTO)
    {
        Plan selectedPlan = _planRepository.GetById(cadasterUserDTO.PlanId);
        Customer customer = new Customer(cadasterUserDTO.Name, cadasterUserDTO.Email, cadasterUserDTO.Password, ParseEnum.Parse<Gender>(cadasterUserDTO.Gender), selectedPlan);
        _customerRepository.Add(customer);
    }
}
