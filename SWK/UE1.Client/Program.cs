using System.CommandLine;
using System.Reflection;
using System.Resources;
using UE1.Library;

namespace UE1.Client;

internal class Program
{
    /// <summary>
    /// Resource management without visual studio is a pain.
    /// </summary>
    private static ResourceManager _resourceManager = new("UE1.Client.Resources.Messages", Assembly.GetExecutingAssembly());
    private static int Main(string[] args)
    {

        Option<int> fromOption = new("--from")
        {
            Aliases = { "-f" },
            Description = _resourceManager.GetString("FromDescription")!,
            Required = false,
            DefaultValueFactory = _ => 0,
            HelpName = "Integer"
        };

        Option<int> toOption = new("--to")
        {
            Aliases = { "-t" },
            Description = _resourceManager.GetString("ToDescription")!,
            Required = false,
            DefaultValueFactory = _ => 100,
            HelpName = "Integer"
        };

        RootCommand rootCommand = new(_resourceManager.GetString("ProgramDescription")!)
        {
            fromOption,
            toOption
        };

        rootCommand.SetAction(parseResult =>
        {
            int from = parseResult.GetValue(fromOption);
            int to = parseResult.GetValue(toOption);
            Run(from, to);

            return 0;
        });

        var parseResult = rootCommand.Parse(args);
        if (parseResult.Errors.Count == 0)
        {
            return parseResult.Invoke();
        }
        else
        {
            Console.WriteLine(_resourceManager.GetString("ParseError")!);
            foreach (var error in parseResult.Errors)
            {
                Console.WriteLine(error.Message);
            }
            return 1;
        }
    }

    private static void Run(int FROM, int TO)
    {
        var primes = new List<int>();
        for (int number = FROM; number <= TO; number++)
        {
            if (PrimeChecker.IsPrime(number))
            {
                primes.Add(number);
            }
        }

        Console.WriteLine(string.Format(_resourceManager.GetString("OutputMessage")!, FROM, TO, string.Join(", ", primes)));
    }
}

