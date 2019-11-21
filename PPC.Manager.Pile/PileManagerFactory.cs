namespace PPC.Manager.Pile
{
    public static class PileManagerFactory
    {
        public static IPileManager GetPileManager(PileManagerType pileManagerType)
        {
            switch (pileManagerType)
            {
                case PileManagerType.Default:
                    return new DefaultPileManager();
                default:
                    return new DefaultPileManager();
            }
        }
    }
}
