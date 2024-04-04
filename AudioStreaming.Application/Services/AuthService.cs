using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AudioStreaming.Domain;
using AudioStreaming.Infrastructure;
using Microsoft.IdentityModel.Tokens;

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
        if(customer == null) return false;
        if(customer.Password.Value != password) return false;
        return true;
    }

    public void Create(CadasterUserDTO cadasterUserDTO)
    {
        Plan selectedPlan = _planRepository.GetById(cadasterUserDTO.PlanId);
        Customer customer = new Customer(cadasterUserDTO.Name, cadasterUserDTO.Email, cadasterUserDTO.Password, ParseEnum.Parse<Gender>(cadasterUserDTO.Gender), selectedPlan);
        customer.CreatePlaylist(new Playlist("Músicas Favoritas", "Minhas músicas favoritas", customer, false));
        customer.SubscribePlan(selectedPlan);
        customer.Activate();
        _customerRepository.Add(customer);
    }
}
