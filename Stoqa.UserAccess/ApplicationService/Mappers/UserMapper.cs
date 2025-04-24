using Stoqa.Identity.ApplicationService.DTOs.UserDtos.Request;
using Stoqa.Identity.ApplicationService.DTOs.UserDtos.Response;
using Stoqa.Identity.ApplicationService.Interfaces.MapperContracts;
using Stoqa.Identity.Domain.Entities;

namespace Stoqa.Identity.ApplicationService.Mappers;

public sealed class UserMapper(
    IRoleMapper roleMapper
    ) : IUserMappers
{
    public User RegisterDtoToDomain(UserRegisterRequest userRegisterRequest) =>
        new()
        {
            Id = default,
            UserName = userRegisterRequest.Email,
            Email = null,
            NormalizedEmail = null,
            EmailConfirmed = true,
            PasswordHash = userRegisterRequest.Password,
            ConcurrencyStamp = null,
            PhoneNumber = userRegisterRequest.PhoneNumber,
            PhoneNumberConfirmed = true,
            Status = userRegisterRequest.Status,
            UserType = userRegisterRequest.UserType,
            CreationDate = DateTime.Now,
            DisplayName = userRegisterRequest.DisplayName,
            NormalizedDisplayName = userRegisterRequest.DisplayName.ToUpperInvariant(),
            Document = userRegisterRequest.Document,
            UserRoles = userRegisterRequest.RolesId!.Select(r => new UserRole{RoleId = r}).ToList()
        };

    public UserSimpleResponse DomainToSimpleResponse(User user) =>
        new()
        {
            Email = user.UserName!,
            Status = user.Status,
            UserType = user.UserType,
            Password = user.PasswordHash!,
            DisplayName = user.DisplayName,
            Roles = roleMapper.DomainToSimpleResponse(user.UserRoles?.Select(r => r.Role).ToList()!)
        };
}