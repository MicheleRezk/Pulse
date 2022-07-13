using MediatR;
using Pulse.Application.Common;
using Pulse.Application.Features.Users.Commands;
using Pulse.Core.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Pulse.Application.Features.Users.Handlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly IUserServices _userServices;
        public CreateUserHandler(IUserServices userServices)
        {
            _userServices = userServices;
        }

        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            return await _userServices.CreateUserAsync(request.user);
        }
    }
}
