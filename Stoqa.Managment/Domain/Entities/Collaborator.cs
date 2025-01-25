using Stoqa.Managment.Domain.Enums;

namespace Stoqa.Managment.Domain.Entities;

public sealed class Collaborator
{
    public Guid Id { get; init; }
    public required string Name { get; init; }
    public required string Password { get; init; }
    public required string Document { get; init; }
    public DateTime CreateDate { get; init; }
    public required ERole Role { get; init; }
    public required EGender Gender { get; init; }
    public required long AddressId { get; init; }
    public required Address Address { get; set; }
}