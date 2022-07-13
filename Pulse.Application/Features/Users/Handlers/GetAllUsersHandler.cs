using MediatR;
using Pulse.Application.Common;
using Pulse.Application.Features.Users.Queries;
using Pulse.Core.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Pulse.Application.Features.Users.Handlers
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<User>>
    {
        private readonly IUserServices _userServices;
        public GetAllUsersHandler(IUserServices userServices)
        {
            _userServices = userServices;
        }
        public async Task<IEnumerable<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await _userServices.GetAllUsersAsync();
        }
    }
}
