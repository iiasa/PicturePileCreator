namespace PPC.ResourceAccess.Contract
{
    using System.Collections.Generic;
    using PPC.Utility.DTO;

    public interface IPileSource
    {
        void SetPileSource(string sourceAccessDescriptor);
        PileSourceCheckResult CheckPileSource();
        PileDefinition ReadPileDefinition();
        List<Tile> ReadValidationTiles();
        List<Tile> ReadExampleTiles();
        List<Tile> ReadExpertTiles();
        bool SourceDescriptorIsValid(object sourceDescriptor);
    }
}