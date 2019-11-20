namespace PPC.Manager.Pile
{
    public static class PileManagerFactory
    {
        public static IPileManager getPileManager()
        {
            return new PileManager();
        }
    }
}
