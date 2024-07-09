using CsvParser.CsvParser.Exceptions;
using CsvParser.CsvParser.Parsers;

namespace CsvParser.CsvParser.Factories;

public static class ParserFactory
{
    public static IEntryParser CreateParser(string patternName)
    {
        return patternName switch
        {
            "pattern1" => new TitleNameParser(),
            "pattern2" => new InitialLastNameParser(),
            "pattern3" => new TitleAndMrsLastNameParser(),
            "pattern4" => new TitleNameAndTitleNameParser(),
            _ => throw new InvalidParserException($"Invalid pattern name: {patternName}")
        };
    }
}