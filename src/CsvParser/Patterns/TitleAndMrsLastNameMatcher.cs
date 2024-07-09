using System.Text.RegularExpressions;

namespace CsvParser.CsvParser.Patterns;

public class TitleAndMrsLastNameMatcher : IEntryMatcher
{
    private const string
        Pattern = @"^(?:Mr|Mrs|Ms|Mister|Prof|Dr)\s+(?:and|&)\s+Mrs\s+[A-Za-z]+\b"; // Mr and Mrs Smith

    public bool MatchEntry(string entry)
    {
        return Regex.IsMatch(entry, Pattern, RegexOptions.IgnoreCase);
    }
}