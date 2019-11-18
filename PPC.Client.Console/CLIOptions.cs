using CommandLine;

namespace PPC_Console_Client
{
    public class CLIOptions
    {
        [Option('v', "verbose", Required = false, HelpText = "Set output to verbose messages.")]
        public bool Verbose { get; set; }

        [Option('f', "folder", Required = true, HelpText = "Pass path to folder containing pile information.")]
        public string Folder { get; set; }
    }
}