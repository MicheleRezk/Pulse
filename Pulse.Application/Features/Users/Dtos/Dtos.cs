using System;

namespace Pulse.Application.Features.Users.Dtos
{
    public record CreateUserDto(string FirstName, string LastName, string Email);
    public record UpdateUserDto(string FirstName, string LastName, string Email);
    public record UserDto(Guid UserId,string FirstName, string LastName, string Email);
}
