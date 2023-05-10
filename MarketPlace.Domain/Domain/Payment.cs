﻿namespace MarketPlace.Domain;

public class Payment
{
    public int Id { get; set; }
    public PaymentMethodType PaymentMethod { get; set; }
    public double Amount { get; set; }
    public IEnumerable<Product> Products { get; set; }
}
public enum PaymentMethodType
{
    Card,
    Cash,
    Paypal
}