using System.Collections.Generic;
using PPC.ResourceAccess.Contract;
using PPC.ResourceAccess.Pile.DAO;

namespace PPC.ResourceAccess.Pile.FolderAccess
{
    public class FolderPileSource : IPileSource
    {
        public PileSourceCheckResult checkPileSource()
        {
            throw new System.NotImplementedException();
        }

        public List<Tile> readExampleTiles()
        {
            throw new System.NotImplementedException();
        }

        public List<Tile> readExpertTiles()
        {
            throw new System.NotImplementedException();
        }

        public PileDefinition readPileDefinition()
        {
            throw new System.NotImplementedException();
        }

        public List<Tile> readValidationTiles()
        {
            throw new System.NotImplementedException();
        }

        public void setPileSource(string sourceAccessDescriptor)
        {
            throw new System.NotImplementedException();
        }
    }
}
