using AudioStreaming.Domain;

namespace AudioStreaming.Test;

public class CreditCardTests
{
  [Fact]
  public void ShouldCreateNewTransactionCorrectly()
  {
    CreditCard creditCard = new CreditCard(98765643, 2500M);
    Merchant merchant = new Merchant("FakeMerchant");

    creditCard.NewTransaction(merchant, 2340M, "Some transaction");

    Assert.True(creditCard.Transactions.Count() == 1);
    Assert.True(creditCard.Limit == 160M);
  }

  [Fact]
  public void ShouldNotCreateNewTransactionWithoutLimit()
  {
    CreditCard creditCard = new CreditCard(98765643, 0);
    Merchant merchant = new Merchant("FakeMerchant");

    Assert.Throws<Exception>(() => 
    {
      creditCard.NewTransaction(merchant, 2340M, "Some transaction");
    });
  }

  [Fact]
  public void ShouldNotCreateDuplicateTransaction()
  {
    CreditCard creditCard = new CreditCard(98765643, 1000M);
    Merchant merchant = new Merchant("FakeMerchant");

    creditCard.NewTransaction(merchant, 500M, "Some transaction");

    Assert.Throws<Exception>(() => 
    {
      creditCard.NewTransaction(merchant, 500M, "Some transaction");
    });
  }

  [Fact]
  public void ShouldNotCreateMultipleTransactionInFewMinutes()
  {
    CreditCard creditCard = new CreditCard(98765643, 1000M);
    Merchant merchant1 = new Merchant("FakeMerchant1");
    Merchant merchant2 = new Merchant("FakeMerchant2");
    Merchant merchant3 = new Merchant("FakeMerchant3");

    creditCard.NewTransaction(merchant1, 100M, "Some transaction");
    creditCard.NewTransaction(merchant2, 250M, "Some transaction");


    Assert.Throws<Exception>(() => 
    {
      creditCard.NewTransaction(merchant3, 100M, "Some transaction");
    });
  }
}
