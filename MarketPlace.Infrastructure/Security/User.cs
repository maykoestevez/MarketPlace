namespace MarketPlace.Infrastructure.Security;

public class User
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public bool IsActive { get; set; }
    public UserType UserType { get; set; }
}

public enum UserType
{
    Admin,
    Customer
}