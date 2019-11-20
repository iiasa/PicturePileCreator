namespace PPC.ResourceAccess.PileSource.Contract
{
    using System.Collections.Generic;
    using PPC.Utility.DTO;

    public interface IPileSource
    {
        void SetPileSource(object sourceAccessDescriptor);
        PileSourceCheckResult CheckPileSource(object sourceAccessDescriptor);
        PileDefinition ReadPileDefinition(object sourceAccessDescriptor);
        List<Tile> ReadValidationTiles(object sourceAccessDescriptor);
        List<Tile> ReadExampleTiles(object sourceAccessDescriptor);
        List<Tile> ReadExpertTiles(object sourceAccessDescriptor);
        bool SourceDescriptorIsValid(object sourceDescriptor);
    }
}