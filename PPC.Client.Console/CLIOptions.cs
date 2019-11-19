using CommandLine;

namespace PPC_Console_Client
{
    public class CLIOptions
    {
        /*
        [Option('v', "verbose", Required = false, HelpText = "Set output to verbose messages.")]
        public bool Verbose { get; set; }
        */


        [Option('f', "folder", Required = true, HelpText = "Pass path to folder containing pile information.")]
        public string Folder { get; set; }

        [Option('d', "definition", Required = false, HelpText = "Set to output pile definition")]
        public bool WritePileDefinition { get; set; }

        [Option('t', "tiles", Required = false, HelpText = "Set to output tiles")]
        public bool WriteTiles { get; set; }

        [Option('m', "mediaitemgroup", Required = false, HelpText = "Set mediaitem group ID, required with -t option.")]
        public int? MediaItemGroupId { get; set; }

        [Option('p', "pileid", Required = false, HelpText = "Set pile's branch ID, required with -t option.")]
        public int? PileId { get; set; }
    }
}