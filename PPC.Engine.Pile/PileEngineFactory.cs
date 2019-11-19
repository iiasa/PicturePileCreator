namespace PPC.Engine.Pile
{
    public class PileEngineFactory
    {
        public static IPileEngine GetPileEngine() 
        {
            return new PileEngine();
        }
    }
}
