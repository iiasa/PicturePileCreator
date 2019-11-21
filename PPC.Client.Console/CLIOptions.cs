using CommandLine;

namespace PPC.Client.Console
{
    public class CLIOptions
    {
        [Option('s', "source-folder", Required = true, HelpText = "Pass path to folder containing pile information.")]
        public string SourceFolder { get; set; }

        [Option('t', "target-folder", Required = true, HelpText = "Pass path to folder for writing to.")]
        public string TargetFolder { get; set; }

        [Option('d', "definition", Required = false, HelpText = "Set to output pile definition")]
        public bool WritePileDefinition { get; set; }

        [Option('w', "write-tiles", Required = false, HelpText = "Set to output tiles")]
        public bool WriteTiles { get; set; }

        [Option('m', "mediaitem-group", Required = false, HelpText = "Set mediaitem group ID, required with -t option.")]
        public int? MediaItemGroupId { get; set; }

        [Option('p', "pileid", Required = false, HelpText = "Set pile's branch ID, required with -t option.")]
        public int? PileId { get; set; }

        [Option('a', "add-prefix", Required = false, HelpText = "Set to use pile id as prefix for images. This will create a copy of all images in the output directory.")]
        public bool AddPileIdAsPrefix { get; set; }


    }
}