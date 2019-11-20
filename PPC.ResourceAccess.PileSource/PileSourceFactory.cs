using PPC.ResourceAccess.PileSource.Contract;
using PPC.ResourceAccess.PileSource.Folder;

namespace PPC.ResourceAccess.PileSource
{
    public static class PileSourceFactory
    {
        public static IPileSource GetPileSource(PileSourceType pileSourceType) 
        {
            switch (pileSourceType) 
            {
                case PileSourceType.Folder:
                    return new FolderPileSource();
                default:
                    return null;
            }
        }
    }
}
