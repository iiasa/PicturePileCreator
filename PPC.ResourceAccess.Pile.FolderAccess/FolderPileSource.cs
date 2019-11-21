namespace PPC.ResourceAccess.PileSource.Folder
{
    using PPC.ResourceAccess.PileSource.Contract;
    using PPC.Utility.DTO;
    using System.Collections.Generic;

    public class FolderPileSource : IPileSource
    {
        public void SetPileSource(object sourceAccessDescriptor)
        {
            throw new System.NotImplementedException();
        }

        public PileSourceCheckResult CheckPileSource(object sourceAccessDescriptor)
        {
            throw new System.NotImplementedException();
        }

        public PileDefinition ReadPileDefinition(object sourceAccessDescriptor)
        {
            string fileName = (string) sourceAccessDescriptor; // TODO: assert format valid
            
            return null;
        }

        public List<Tile> ReadValidationTiles(object sourceAccessDescriptor)
        {
            throw new System.NotImplementedException();
        }

        public List<Tile> ReadExampleTiles(object sourceAccessDescriptor)
        {
            throw new System.NotImplementedException();
        }

        public List<Tile> ReadExpertTiles(object sourceAccessDescriptor)
        {
            throw new System.NotImplementedException();
        }

        public bool SourceDescriptorIsValid(object sourceDescriptor)
        {
            throw new System.NotImplementedException();
        }
    }
}
