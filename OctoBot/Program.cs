
using CerebroLibrary;
using Utility;

Flavor.Intro();
var token = await ConfigUtility.GetToken();
await Flavor.Authorized();
var httpClient = new HttpClient();
var pollingService = new PollingService(
        new MessageService(token, httpClient),
        new CerebroService(httpClient)
    );

while (true)
{
    await pollingService.PollForUpdatesAsync();
    await Task.Delay(5000);
}
