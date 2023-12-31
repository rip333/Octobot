using Microsoft.Extensions.Configuration;
namespace Utility;
public class ConfigUtility
{
    public static async Task<string> GetToken()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);
        var config = builder.Build();
        var tokenFileLocation = config["AppSettings:TokenFileLocation"];
        var token = (await File.ReadAllTextAsync(tokenFileLocation)).Trim();
        return token;
    }
}