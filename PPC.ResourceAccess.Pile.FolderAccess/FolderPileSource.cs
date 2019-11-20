namespace PPC.ResourceAccess.PileSource.Folder
{
    using PPC.ResourceAccess.PileSource.Contract;
    using PPC.Utility.DTO;
    using System.Collections.Generic;

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

        public bool SourceDescriptorIsValid(object sourceDescriptor)
        {
            return (sourceDescriptor is string);
        }

        List<Tile> IPileSource.ReadExampleTiles()
        {
            throw new System.NotImplementedException();
        }

        List<Tile> IPileSource.ReadExpertTiles()
        {
            throw new System.NotImplementedException();
        }

        PileDefinition IPileSource.ReadPileDefinition()
        {
            throw new System.NotImplementedException();
        }

        List<Tile> IPileSource.ReadValidationTiles()
        {
            throw new System.NotImplementedException();
        }
    }
}
