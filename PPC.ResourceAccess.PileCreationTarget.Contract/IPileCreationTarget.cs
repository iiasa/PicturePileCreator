namespace PPC.ResourceAccess.PileCreationTarget.Contract
{
    using PPC.Utility.DTO;

    public interface IPileCreationTarget
    {
        void SetPileCreationTarget(object targetAccessDescriptor);

        PileCreationResult CheckPileCreationTarget(object targetAccessDescriptor);
        PileCreationResult WritePileDefinition(object targetAccessDescriptor, PileDefinition pileDefinition);
        PileCreationResult WriteValidationTiles(object targetAccessDescriptor, int pileId, int mediaItemGroupId);
        PileCreationResult WriteExampleTiles(object targetAccessDescriptor, int pileId, int mediaItemGroupId);
        PileCreationResult WriteExpertTiles(object targetAccessDescriptor, int pileId, int mediaItemGroupId);
        bool TargetDescriptorTypeIsValid(object targetDescriptor);
    }
}
