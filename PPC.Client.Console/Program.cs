using System;
using System.Collections.Generic;
using CommandLine;
using PPC.ResourceAccess.Contract;
using PPC.ResourceAccess.Pile.DAO;
using PPC.ResourceAccess.Pile.FolderAccess;

namespace PPC_Console_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Picture Pile Creator!");
            Parser.Default.ParseArguments<CLIOptions>(args)
                .WithParsed<CLIOptions>(
                    o =>
                    {
                        string foldername = o.Folder;

                        IPileSource pileSource = new FolderPileSource();
                        pileSource.setPileSource(foldername);
                        PileSourceCheckResult result = pileSource.checkPileSource();

                        if (result == PileSourceCheckResult.PileSourceOK)
                        {
                            PileDefinition pileDefinition = pileSource.readPileDefinition();

                            List<Tile> validationTiles = pileSource.readValidationTiles();
                            List<Tile> exampleTiles = pileSource.readExampleTiles();
                            List<Tile> expertTiles = pileSource.readExpertTiles();
                        }
                        else 
                        {
                            // TODO: Output for failed pile source check
                        }
                    }
                );
        }
    }
}