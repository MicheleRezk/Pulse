using Microsoft.AspNetCore.Mvc.Testing;

namespace Pulse.API.IntegrationTests
{
    public class TestingWebAppFactory<TEntryPoint> : WebApplicationFactory<Program> where TEntryPoint : Program
    {
    }
}
