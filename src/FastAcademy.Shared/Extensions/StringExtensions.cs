using System.Security.Cryptography;
using System.Text;

namespace FastAcademy.Shared.Extensions;

public static class StringExtensions
{
    public static Guid ToGuid(this string input) => Guid.TryParse(input, out var result) ? result : default;
    
    public static int ToInt(this string input) => int.TryParse(input, out var result) ? result : default;
    
    public static long ToLong(this string input) => long.TryParse(input, out var result) ? result : default;

    public static T ToEnum<T>(this string input) where T : struct, Enum
    {
        if (!Enum.TryParse<T>(input, true, out var result)) 
            throw new ArgumentException("Invalid enum value");
        return result;
    }
    
    public static string ToSha256(this string input)
    {
        if (string.IsNullOrEmpty(input)) return default!;
        var data = SHA256.HashData(Encoding.UTF8.GetBytes(input));
        var stringBuilder = new StringBuilder();
        foreach (var byteCode in data)
            stringBuilder.Append(byteCode.ToString("X2"));
        return stringBuilder.ToString();
    }
    
    public static string RandomString(this int length, string pattern = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890")
        => new(Enumerable
            .Repeat(pattern, length)
            .Select(s => s[new Random().Next(s.Length)])
            .ToArray()
        );
}