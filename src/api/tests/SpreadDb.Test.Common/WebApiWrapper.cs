﻿using NUnit.Framework;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Spread.Test.Common;

public class WebApiWrapper
{
    private readonly HttpClient client;
    private readonly SpreadApplicationFactory factory;
    private readonly JsonSerializerOptions serializerOptions;
    public WebApiWrapper(SpreadApplicationFactory factory)
    {
        this.factory = factory;
        this.client = factory.Client;
        this.serializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    public string AccessToken { get; set; }

    public async Task<T> Get<T>(string url)
    {
        SetupHeader();
        var response = await client.GetAsync(url);
        if (!response.IsSuccessStatusCode)
        {
            Assert.Fail($"{url}\n{response.StatusCode}");
            return default(T);
        }
        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<T>(json, serializerOptions);
    }

    public async Task<TResult> Post<TDto, TResult>(string url, TDto user)
    {
        var content = new StringContent(JsonSerializer.Serialize(user, serializerOptions), Encoding.UTF8, "application/json");
        SetupHeader();
        var response = await client.PostAsync(url, content);
        if (!response.IsSuccessStatusCode)
        {
            Assert.Fail($"{url}\n{response.StatusCode}");
            return default(TResult);
        }
        var json = await response.Content.ReadAsStringAsync();
        if (string.IsNullOrEmpty(json))
        {
            return default(TResult);
        }
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

    internal void DropDatabase()
    {
        factory.Clean();
    }
}