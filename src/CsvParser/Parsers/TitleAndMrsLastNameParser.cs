using System.Text.RegularExpressions;
using CsvParser.CsvParser.Models;

namespace CsvParser.CsvParser.Parsers;

public class TitleAndMrsLastNameParser : IEntryParser
{
    private const string Pattern = @"^((?:[a-zA-Z]+\s*(?:&|and)\s*)*[a-zA-Z]+)\s+([a-zA-Z]+(?:\s+[a-zA-Z]+)?)$";

    public object ParseEntry(string entry)
    {
        // Split the string into separate entries
        var entries = Regex.Split(entry, @"\s*,\s*");

        var persons = new List<Person>();

        foreach (var singleEntry in entries)
        {
            // Split the entry into title(s) and name(s)
            var match = Regex.Match(singleEntry, Pattern);
            if (match.Success)
            {
                var titlesStr = match.Groups[1].Value;
                var namesStr = match.Groups[2].Value;

                var titles = Regex.Split(titlesStr, @"\s*&\s*|\s+and\s+");
                var names = namesStr.Split(' ');

                foreach (var name in names)
                    if (names.Length == 1) // only last name
                        foreach (var title in titles)
                            persons.Add(new Person(title, "", name));
                    else if (names.Length == 2) // first name and last name
                        foreach (var title in titles)
                            persons.Add(new Person(title, names[0], names[1]));
            }
        }

        if (persons.Count == 0) return null;

        return persons.Count > 1 ? persons : persons[0];
    }
}