using Microsoft.AspNetCore.Mvc;
using Pulse.Application;
using Pulse.Application.Features.Users.Commands;
using Pulse.Application.Features.Users.Dtos;
using Pulse.Application.Features.Users.Queries;

namespace Pulse.API.Controllers.v1
{
    [ApiVersion("1.0")]
    public class UsersController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var users = await Mediator.Send(new GetAllUsersQuery());
            var response = users.Select(user => user.AsDto());
            return Ok(response);
        }
      
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var user = await Mediator.Send(new GetUserByIdQuery(id));
            if(user == null)
            {
                return NotFound();
            }
            return Ok(user.AsDto());
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(CreateUserDto createUserDto)
        {
            var createUserCommand = createUserDto.AsCommand();
            var user = await Mediator.Send(createUserCommand);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = user.Id }, user.AsDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutByIdAsync(Guid id, UpdateUserDto updateUserDto)
        {
            var user = await Mediator.Send(new GetUserByIdQuery(id));
            if (user == null)
            {
                return NotFound();
            }
            var updateUserCommand = updateUserDto.AsCommand(id);
            await Mediator.Send(updateUserCommand);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var user = await Mediator.Send(new GetUserByIdQuery(id));
            if (user == null)
            {
                return NotFound();
            }
            await Mediator.Send(new DeleteUserCommand(id));

            return NoContent();
        }
    }
}
