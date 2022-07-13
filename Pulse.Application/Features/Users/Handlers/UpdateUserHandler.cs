using MediatR;
using Pulse.Application.Common;
using Pulse.Application.Features.Users.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace Pulse.Application.Features.Users.Handlers
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly IUserServices _userServices;
        public UpdateUserHandler(IUserServices userServices)
        {
            _userServices = userServices;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            await _userServices.UpdateUserAsync(request.user);
            return Unit.Value;
        }
    }
}
