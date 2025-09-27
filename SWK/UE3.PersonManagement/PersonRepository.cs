namespace PersonManagement;

public class PersonRepository
{
    private readonly List<Person> _persons = [];

    public void AddPerson(Person person)
    {
        _persons.Add(person);
    }

    public void AddPersons(IEnumerable<Person> persons)
    {
        _persons.AddRange(persons);
    }

    public void PrintPersons(TextWriter textWriter)
    {
        foreach (var person in _persons)
        {
            textWriter.WriteLine(person);
        }
    }

    public IEnumerable<Person> FindPersonsByCity(string city)
    {
        foreach (var person in _persons)
        {
            if (person.City == city)
            {
                yield return person;
            }
        }
    }

    public IEnumerable<(string?, string?)> GetPersonNames()
    {
        foreach (var person in _persons)
        {
            yield return (person.FirstName, person.LastName);
        }
    }

    public Person FindYoungestPerson()
    {
        using var e = _persons.GetEnumerator();

        if (!e.MoveNext())
        {
            throw new InvalidOperationException("No persons in repository");
        }

        var youngest = e.Current;

        while (e.MoveNext())
        {
            if (e.Current.DateOfBirth > youngest.DateOfBirth)
            {
                youngest = e.Current;
            }
        }

        return youngest;
    }
}
