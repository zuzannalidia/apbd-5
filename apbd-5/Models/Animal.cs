using System.Text.Json.Serialization;

namespace RestApiApbdPjatkCw4.Models;

/// <summary>
/// Klasa reprezentująca zwierzę.
/// </summary>
public class Animal
{
    /// <summary>
    /// Id zwierzęcia (klucz główny).
    /// </summary>
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Imię zwierzęcia.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    /// <summary>
    /// Kategoria zwierzęcia.
    /// </summary>
    [JsonPropertyName("category")]
    public string Category { get; set; }
    
    /// <summary>
    /// Masa zwierzęcia.
    /// </summary>
    [JsonPropertyName("mass")]
    public double Mass { get; set; }
    
    /// <summary>
    /// Kolor sierści zwierzęcia.
    /// </summary>
    [JsonPropertyName("hairColor")]
    public string HairColor { get; set; }
    
    [JsonPropertyName("visits")]
    public List<Visit> Visits { get; set; }
    
    
    public void Update(Animal animal)
    {
        Name = animal.Name;
        Category = animal.Category;
        Mass = animal.Mass;
        HairColor = animal.HairColor;
        Visits = animal.Visits;
    }
}