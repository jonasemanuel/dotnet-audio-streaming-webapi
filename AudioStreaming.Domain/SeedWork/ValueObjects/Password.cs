using System.Security.Cryptography;
using System.Text;

namespace AudioStreaming.Domain;

public record class Password
{
  public string Value { get; }   
  public Password (string password) 
  {
    if(password.Length < 8) 
    {
      throw new Exception("Password must be at least 8 characters");
    }

    Value = password;
  }
}
