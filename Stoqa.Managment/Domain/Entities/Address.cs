namespace Stoqa.Managment.Domain.Entities;

public sealed class Address
{
    public long Id { get; init; }
    public required string Street { get; set; }
    public required string District { get; set; }
    public required string City { get; set; }
    public required string Number { get; set; }
    public string? Complement { get; set; }
    public required string State { get; set; }
    public required string ZipCode { get; set; }
    public required string Country { get; set; }
}