using CerebroLibrary.Models;
namespace CerebroLibrary;
public interface ICerebroService
{
    Task<IEnumerable<Card>> GetCardsByName(string name);
    Task<IEnumerable<Card>> GetCardsByClassification(string classification);
    Task<IEnumerable<Card>> GetCardsByType(string type);
    Task<IEnumerable<Card>> GetCardsByCost(int cost);
    Task<IEnumerable<Card>> SearchCards(Dictionary<string, string> parameters);
}