namespace CsvParser.CsvParser.Exceptions;

public class InvalidParserException : Exception
{
    public InvalidParserException(string message) : base(message)
    {
    }
}