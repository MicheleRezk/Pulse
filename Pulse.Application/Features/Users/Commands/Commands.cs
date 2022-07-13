using MediatR;
using Pulse.Core.Entities;
using System;

namespace Pulse.Application.Features.Users.Commands
{
    public record CreateUserCommand(User user) : IRequest;
    public record UpdateUserCommand(User user) : IRequest;
    public record DeleteUserCommand(Guid userId) : IRequest;
}
