namespace PPC.Client.Console
{
    using CommandLine;
    using PPC.Manager.Pile;
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<CLIOptions>(args)
                .WithParsed<CLIOptions>(
                    options =>
                    {
                        IPileManager pileManager = PileManagerFactory.GetPileManager(PileManagerType.Default);


                        if (options.WritePileDefinition)
                        {
                            ProcessPileDefinitionResult readPileDefinitionResult = pileManager.ProcessPileDefinition(options.SourceFolder, options.TargetFolder);
                        }
                        else
                        {
                            Console.WriteLine("Not writing pile definition. (use switch -d to produce pile definition output)");
                        }

                        if (options.WriteTiles)
                        {
                            if (options.PileId == null)
                            {
                                Console.WriteLine("You did not specify a pile id. For creating tile inserts this is necessary. Please consult the --help for further information.");
                                return;
                            }
                            if (options.MediaItemGroupId == null)
                            {
                                Console.WriteLine("You did not specify a mediaitem group id. For creating tile inserts this is necessary. Please consult the --help for further information.");
                                return;
                            }
                            ReadTilesResult readTilesResult = pileManager.ProcessTiles(
                                options.SourceFolder, options.TargetFolder, (int)options.PileId, (int)options.MediaItemGroupId, options.AddPileIdAsPrefix);
                        }
                        else
                        {
                            Console.WriteLine("Not writing tiles. (use switch -w to produce tile output)");
                        }
                    })
                .WithNotParsed(
                    errors =>
                    {
                        Console.WriteLine("Parsing parameters has failed due to the following problem(s):");
                        foreach (var error in errors)
                        {
                            Console.WriteLine(error.ToString());
                        }
                    });
        }
    }
}