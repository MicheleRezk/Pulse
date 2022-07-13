using MediatR;
using Pulse.Application.Common;
using Pulse.Core.Entities;
using System;
using System.Collections.Generic;

namespace Pulse.Application.Features.Users.Queries
{
    public record GetAllUsersQuery(bool BypassCache) : IRequest<IEnumerable<User>>, ICacheableMediatrQuery
    {
        public string CacheKey => $"UserList";

        public TimeSpan? SlidingExpiration => null;
    }

    public record GetUserByIdQuery(Guid UserId, bool BypassCache) : IRequest<User>, ICacheableMediatrQuery
    {
        public string CacheKey => $"User-{UserId}";

        public TimeSpan? SlidingExpiration => null;
    }
}
