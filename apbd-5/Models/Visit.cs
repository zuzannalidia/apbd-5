using System.Text.Json.Serialization;

namespace RestApiApbdPjatkCw4.Models;

/// <summary>
/// Model wizyty zwierzęcia.
/// </summary>
public class Visit
{
    /// <summary>
    /// Id wizyty.
    /// </summary>
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    /// <summary>
    /// Data wizyty.
    /// </summary>
    [JsonPropertyName("date")]
    public DateTime Date { get; set; }
    
    // /// <summary>
    // /// Klucz obcy zwierzęcia.
    // /// </summary>
    // [JsonPropertyName("animalId")]
    // public int AnimalId { get; set; }
    
    /// <summary>
    /// Zwierzę wizytujące.
    /// </summary>
    [JsonPropertyName("animal")]
    public Animal Animal { get; set; }
    
    /// <summary>
    /// Opis wizyty.
    /// </summary>
    [JsonPropertyName("description")]
    public string Description { get; set; }
    
    /// <summary>
    /// Cena wizyty.
    /// </summary>
    [JsonPropertyName("cost")]
    public double Cost { get; set; }
}