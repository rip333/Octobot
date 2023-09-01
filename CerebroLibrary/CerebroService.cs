
using System.Text.Json;
using CerebroLibrary.Models;

namespace CerebroLibrary;
public class CerebroService : ICerebroService
{
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "https://cerebro-beta-bot.herokuapp.com/cards";
    public CerebroService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Card>> GetCardsByName(string name)
    {
        var responseString = await _httpClient.GetStringAsync($"{BaseUrl}?name={name}");
        return JsonSerializer.Deserialize<IEnumerable<Card>>(responseString);
    }

    public async Task<IEnumerable<Card>> GetCardsByClassification(string classification)
    {
        var responseString = await _httpClient.GetStringAsync($"{BaseUrl}?classification={classification}");
        return JsonSerializer.Deserialize<IEnumerable<Card>>(responseString);
    }

    public async Task<IEnumerable<Card>> GetCardsByType(string type)
    {
        var responseString = await _httpClient.GetStringAsync($"{BaseUrl}?type={type}");
        return JsonSerializer.Deserialize<IEnumerable<Card>>(responseString);
    }

    public async Task<IEnumerable<Card>> GetCardsByCost(int cost)
    {
        var responseString = await _httpClient.GetStringAsync($"{BaseUrl}?cost={cost}");
        return JsonSerializer.Deserialize<IEnumerable<Card>>(responseString);
    }

    public async Task<IEnumerable<Card>> SearchCards(Dictionary<string, string> parameters)
    {
        var queryString = string.Join("&", parameters.Select(kv => $"{kv.Key}={kv.Value}"));
        var responseString = await _httpClient.GetStringAsync($"{BaseUrl}?{queryString}");
        return JsonSerializer.Deserialize<IEnumerable<Card>>(responseString);
    }
}
