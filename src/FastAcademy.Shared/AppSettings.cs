namespace FastAcademy.Shared;

public sealed record AppSettings
{
    public Metadata Metadata { get; set; } = default!;
        
    public JwtOptions JwtOptions { get; set; } = default!;
}

public sealed record Metadata
{
    public string Name { get; set; } = default!;
    
    public string Host { get; set; } = default!;
    
    public string Environment { get; set; } = default!;
    
    public string? EndpointPrefix { get; set; } = default!;
}

public sealed record JwtOptions
{
    public string TokenSigningKey { get; set; } = default!;
    
    public int AccessTokenDurationInMinutes { get; set; }
    
    public int RefreshTokenDurationInDays { get; set; }

    public string? Issuer { get; set; }
    
    public string? Audience { get; set; }
}