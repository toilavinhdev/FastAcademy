using System.Text.RegularExpressions;

namespace FastAcademy.Shared.Utilities;

public static partial class RegexUtils
{
    [GeneratedRegex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$")] 
    private static partial Regex EmailGeneratedRegex();
    public static readonly Regex EmailRegex = EmailGeneratedRegex();
}