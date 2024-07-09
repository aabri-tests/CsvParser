using System.Reflection;
using CsvParser.CsvParser.Exceptions;

namespace CsvParser.CsvParser.Readers;

public class CsvReader(string delimiter = ",")
{
    private string Delimiter { get; } = delimiter;
    private const String ResourceName = "CsvParser.examples.csv";
    public List<string> ReadEntries()
    {
        var entries = new List<string>();

        var assembly = Assembly.GetExecutingAssembly();
        var stream = assembly.GetManifestResourceStream(ResourceName);
        if (stream == null) throw new FileNotFoundException("CSV file not found");
        using var r = new StreamReader(stream);
        
        try
        {
            string line;
            while ((line = r.ReadLine()) != null)
            {
                var data = line.Split(new[] { Delimiter }, StringSplitOptions.None);
                entries.Add(data[0]);
            }
        }
        catch (Exception e)
        {
            throw new FileReadException("Error reading CSV file", e);
        }
        
        return entries;
    }
}