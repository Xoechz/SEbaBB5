namespace UE1.Basic;

internal class Program
{
    private static void Main(string[] args)
    {
        const int FROM = 1;
        const int TO = 100;

        var primes = new List<int>();
        for (int number = FROM; number <= TO; number++)
        {
            if (PrimeChecker.IsPrime(number))
            {
                primes.Add(number);
            }
        }

        Console.WriteLine($"The prime numbers between {FROM} and {TO} are {string.Join(", ", primes)}");
    }
}