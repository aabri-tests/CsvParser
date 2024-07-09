namespace CsvParser.CsvParser;

public interface IEntryMatcher
{
    public bool MatchEntry(string entry);
}