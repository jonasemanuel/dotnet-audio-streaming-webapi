namespace AudioStreaming.Domain;

public class CreditCard : IEntity
{
  public Guid Id { get; set; }
  public int Number { get; private set; }
  public bool IsActive { get; private set; }
  public decimal Limit { get; private set; }
  public List<Transaction> Transactions { get; private set; } = new List<Transaction>();

  public CreditCard(int number, decimal limit)
  {
    Id = new Guid();
    Number = number;
    IsActive = true;
    Limit = limit;
  }

  public void NewTransaction(Merchant merchant, decimal value, string details)
  {
    if(IsActive == false)
    {
      throw new Exception("This credit card is not active");
    }

    if(IsAvailableLimit(value) == false)
    {
      throw new Exception("Limit not available for this transaction");
    }

    Transaction transaction = new Transaction(details, merchant, value);
    Transactions.Add(transaction);

    ValidateTransaction(transaction);

    Limit = Limit - transaction.Value;
  }

  private bool IsAvailableLimit(decimal transactionValue)
  {
    return Limit >= transactionValue;
  }

  private void ValidateTransaction(Transaction transaction)
  {
    IEnumerable<Transaction> lastTransactions = Transactions.Where(t =>
    {
      return t.CreatedAt <= DateTime.Now.AddMinutes(2);
    });

    if(lastTransactions.Count() >= 3)
    {
      throw new Exception("Card used a lot in the last few minutes");
    }

    IEnumerable<Transaction> lastTransactionsByMerchant = lastTransactions.Where(t => 
    { 
      return t.Merchant.Name.ToUpper() == transaction.Merchant.Name.ToUpper() && t.Value == transaction.Value;
    });

    if(lastTransactionsByMerchant.Count() >= 2)
    {
      throw new Exception("Duplicate transaction to same merchant detected.");
    }

    if(IsActive == false)
    {
      throw new Exception("Credit card is inactive.");
    }
  }

  public void Active()
  {
    IsActive = true;
  }

  public void DeActivate()
  {
    IsActive = false;
  }
}
