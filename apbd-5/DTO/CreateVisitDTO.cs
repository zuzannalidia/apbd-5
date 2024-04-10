using System.Text.Json.Serialization;
using RestApiApbdPjatkCw4.Data;
using RestApiApbdPjatkCw4.Models;

namespace RestApiApbdPjatkCw4.DTO;

/// <summary>
/// Obiekt transferu danych dla tworzenia wizyty.
/// </summary>
public class CreateVisitDTO
{
    /// <summary>
    /// Data wizyty.
    /// </summary>
    [JsonPropertyName("date")]
    public DateTime Date { get; set; }
    
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
    
    /// <summary>
    /// Id zwierzęcia.
    /// </summary>
    [JsonPropertyName("animalId")]
    public int AnimalId { get; set; }
    
    public Visit ToVisit()
    {
        return new Visit
        {
            Id = MemoryDatabase.Animals
                .SelectMany(a => a.Visits)
                .Max(v => v.Id) + 1,
            Date = Date,
            Description = Description,
            Cost = Cost
        };
    }
}