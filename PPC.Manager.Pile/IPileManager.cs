namespace PPC.Manager.Pile
{
    public interface IPileManager
    {
        ReadPileDefinitionResult ProcessPileDefinition(object sourceDescriptor);

        ReadTilesResult ProcessTiles(object sourceDescriptor, int pileId, int mediaItemGroupId);
    }
}
