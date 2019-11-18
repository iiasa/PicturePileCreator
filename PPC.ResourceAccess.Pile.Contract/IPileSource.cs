using System.Collections.Generic;
using PPC.ResourceAccess.Pile.DAO;

namespace PPC.ResourceAccess.Contract
{
    public interface IPileSource
    {
        void setPileSource(string sourceAccessDescriptor);
        PileSourceCheckResult checkPileSource();
        PileDefinition readPileDefinition();
        List<Tile> readValidationTiles();
        List<Tile> readExampleTiles();
        List<Tile> readExpertTiles();
    }
}