namespace CerebroLibrary.Search;
public static class Search {
    public static Dictionary<string, string> GetParametersFromText(string text) {
                var result = new Dictionary<string, string>();

        // Split the text by spaces, but keeping the data after the colon together.
        var segments = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                 .Select(segment => segment.Split(':'))
                                 .ToList();

        foreach (var segment in segments)
        {
            string key = segment[0];
            string value = segment.Length > 1 ? segment[1] : key; // If no specific filter, it's a name search.

            switch (key.ToLower())
            {
                case "x":
                    result["text"] = value;
                    break;
                case "k":
                    result["traits"] = value;
                    break;
                case "t":
                    result["type"] = value;
                    break;
                case "r":
                    result["resource"] = value;
                    break;
                case "o":
                    result["cost"] = value;
                    break;
                case "c":
                    result["classification"] = FuzzyMatcher.AspectFuzzyMatch(value);
                    break;
                case "m":
                    result["set"] = value;
                    break;
                default:
                    if (!result.ContainsKey("name"))
                    {
                        result["name"] = value; // Default case is name search.
                    }
                    else
                    {
                        result["name"] += " " + value; // Concatenate other parts to the name.
                    }
                    break;
            }
        }

        return result;
    }
}