using MediatR;
using Pulse.Application.Common;
using Pulse.Application.Features.Users.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace Pulse.Application.Features.Users.Handlers
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly IUserServices _userServices;
        public DeleteUserHandler(IUserServices userServices)
        {
            _userServices = userServices;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            await _userServices.DeleteUserAsync(request.userId);
            return Unit.Value;
        }
    }
}
