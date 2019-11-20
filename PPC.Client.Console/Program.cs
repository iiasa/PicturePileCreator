namespace PPC_Console_Client
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
                        string foldername = options.Folder;

                        IPileManager pileManager = PileManagerFactory.getPileManager();


                        if (options.WritePileDefinition) 
                        {
                            ReadPileDefinitionResult readPileDefinitionResult = pileManager.ProcessPileDefinition(foldername);
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
                            ReadTilesResult readTilesResult = pileManager.ProcessTiles(foldername, (int) options.PileId, (int) options.MediaItemGroupId);
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