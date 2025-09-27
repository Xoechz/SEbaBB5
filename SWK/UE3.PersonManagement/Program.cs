using System.Text.Json;
using PersonManagement;

Console.WriteLine("PersonManagement");

var personRepository = new PersonRepository();
using var reader = new StreamReader("/home/elias/Repos/SEbaBB5/SWK/UE3.PersonManagement/persons.json");
using var textWriter = Console.Out;

try
{
    string json = reader.ReadToEnd();
    var persons = JsonSerializer.Deserialize<IEnumerable<Person>>(
        json,
        new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
        ) ?? throw new Exception("Problems with deserialization of persons.json");

    personRepository.AddPersons(persons);
}
catch (FileNotFoundException fnfEx)
{
    Console.WriteLine(fnfEx.Message);
    return;
}



textWriter.WriteLine("=====================================================");
textWriter.WriteLine("Person list");
textWriter.WriteLine("=====================================================");
personRepository.PrintPersons(textWriter);


textWriter.WriteLine();
textWriter.WriteLine("===================================================");
textWriter.WriteLine("Persons in Hagenberg");
textWriter.WriteLine("=====================================================");
foreach (var person in personRepository.FindPersonsByCity("Hagenberg"))
{
    textWriter.WriteLine(person);
}

textWriter.WriteLine();
textWriter.WriteLine("=====================================================");
textWriter.WriteLine("Person names");
textWriter.WriteLine("=====================================================");
foreach (var person in personRepository.GetPersonNames())
{
    textWriter.WriteLine(person);
}

textWriter.WriteLine();
textWriter.WriteLine("=====================================================");
textWriter.WriteLine($"Youngest person");
textWriter.WriteLine("=====================================================");
textWriter.WriteLine(personRepository.FindYoungestPerson());