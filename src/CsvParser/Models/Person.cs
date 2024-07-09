namespace CsvParser.CsvParser.Models;

public class Person(string title, string firstName, string lastName = "", char initial = '\0')
{   
    private string Title { get; } = title;
    private string FirstName { get; } = firstName;
    private char Initial { get; } = initial;
    private string LastName { get; } = lastName;
    
    public override string ToString()
    {
        return $"{Title} {Initial} {FirstName} {LastName}".Trim();
    }
}