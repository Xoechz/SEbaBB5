using System.Collections;

namespace Playground;

public class ClassEnumerable : IEnumerable<int>
{
    public IEnumerator<int> GetEnumerator()
    {
        yield return 1;
        yield return 2;
        yield return 3;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public class ClassNotEnumerable
{
    public IEnumerator<int> GetEnumerator()
    {
        yield return 1;
        yield return 2;
        yield return 3;
    }
}

public struct StructEnumerable : IEnumerable<int>
{
    public IEnumerator<int> GetEnumerator()
    {
        yield return 1;
        yield return 2;
        yield return 3;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public struct StructNotEnumerable
{
    public IEnumerator<int> GetEnumerator()
    {
        yield return 1;
        yield return 2;
        yield return 3;
    }
}

public ref struct RefStructNotEnumerable
{
    public RefStructNotEnumerable.Enumerator GetEnumerator()
    {
        return new Enumerator();
    }

    public ref struct Enumerator
    {
        public int Current { get; private set; }

        public bool MoveNext()
        {
            Current++;
            return Current <= 3;
        }
    }
}

public static class Program
{
    public static void Main()
    {
        var classEnumerable = new ClassEnumerable();
        Console.WriteLine($"ClassEnumerable(is IEnumerable<int> = {classEnumerable is IEnumerable<int>})");
        foreach (var item in classEnumerable)
        {
            Console.WriteLine(item);
        }

        var classNotEnumerable = new ClassNotEnumerable();
        Console.WriteLine($"ClassNotEnumerable(is IEnumerable<int> = {classNotEnumerable is IEnumerable<int>})");
        foreach (var item in classNotEnumerable)
        {
            Console.WriteLine(item);
        }

        var structEnumerable = new StructEnumerable();
        Console.WriteLine($"StructEnumerable(is IEnumerable<int> = {structEnumerable is IEnumerable<int>})");
        foreach (var item in structEnumerable)
        {
            Console.WriteLine(item);
        }

        var structNotEnumerable = new StructNotEnumerable();
        Console.WriteLine($"StructNotEnumerable(is IEnumerable<int> = {structNotEnumerable is IEnumerable<int>})");
        foreach (var item in structNotEnumerable)
        {
            Console.WriteLine(item);
        }

        var refStructNotEnumerable = new RefStructNotEnumerable();
        Console.WriteLine($"RefStructNotEnumerable(is IEnumerable<int> = {refStructNotEnumerable is IEnumerable<int>})");
        foreach (var item in refStructNotEnumerable)
        {
            Console.WriteLine(item);
        }
    }
}