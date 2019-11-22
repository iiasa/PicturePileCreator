using System.Linq;

namespace PPC.ResourceAccess.PileCreationTarget.Folder
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Runtime.InteropServices.WindowsRuntime;
    using PPC.Utility.DTO;
    using PPC.ResourceAccess.PileCreationTarget.Contract;

    public class FolderPileCreationTarget : IPileCreationTarget
    {
        public PileCreationResult CheckPileCreationTarget(object targetAccessDescriptor)
        {
            string folderName = (string)targetAccessDescriptor;
            if (!Directory.Exists(folderName)) return PileCreationResult.InvalidAccessor;
            return PileCreationResult.Ok; // TODO: Use the proper enum for this!
        }

        public PileCreationResult WritePileDefinition(object targetAccessDescriptor, PileDefinition pileDefinition)
        {
            string folderName = (string)targetAccessDescriptor;
            string targetFileName = Path.Combine(folderName, "insert_pile_definition.sql");
            try
            {
                if (pileDefinition != null) File.WriteAllText(targetFileName, pileDefinition.SqlInsert);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return PileCreationResult.WritingPileDefinitionFailed;
            }

            return PileCreationResult.Successful;
        }

        public PileCreationResult WriteValidationTiles(object targetAccessDescriptor, List<ValidationTile> tiles, PileDefinition pileDefinition, int pileId, int mediaItemGroupId)
        {
            string targetFile = Path.Combine((string)targetAccessDescriptor, "insert_validation_tiles.sql");
            List<string> inserts = tiles.Select(validationTile => $"select from public.gw_insert_urundata_tile('{validationTile.filename}', {mediaItemGroupId}, {pileId});").ToList();

            try
            {
                File.WriteAllLines(targetFile, inserts);
            }
            catch (Exception e)
            {
                return PileCreationResult.WritingPileTilesFailed;
            }

            return PileCreationResult.Successful;
        }

        public PileCreationResult WriteExampleTiles(object targetAccessDescriptor, List<ExampleTile> tiles, PileDefinition pileDefinition, int pileId, int mediaItemGroupId)
        {
            string targetFile = Path.Combine((string)targetAccessDescriptor, "insert_example_tiles.sql");
            List<string> inserts = tiles.Select(validationTile => $"select from public.gw_insert_urundata_example_tile('{validationTile.filename}', {mediaItemGroupId}, {pileId}, {pileDefinition.GetAnswerId(validationTile.correctAnswer)});").ToList();

            try
            {
                File.WriteAllLines(targetFile, inserts);
            }
            catch (Exception e)
            {
                return PileCreationResult.WritingPileTilesFailed;
            }

            return PileCreationResult.Successful;
        }

        public PileCreationResult WriteExpertTiles(object targetAccessDescriptor, List<ExpertTile> tiles, PileDefinition pileDefinition, int pileId, int mediaItemGroupId)
        {
            string targetFile = Path.Combine((string)targetAccessDescriptor, "insert_expert_tiles.sql");
            List<string> inserts = tiles.Select(validationTile => $"select from public.gw_insert_urundata_expert_tile('{validationTile.filename}', {mediaItemGroupId}, {pileId}, {pileDefinition.GetAnswerId(validationTile.correctAnswer)});").ToList();

            try
            {
                File.WriteAllLines(targetFile, inserts);
            }
            catch (Exception e)
            {
                return PileCreationResult.WritingPileTilesFailed;
            }

            return PileCreationResult.Successful;
        }

        public bool TargetDescriptorTypeIsValid(object targetDescriptor)
        {
            return (targetDescriptor is string);
        }
    }
}