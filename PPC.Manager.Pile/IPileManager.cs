namespace PPC.Manager.Pile
{
    public interface IPileManager
    {
        ProcessPileDefinitionResult ProcessPileDefinition(object sourceDescriptor, object targetDescriptor);

        ReadTilesResult ProcessTiles(object sourceDescriptor, object targetDescriptor, int pileId, int mediaItemGroupId);
    }
}
