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

    SHA256 criptoProvider = SHA256.Create();

    byte[] btexto = Encoding.UTF8.GetBytes(password);

    var criptoResult = criptoProvider.ComputeHash(btexto);

    Value = Convert.ToHexString(criptoResult);
  }
}
