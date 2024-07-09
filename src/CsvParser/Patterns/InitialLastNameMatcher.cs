using System.Text.RegularExpressions;

namespace CsvParser.CsvParser.Patterns;

public class InitialLastNameMatcher : IEntryMatcher
{
    private const string
        Pattern =
            @"^(?:Mr|Mrs|Ms|Mister|Prof|Dr)\s+[A-Z](?:\.[A-Z]|\.)?\s[A-Za-z]+$"; // Mr F. Fredrickson || Mr F Fredrickson

    public bool MatchEntry(string entry)
    {
        return Regex.IsMatch(entry, Pattern);
    }
}