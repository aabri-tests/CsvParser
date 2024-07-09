using System.Text.RegularExpressions;

namespace CsvParser.CsvParser.Patterns;

public class TitleNameMatcher : IEntryMatcher
{
    private const string Pattern = @"^(Mr|Mrs|Ms|Mister|Prof|Dr)\s+\b\w{2,}(\s+\w+(-\w+)*)$";

    public bool MatchEntry(string entry)
    {
        return Regex.IsMatch(entry, Pattern, RegexOptions.IgnoreCase);
    }
}