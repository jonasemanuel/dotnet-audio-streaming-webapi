using System.Text.RegularExpressions;

namespace AudioStreaming.Domain;

public record class Email
{
  public string Value { get; }

  public Email(string email)
  {
    Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
    Match isCorrectEmail = emailRegex.Match(email);

    if(isCorrectEmail.Success == false)
    {
      throw new Exception("E-mail must be valid");
    }

    Value = email;
  }
}
