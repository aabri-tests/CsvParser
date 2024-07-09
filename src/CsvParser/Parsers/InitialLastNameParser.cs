using System.Text.RegularExpressions;
using CsvParser.CsvParser.Models;

namespace CsvParser.CsvParser.Parsers;

public class InitialLastNameParser : IEntryParser
{
    private const string Pattern = @"([a-zA-Z]+)\s+([a-zA-Z])\.?\s+([a-zA-Z]+)";

    public object ParseEntry(string entry)
    {
        var match = Regex.Match(entry, Pattern);
        if (match.Success)
        {
            var title = match.Groups[1].Success ? match.Groups[1].Value.Trim() : null;
            var firstName = match.Groups[2].Value;
            var lastName = match.Groups[3].Value;

            return new Person(title, firstName, lastName);
        }

        return null;
    }
}