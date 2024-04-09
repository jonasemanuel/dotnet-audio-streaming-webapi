using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AudioStreaming.Domain;
using AudioStreaming.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AudioStreaming.Application;

public class AuthService
{
    private readonly CustomerRepository _customerRepository;
    private readonly PlanRepository _planRepository;
    private readonly IConfiguration _config;

    public AuthService(CustomerRepository customerRepository, PlanRepository planRepository, IConfiguration config)
    {
        _customerRepository = customerRepository;
        _planRepository = planRepository;
        _config = config;
    }

    public string Authenticate(string email, string password)
    {
        Customer customer = _customerRepository.GetByEmail(email);
        if (customer == null || customer.Password.Value != password.HashSHA256())
        {
            return null;
        }
        SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

        var Sectoken = new JwtSecurityToken(
            _config["Jwt:Issuer"],
            _config["Jwt:Issuer"],
            new List<Claim>
            {
                new Claim("Name", customer.Name),
                new Claim("Email", customer.Email.Value),
                new Claim("PlanId", customer.Subscription.Plan.Id.ToString())
            },
            expires: DateTime.Now.AddMinutes(120)
        );

        return new JwtSecurityTokenHandler().WriteToken(Sectoken);
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
