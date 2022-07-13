namespace Pulse.API.IntegrationTests
{
    public static class ApiRoutes
    {
        public const string RootApi = "api/v1/";

        public static class Users
        {
            public const string GetAll = RootApi + "users";
            public const string GetById = RootApi + "users/{userId}";
            public const string Post = RootApi + "users";
            public const string PutById = RootApi + "users/{userId}";
        }


    }
}
