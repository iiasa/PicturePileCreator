using PPC.ResourceAccess.Pile.FolderAccess;

namespace PPC.ResourceAccess.Contract
{
    public class PileSourceFactory
    {
        public IPileSource GetPileSource(PileSourceType pileSourceType) 
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
