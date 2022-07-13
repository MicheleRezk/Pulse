using System;
using System.ComponentModel.DataAnnotations;

namespace Pulse.Application.Features.Users.Dtos
{
    public record CreateUserDto([Required] string FirstName, [Required] string LastName, [Required][EmailAddress] string Email);
    public record UpdateUserDto([Required] string FirstName, [Required] string LastName, [Required][EmailAddress] string Email);
    public record UserDto(Guid UserId,string FirstName, string LastName, string Email);
}
