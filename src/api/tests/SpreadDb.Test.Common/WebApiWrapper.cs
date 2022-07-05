using NUnit.Framework;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Spread.Test.Common;

public class WebApiWrapper
{
    private readonly HttpClient client;
    private readonly SpreadApplicationFactory factory;

    public WebApiWrapper(SpreadApplicationFactory factory)
    {
        this.factory = factory;
        this.client = factory.Client;
    }

    public string AccessToken { get; set; }

    public async Task<TResult> Delete<TResult>(string url)
    {
        SetupHeader();
        var response = await client.DeleteAsync(url);
        return await HandleResponse<TResult>(response);
    }

    public async Task<TResult> Get<TResult>(string url)
    {
        SetupHeader();
        var response = await client.GetAsync(url);
        return await HandleResponse<TResult>(response);
    }
    public async Task<TResult> Post<TDto, TResult>(string url, TDto data)
    {
        var content = SetupHeaderAndCreateContent(data);
        var response = await client.PostAsync(url, content);
        return await HandleResponse<TResult>(response);
    }

    public async Task<TResult> Put<TDto, TResult>(string url, TDto data)
    {
        var content = SetupHeaderAndCreateContent(data);
        var response = await client.PutAsync(url, content);
        return await HandleResponse<TResult>(response);
    }

    internal void DropDatabase()
    {
        factory.Clean();
    }

    private StringContent SetupHeaderAndCreateContent<TDto>(TDto data)
    {
        SetupHeader();
        var serializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        return new StringContent(JsonSerializer.Serialize(data, serializerOptions), Encoding.UTF8, "application/json");
    }

    private async Task<TResult> HandleResponse<TResult>(HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
        {
            return default(TResult);
        }
        var json = await response.Content.ReadAsStringAsync();
        if (string.IsNullOrEmpty(json))
        {
            return default(TResult);
        }
        var serializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        return JsonSerializer.Deserialize<TResult>(json, serializerOptions);
    }

    private void SetupHeader()
    {
        if (string.IsNullOrEmpty(AccessToken))
        {
            return;
        }

        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
    }
}