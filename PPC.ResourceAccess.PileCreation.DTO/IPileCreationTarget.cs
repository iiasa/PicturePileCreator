namespace PPC.ResourceAccess.PileCreation.DTO
{
    public interface IPileCreationTarget
    {
        public void setPileCreationTarget(object sourceAccessDescriptor);

        public PileCreationResult checkPileCreationTarget();
        public PileCreationResult writePileDefinition();
        public PileCreationResult writeValidationTiles();
        public PileCreationResult writeExampleTiles();
        public PileCreationResult writeExpertTiles();
    }
}
