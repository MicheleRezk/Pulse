namespace Pulse.Application.Features.Users.Dtos
{
    public record CreateUserDto(string FirstName, string LastName, string Email);
    public record UpdateUserDto(string FirstName, string LastName, string Email);
}
