using System.Collections.Generic;
using PPC.Utility.DTO;

namespace PPC.ResourceAccess.Contract
{
    public interface IPileSource
    {
        void SetPileSource(string sourceAccessDescriptor);
        PileSourceCheckResult CheckPileSource();
        PileDefinition ReadPileDefinition();
        List<Tile> ReadValidationTiles();
        List<Tile> ReadExampleTiles();
        List<Tile> ReadExpertTiles();
    }
}