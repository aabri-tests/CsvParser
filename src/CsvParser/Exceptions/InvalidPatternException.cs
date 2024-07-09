namespace CsvParser.CsvParser.Exceptions;

public class InvalidPatternException : Exception
{
    public InvalidPatternException(string message) : base(message)
    {
    }
}