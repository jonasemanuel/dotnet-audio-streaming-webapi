using AudioStreaming.Domain;

namespace AudioStreaming.Test;

public class CustomerTests
{
    [Fact]
    public void ShouldCreateCustomerCorrectly()
    {
        string userName = "Jonas Emanuel";
        string userEmail = "me@jonasemanuel.com";
        string userPassword = "12345678";

        Plan newPlan = new Plan("Plano Grátis", 0m);
        CreditCard creditCard = new CreditCard(number: 43211234, limit: 1000M);
        Customer customer = new Customer(userName, userEmail, userPassword, Gender.MALE, newPlan);
        customer.AddCreditCard(creditCard);

        Assert.True(customer.Name == userName);
        Assert.True(customer.Email == new Email(userEmail));
        Assert.True(customer.Password == new Password(userPassword));
        Assert.True(customer.CreditCards.First().Number == creditCard.Number);
        Assert.True(customer.Playlists.Count() == 1);
        Assert.True(customer.Playlists.First().Name == "Músicas Favoritas");
        Assert.True(customer.Subscription.Plan.Name == "Plano Grátis");
        Assert.True(customer.IsActive == true);
    }

    [Fact]
    public void ShouldThrowExceptionWhenPasswordSmallerThanEightCharacters()
    {
        string userName = "Jonas Emanuel";
        string userEmail = "me@jonasemanuel.com";
        string userPassword = "1234";

        Plan newPlan = new Plan("Plano Grátis", 0m);

        Assert.Throws<Exception>(() => 
        {
            Customer customer = new Customer(
                name: userName, 
                email: userEmail, 
                password: userPassword, 
                gender: Gender.MALE, 
                plan: newPlan
            );
        });
    }
}