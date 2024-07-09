using System.Text.RegularExpressions;
using CsvParser.CsvParser.Models;

namespace CsvParser.CsvParser.Parsers;

public class TitleNameAndTitleNameParser : IEntryParser
{
    private const string Pattern = @"([a-zA-Z]+)\s+([a-zA-Z]+)\s+([a-zA-Z]+)";

    public object ParseEntry(string entry)
    {
        // Split the string into separate entries
        var entries = Regex.Split(entry, @"\s+and\s+|\s*,\s*", RegexOptions.IgnoreCase);

        var persons = new List<Person>();
        foreach (var singleEntry in entries)
        {
            var match = Regex.Match(singleEntry, Pattern);
            if (match.Success)
            {
                var title1 = match.Groups[1].Value;
                var title2 = match.Groups[2].Value;
                var lastName = match.Groups[3].Value;

                persons.Add(new Person(title1, title2, lastName));
            }
        }

        if (persons.Count == 0) return null;

        return persons.Count > 1 ? persons : persons[0];
    }
}