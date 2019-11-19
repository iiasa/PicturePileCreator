namespace PPC.Manager.Pile
{
    public interface IPileManager
    {
        public ReadPileDefinitionResult processPileDefinition(object sourceDescriptor);

        public ReadTilesResult processTiles(object sourceDescriptor, int pileId, int mediaItemGroupId);
    }
}
