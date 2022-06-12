using NUnit.Framework;
using Spread.Data.Requests.Contracts;

namespace Spread.Test.Common;

public class IntegrationTestBase
{
    public IntegrationTestBase()
    {
        var factory = new SpreadApplicationFactory();
        Api = new WebApiWrapper(factory);
    }

    protected async Task Login(string userName)
    {
        var request = new LoginRequestDto
        {
            UserName = userName,
            Password = "123."
        };
        var result = await Api.Post<LoginRequestDto, LoginResultDto>("api/authentication/login", request);
        Api.AccessToken = result.Token;
    }

    public WebApiWrapper Api { get; }

    [OneTimeTearDown]
    protected void TearDown()
    {
        Api.DropDatabase();
    }
}
