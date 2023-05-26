using MarketPlace.Domain.Common;

namespace MarketPlace.Domain;

public class Order : AuditableEntity
{
    public int Id { get; set; }
    public PaymentMethodType PaymentMethod { get; set; }
    public double Amount { get; set; }
    public bool IsPaid { get; set; }
}

public enum PaymentMethodType
{
    Card,
    Cash,
    Paypal
}
