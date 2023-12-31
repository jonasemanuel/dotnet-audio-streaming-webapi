﻿namespace AudioStreaming.Domain;

public class Transaction
{
  public Guid Id { get; private set; }
  public string Details { get; private set; }
  public DateTime CreatedAt { get; private set; }
  public TransactionStatus Status { get; set; } = TransactionStatus.OK;
  public decimal Value { get; private set; }
  public Merchant Merchant { get; private set; }

  public Transaction(string details, Merchant merchant, decimal value)
  {
    if(value <= 0)
    {
      throw new Exception("Transaction value should be greater than 0");
    }

    Id = new Guid();
    Details = details;
    CreatedAt = DateTime.Now;
    Merchant = merchant;
    Value = value;
  }
}
