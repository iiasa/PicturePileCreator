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
            throw new System.NotImplementedException();
        }

        public PileCreationResult WritePileDefinition(object targetAccessDescriptor)
        {
            throw new System.NotImplementedException();
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

        public bool TargetDescriptorIsValid(object targetDescriptor)
        {
            throw new System.NotImplementedException();
        }
    }
}
