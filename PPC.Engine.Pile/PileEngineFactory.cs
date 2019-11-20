namespace PPC.Engine.Pile
{
    public static class PileEngineFactory
    {
        public static IPileEngine GetPileEngine()
        {
            return new PileEngine();
        }
    }
}
