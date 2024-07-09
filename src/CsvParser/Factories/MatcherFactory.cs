using CsvParser.CsvParser.Exceptions;
using CsvParser.CsvParser.Patterns;

namespace CsvParser.CsvParser.Factories;

public static class MatcherFactory
{
    public static IEntryMatcher CreateMatcher(string patternName)
    {
        return patternName switch
        {
            "pattern1" => new TitleNameMatcher(),
            "pattern2" => new InitialLastNameMatcher(),
            "pattern3" => new TitleAndMrsLastNameMatcher(),
            "pattern4" => new TitleNameAndTitleNameMatcher(),
            _ => throw new InvalidPatternException($"Invalid pattern name: {patternName}")
        };
    }
}