using Pulse.Application.Features.Users.Commands;
using Pulse.Application.Features.Users.Dtos;
using Pulse.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pulse.Application
{
    public static class Extensions
    {
        //TODO: refactor all mapping methods and use AutoMapper
        public static UserDto AsDto(this User user)
        {
            var dto = new UserDto(user.Id, user.FirstName, user.LastName, user.Email);
            return dto;
        }
        public static CreateUserCommand AsCommand(this CreateUserDto userDto)
        {
            var user = new User
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                Id = Guid.NewGuid(),
            };
            return new CreateUserCommand(user);
        }
        public static UpdateUserCommand AsCommand(this UpdateUserDto userDto, Guid userId)
        {
            var user = new User
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                Id = userId
            };
            return new UpdateUserCommand(user);
        }
    }
}
