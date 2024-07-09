using System.Text.RegularExpressions;
using CsvParser.CsvParser.Models;

namespace CsvParser.CsvParser.Parsers;

public class TitleNameParser : IEntryParser
{
    private const string Pattern = @"^(Mr|Mrs|Ms|Mister|Prof|Dr)\s+(\b\w{2,}\b)(\s+\w+(-\w+)*)$";

    public object ParseEntry(string entry)
    {
        var match = Regex.Match(entry, Pattern, RegexOptions.IgnoreCase);
        if (match.Success)
        {
            var title = match.Groups[1].Value;
            var firstName = match.Groups[2].Value;
            var lastName = Regex.Replace(match.Groups[3].Value, @"\s+", "");

            return new Person(title, firstName, lastName);
        }

        return null;
    }
}