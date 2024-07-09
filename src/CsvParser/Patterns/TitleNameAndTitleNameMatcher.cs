using System.Text.RegularExpressions;

namespace CsvParser.CsvParser.Patterns;

public class TitleNameAndTitleNameMatcher : IEntryMatcher
{
    private const string
        Pattern =
        @"(?:Mr|Mrs|Ms|Mister|Prof|Dr)\s[A-Za-z]+\s[A-Za-z]+\s(?:and|&)\s(?:Mr|Mrs|Ms|Mister|Prof|Dr)\s[A-Za-z]+\s[A-Za-z]+";

    public bool MatchEntry(string entry)
    {
        return Regex.IsMatch(entry, Pattern, RegexOptions.IgnoreCase);
    }
}