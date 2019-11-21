namespace PPC.Engine.Pile
{
    public static class PileEngineFactory
    {
        public static IPileEngine GetPileEngine(PileEngineType pileEngineType)
        {
            switch (pileEngineType)
            {
                case PileEngineType.Default:
                    return new DefaultPileEngine();
                default:
                    return new DefaultPileEngine();
            }
        }
    }
}
