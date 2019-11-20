namespace PPC.ResourceAccess.PileCreationTarget.Contract
{
    public interface IPileCreationTarget
    {
        void SetPileCreationTarget(object sourceAccessDescriptor);

        PileCreationResult CheckPileCreationTarget();
        PileCreationResult WritePileDefinition();
        PileCreationResult WriteValidationTiles();
        PileCreationResult WriteExampleTiles();
        PileCreationResult WriteExpertTiles();
        bool TargetDescriptorIsValid(object targetDescriptor);
    }
}
