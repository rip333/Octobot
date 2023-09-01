
using System.Text.RegularExpressions;
using CerebroLibrary;
using CerebroLibrary.Models;
using CerebroLibrary.Search;

namespace Telegram;
public class PollingService
{
    private readonly ICerebroService _cerebroService;
    private readonly IMessageService _messageService;
    private static int _lastUpdateId = 0;

    public PollingService(IMessageService messageService, ICerebroService cerebroService)
    {
        _messageService = messageService ?? throw new ArgumentNullException(nameof(messageService));
        _cerebroService = cerebroService ?? throw new ArgumentNullException(nameof(cerebroService));
    }


    public async Task PollForUpdatesAsync()
    {
        try
        {
            var updates = await _messageService.GetUpdates(_lastUpdateId);

            if (updates?.result == null) return;
            foreach (var result in updates.result)
            {
                _lastUpdateId = result.update_id;
                if (string.IsNullOrEmpty(result?.message?.text)) continue;
                var message = result?.message?.text.Trim();;
                Console.WriteLine(message ?? "");

                var cards = await _cerebroService.SearchCards(Search.GetParametersFromText(message));
                if (cards.Count() == 0) continue;
                var topThree = cards.Where(x => x.Official).Take(3).ToList();
                foreach (var card in topThree)
                {
                    Console.WriteLine(card.Name);
                    Console.WriteLine(card.Id);
                    Console.WriteLine(card.ImageUrl());
                    await _messageService.SendImageToChat(result.message.chat.id, card.ImageUrl());
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}. {e.StackTrace}");
        }
    }

}