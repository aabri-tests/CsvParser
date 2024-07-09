using CsvParser.CsvParser.Factories;

namespace CsvParser.CsvParser.Processors;

public class EntryProcessor
{
    public string? FindMatchingPattern(string entry, List<string> groups)
    {
        foreach (var patternName in groups)
        {
            var matcher = MatcherFactory.CreateMatcher(patternName);

            if (matcher.MatchEntry(entry)) return patternName;
        }

        return null;
    }

    public object? ProcessEntry(string entry, string patternName)
    {
        var parser = ParserFactory.CreateParser(patternName);
        var parsedData = parser.ParseEntry(entry);

        return parser.ParseEntry(entry);
    }
}