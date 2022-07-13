using FluentAssertions;
using Pulse.Application.Features.Users.Dtos;
using System;
using System.Net;
using System.Net.Http.Json;
using Xunit;

namespace Pulse.API.IntegrationTests
{
    public class ProductsControllerTests : IntegrationTest
    {

        [Fact]
        public async void PostAsync_ShouldReturnCreatedStatus()
        {
            //Arrange
            var rand = _random.Next(1, int.MaxValue);
            var createUserDto = new CreateUserDto($"FN_{rand}", $"LN{rand}", $"email{rand}@gmail.com");

            //Act
            var response = await _testClient.PostAsJsonAsync(ApiRoutes.Users.Post, createUserDto);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var userDto = this.Deserialize<UserDto>(content);
            Assert.NotNull(userDto);
            userDto.FirstName.Should().Be(createUserDto.FirstName);
            userDto.LastName.Should().Be(createUserDto.LastName);
            userDto.Email.Should().Be(createUserDto.Email);

            //Cleanup
            await DeleteUser(userDto.UserId);
        }

        [Fact]
        public async void GetByIdAsync_WithIdNotExists_ShouldReturnNotFoundStatus()
        {
            //Arrange
            var url = ApiRoutes.Users.GetById.Replace("{userId}", Guid.NewGuid().ToString());

            //Act
            var response = await _testClient.GetAsync(url);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async void GetByIdAsync_WithIdExists_ShouldReturnOkStatus()
        {
            //Arrange
            var user = await CreateUserForTesting();
            var url = ApiRoutes.Users.GetById.Replace("{userId}", user.Id.ToString());

            //Act
            var response = await _testClient.GetAsync(url);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var userDto = this.Deserialize<UserDto>(content);
            Assert.NotNull(userDto);
            userDto.FirstName.Should().Be(user.FirstName);
            userDto.LastName.Should().Be(user.LastName);
            userDto.Email.Should().Be(user.Email);
            userDto.UserId.Should().Be(user.Id);

            //Cleanup
            await DeleteUser(user.Id);
        }

        [Fact]
        public async void PutAsync_WithIdNotExists_ShouldReturnNotFoundStatus()
        {
            //Arrange
            var url = ApiRoutes.Users.PutById.Replace("{userId}", Guid.NewGuid().ToString());

            //Act
            var response = await _testClient.PutAsJsonAsync(url, new UpdateUserDto("FN","LN","e@gmail.com"));

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }


    }
}