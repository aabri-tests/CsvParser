using CsvParser.CsvParser.Exceptions;
using CsvParser.CsvParser.Models;
using CsvParser.CsvParser.Processors;
using CsvParser.CsvParser.Readers;

namespace CsvParser;

internal class Program
{
    private static void Main(string[] args)
    {
        
        var groups = new List<string>
        {
            "pattern1",
            "pattern2",
            "pattern3",
            "pattern4"
        };

        try
        {
            var csvReader = new CsvReader();

            var entries = csvReader.ReadEntries();

            var data = new List<Person>();
            var entryProcessor = new EntryProcessor();

            foreach (var entry in entries)
            {
                var matchedPattern = entryProcessor.FindMatchingPattern(entry, groups);

                if (!string.IsNullOrEmpty(matchedPattern))
                {
                    var result = entryProcessor.ProcessEntry(entry, matchedPattern);
                    if (result is Person person) // If the result is a single Person object
                        data.Add(person);
                    else if (result is List<Person> personList) // If the result is a list of Person objects
                        data.AddRange(personList);
                }
            }

            foreach (var processedEntry in data) Console.WriteLine(processedEntry);
        }
        catch (FileNotFoundException e)
        {
            // Handle the exception for file not found
            Console.WriteLine("File not found error: " + e.Message);
        }
        catch (FileReadException e)
        {
            // Handle the exception for file read error
            Console.WriteLine("File read error: " + e.Message);
        }
        catch (InvalidPatternException e)
        {
            // Handle the exception for an invalid pattern name
            Console.WriteLine("Invalid pattern name: " + e.Message);
        }
        catch (Exception e)
        {
            // Handle any other generic exception
            //Console.WriteLine("Error: " + e.StackTrace);
            Console.WriteLine("Error: " + e.StackTrace);
        }
    }
}