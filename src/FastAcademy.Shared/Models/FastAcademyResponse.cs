using System.Text.Json.Serialization;

namespace FastAcademy.Shared.Models;

public interface IFastAcademyResponse
{
    bool Success { get; }
    
    string? Message { get; set; }
    
    IEnumerable<string>? Errors { get; set; }
}

public class FastAcademyResponse : IFastAcademyResponse
{
    public bool Success => !Errors?.Any() ?? true;
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Message { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<string>? Errors { get; set; }
}

public class FastAcademyResponse<TData> : FastAcademyResponse
{
    public TData Data { get; set; } = default!;
}