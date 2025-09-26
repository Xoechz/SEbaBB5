using UE2.HashDict.Impl;

namespace UE2.HashDict.Client;

public class Program
{
    public static void Main(string[] args)
    {
        var dict = new HashDictionary<string, int>();
        dict["one"] = 1;
        dict["two"] = 2;
        dict["three"] = 3;
        Console.WriteLine(dict["two"]);
    }
}
