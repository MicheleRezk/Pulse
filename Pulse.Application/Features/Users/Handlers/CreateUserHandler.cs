using MediatR;
using Pulse.Application.Common;
using Pulse.Application.Features.Users.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace Pulse.Application.Features.Users.Handlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, Unit>
    {
        private readonly IUserServices _userServices;
        public CreateUserHandler(IUserServices userServices)
        {
            _userServices = userServices;
        }
        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            await _userServices.CreateUserAsync(request.user);
            return Unit.Value;
        }
    }
}
