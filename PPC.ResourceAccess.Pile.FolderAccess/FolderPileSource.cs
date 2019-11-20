namespace PPC.ResourceAccess.Pile.FolderAccess
{
    using System.Collections.Generic;
    using PPC.ResourceAccess.Contract;
    using PPC.Utility.DTO;

    public class FolderPileSource : IPileSource
    {
        public PileSourceCheckResult CheckPileSource()
        {
            throw new System.NotImplementedException();
        }

        public List<Tile> ReadExampleTiles()
        {
            throw new System.NotImplementedException();
        }

        public List<Tile> ReadExpertTiles()
        {
            throw new System.NotImplementedException();
        }

        public PileDefinition ReadPileDefinition()
        {
            throw new System.NotImplementedException();
        }

        public List<Tile> ReadValidationTiles()
        {
            throw new System.NotImplementedException();
        }

        public void SetPileSource(string sourceAccessDescriptor)
        {
            throw new System.NotImplementedException();
        }
    }
}
