using MediatR;
using Pulse.Application.Common;
using Pulse.Application.Features.Users.Queries;
using Pulse.Core.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Pulse.Application.Features.Users.Handlers
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly IUserServices _userServices;
        public GetUserByIdHandler(IUserServices userServices)
        {
            _userServices = userServices;
        }

        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _userServices.GetUserByIdAsync(request.userId);
        }
    }
}
