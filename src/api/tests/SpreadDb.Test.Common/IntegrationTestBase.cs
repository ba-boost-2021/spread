using NUnit.Framework;

namespace Spread.Test.Common;

public class IntegrationTestBase
{
    public IntegrationTestBase()
    {
        var factory = new SpreadApplicationFactory();
        Api = new WebApiWrapper(factory);
    }

    public WebApiWrapper Api { get; }

    [OneTimeTearDown]
    protected void TearDown()
    {
        Api.DropDatabase();
    }
}
