namespace PPC.ResourceAccess.PileSource.Contract
{
    using PPC.Utility.DTO;
    using System.Collections.Generic;

    public interface IPileSource
    {
        void SetPileSource(object sourceAccessDescriptor);

        PileSourceCheckResult CheckPileSource(object sourceAccessDescriptor);

        PileDefinition ReadPileDefinition(object sourceAccessDescriptor);

        List<ValidationTile> ReadValidationTiles(object sourceAccessDescriptor);

        List<ExampleTile> ReadExampleTiles(object sourceAccessDescriptor);

        List<ExpertTile> ReadExpertTiles(object sourceAccessDescriptor);

        bool SourceDescriptorTypeIsValid(object sourceDescriptor);

        void CopyValidationTilesWithPrefix(object sourceDescriptor, object targetDescriptor, int pileId);

        void CopyExpertTilesWithPrefix(object sourceDescriptor, object targetDescriptor, int pileId);

        void CopyExampleTilesWithPrefix(object sourceDescriptor, object targetDescriptor, int pileId);
    }
}