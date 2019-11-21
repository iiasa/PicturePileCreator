using System;
using System.IO;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using PPC.Utility.DTO;

namespace PPC.ResourceAccess.PileCreationTarget.Folder
{
    using PPC.ResourceAccess.PileCreationTarget.Contract;

    public class FolderPileCreationTarget : IPileCreationTarget
    {
        public void SetPileCreationTarget(object targetAccessDescriptor)
        {
            throw new System.NotImplementedException();
        }

        public PileCreationResult CheckPileCreationTarget(object targetAccessDescriptor)
        {
            string folderName = (string) targetAccessDescriptor;
            if (!Directory.Exists(folderName)) return  PileCreationResult.InvalidAccessor;
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

        public PileCreationResult WriteValidationTiles(object targetAccessDescriptor, int pileId, int mediaItemGroupId)
        {
            throw new System.NotImplementedException();
        }

        public PileCreationResult WriteExampleTiles(object targetAccessDescriptor, int pileId, int mediaItemGroupId)
        {
            throw new System.NotImplementedException();
        }

        public PileCreationResult WriteExpertTiles(object targetAccessDescriptor, int pileId, int mediaItemGroupId)
        {
            throw new System.NotImplementedException();
        }

        public bool TargetDescriptorTypeIsValid(object targetDescriptor)
        {
            return (targetDescriptor is string);
        }
    }
}
