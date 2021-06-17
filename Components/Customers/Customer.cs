namespace Components.Customers
{
    public record Customer
    {
        public int Id { get; init; }
        public string Email { get; init; }
        public string Name { get; init; }
        public int Age { get; init; }
    }
}
