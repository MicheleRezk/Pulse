using MediatR;
using Pulse.Core.Entities;
using System;
using System.Collections.Generic;

namespace Pulse.Application.Features.Users.Queries
{
    public record GetAllUsersQuery : IRequest<IEnumerable<User>>;
    public record GetUserByIdQuery(Guid userId) : IRequest<User>;
}
