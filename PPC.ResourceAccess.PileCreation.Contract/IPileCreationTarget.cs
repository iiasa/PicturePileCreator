namespace PPC.ResourceAccess.PileCreation.Contract
{
    public interface IPileCreationTarget
    {
        void SetPileCreationTarget(object sourceAccessDescriptor);

        PileCreationResult CheckPileCreationTarget();
        PileCreationResult WritePileDefinition();
        PileCreationResult WriteValidationTiles();
        PileCreationResult WriteExampleTiles();
        PileCreationResult WriteExpertTiles();
    }
}
