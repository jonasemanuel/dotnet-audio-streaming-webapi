using AudioStreaming.Admin.Infrastructure;
using AudioStreaming.Domain;

namespace AudioStreaming.Application;

public class UserService
{
    private readonly UserRepository _userRepository;
    public UserService(UserRepository userRepository)
    {
        _userRepository = userRepository;      
    }

    public void Create(RequestCreateUserDTO dto)
    {
        var user = new User(dto.Email, dto.Password, dto.Role);
        _userRepository.Create(user);
    }

    public IEnumerable<ResponseUserDTO> GetAll()
    {
        var users = _userRepository.GetAll();
        return users.Select(user => new ResponseUserDTO
        {
            Email = user.Email.Value,
            Role = user.Role.ToString(),
            CreatedAt = user.CreatedAt
        });
    }

    public User Login(string email, string password)
    {
        return _userRepository.GetByEmailAndPassword(email, password);
    }
}
