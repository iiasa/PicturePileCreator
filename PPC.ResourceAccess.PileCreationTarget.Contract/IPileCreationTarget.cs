namespace PPC.ResourceAccess.PileCreationTarget.Contract
{
    public interface IPileCreationTarget
    {
        void SetPileCreationTarget(object targetAccessDescriptor);

        PileCreationResult CheckPileCreationTarget(object targetAccessDescriptor);
        PileCreationResult WritePileDefinition(object targetAccessDescriptor);
        PileCreationResult WriteValidationTiles(object targetAccessDescriptor, int pileId, int mediaItemGroupId);
        PileCreationResult WriteExampleTiles(object targetAccessDescriptor, int pileId, int mediaItemGroupId);
        PileCreationResult WriteExpertTiles(object targetAccessDescriptor, int pileId, int mediaItemGroupId);
        bool TargetDescriptorIsValid(object targetDescriptor);
    }
}
