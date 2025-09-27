namespace PersonManagement;

public class Person
{
    public uint Id { get; init; }
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public DateTime DateOfBirth { get; init; }
    public string? City { get; init; }

    public override string ToString() => $"{Id} \t {FirstName} {LastName} \t {DateOfBirth.ToShortDateString()} \t {City}";
}

//public record Person(uint Id, string? FirstName, string? LastName, DateTime DateOfBirth, string? City)
//{
//    public override string ToString() => $"{Id} \t {FirstName} {LastName} \t {DateOfBirth.ToShortDateString()} \t {City}";
//}
