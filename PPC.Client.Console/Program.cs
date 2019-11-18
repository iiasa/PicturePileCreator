using System;
using CommandLine;

namespace PPC_Console_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Parser.Default.ParseArguments<CLIOptions>(args)
                .WithParsed<CLIOptions>(
                    o =>
                    {
                        Console.WriteLine(o.ToString());
                    }
                );
        }
    }
}