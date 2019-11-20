namespace PPC.Client.Console
{
    using System;
    using CommandLine;
    using PPC.Manager.Pile;

    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<CLIOptions>(args)
                .WithParsed<CLIOptions>(
                    options =>
                    {
                        IPileManager pileManager = PileManagerFactory.getPileManager();


                        if (options.WritePileDefinition) 
                        {
                            ProcessPileDefinitionResult readPileDefinitionResult = pileManager.ProcessPileDefinition(options.SourceFolder, options.TargetFolder);
                        }
                        else 
                        {
                            Console.WriteLine("Not writing pile definition.");
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
                                options.SourceFolder, options.TargetFolder, (int) options.PileId, (int) options.MediaItemGroupId);
                        }
                        else
                        {
                            Console.WriteLine("Not writing tiles.");
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