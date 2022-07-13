using Microsoft.Extensions.DependencyInjection;
using Pulse.Application.Common;
using Pulse.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Pulse.API.IntegrationTests
{
    public class IntegrationTest
    {
        protected readonly HttpClient _testClient;
        protected readonly Random _random = new Random();
        protected readonly IUserServices _userServices;
        protected IntegrationTest()
        {
            var appFactory = new TestingWebAppFactory<Program>();
            _testClient = appFactory.CreateDefaultClient();
            this._userServices = appFactory.Server.Services.GetService<IUserServices>();
        }
        protected async Task DeleteUser(Guid userId)
        {
            await _userServices.DeleteUserAsync(userId);
        }
        protected async Task<User> CreateUserForTesting()
        {
            var r = _random.Next(1, int.MaxValue);
            var user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = $"FN_{r}",
                LastName = $"LN{r}",
                Email= $"email{r}@gmail.com"
            };
            await _userServices.CreateUserAsync(user);
            return user;
        }
        protected T Deserialize<T>(string input)
        {
            var serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
            return JsonSerializer.Deserialize<T>(input, serializerOptions);
        }
    }
}
