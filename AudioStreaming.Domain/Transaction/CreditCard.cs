namespace AudioStreaming.Domain;

public class CreditCard
{
  public Guid Id { get; private set; }
  public int Number { get; private set; }
  public bool IsActive { get; private set; }
  public decimal Limit { get; private set; }
  public List<Transaction> Transactions { get; set; } = new List<Transaction>();

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

    ValidateTransaction(transaction);
  }

  private bool IsAvailableLimit(decimal transactionValue)
  {
    return this.Limit < transactionValue;
  }

  private void ValidateTransaction(Transaction transaction)
  {
    IEnumerable<Transaction> lastTransactions = Transactions.Where(t =>
    {
      return t.CreatedAt >= DateTime.Now.AddMinutes(2);
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
  }
}
