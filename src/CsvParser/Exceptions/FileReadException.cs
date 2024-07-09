namespace CsvParser.CsvParser.Exceptions;

public class FileReadException : Exception
{
    public FileReadException(string message, Exception innerException) : base(message, innerException)
    {
    }
}