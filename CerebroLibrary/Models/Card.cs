namespace CerebroLibrary.Models;
public class Card
{
    private const string _imageBaseUrl = "https://cerebrodatastorage.blob.core.windows.net/cerebro-cards/official/";

    public bool Deleted { get; set; }
    public string Id { get; set; }
    public bool Official { get; set; }
    public string? AuthorId { get; set; }
    public string? Attack { get; set; }
    public string Classification { get; set; }
    public string Cost { get; set; }
    public string? Health { get; set; }
    public string Name { get; set; }
    public List<Printing> Printings { get; set; }
    public string? Resource { get; set; }
    public string? Rules { get; set; }
    public string Subname { get; set; }
    public string? Thwart { get; set; }
    public List<string> Traits { get; set; }
    public string Type { get; set; }
    public bool Unique { get; set; }
    public string ImageUrl() 
    { 
        return _imageBaseUrl + Id + ".jpg"; 
    }
}

public class Printing
{
    public string ArtificialId { get; set; }
    public string PackId { get; set; }
    public string PackNumber { get; set; }
    public string? Flavor { get; set; }
}
