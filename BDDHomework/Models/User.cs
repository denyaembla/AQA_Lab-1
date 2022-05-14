using System.Text.Json.Serialization;

namespace BDDHomework.Models;

public record User
{
    [JsonPropertyName("id")] public int Id { get; set; }
    // DEVNOTE: Populate this record correspondingly to your needs.
}
