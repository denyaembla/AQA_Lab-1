using System.Text.Json.Serialization;

namespace BDDHomework.Models;

public record Milestones
{
    [JsonPropertyName("offset")] public int Offset { get; set; }

    [JsonPropertyName("limit")] public int Limit { get; set; }

    [JsonPropertyName("size")] public int Size { get; set; }

    [JsonPropertyName("_links")] public Links Links { get; set; } = null!;

    [JsonPropertyName("milestones")] public Milestone[] MilestoneList { get; set; } = null!;
}
