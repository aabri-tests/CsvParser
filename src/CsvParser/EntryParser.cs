namespace CsvParser.CsvParser;

public interface IEntryParser
{
    public object ParseEntry(string entry);
}