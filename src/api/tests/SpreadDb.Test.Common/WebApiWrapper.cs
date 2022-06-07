using System.Text.Json;

namespace Spread.Test.Common;

public class WebApiWrapper
{
    private readonly SpreadApplicationFactory factory;
    private readonly HttpClient client;

    public WebApiWrapper(SpreadApplicationFactory factory)
    {
        this.factory = factory;
        this.client = factory.Client;
    }

    public async Task<T> Get<T>(string url)
    {
        var response = await client.GetAsync(url);
        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<T>(json);
    }

    internal void DropDatabase()
    {
        factory.Clean();
    }
}
