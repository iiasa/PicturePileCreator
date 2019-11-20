namespace PPC.ResourceAccess.PileCreationTarget
{
    using PPC.ResourceAccess.PileCreationTarget.Contract;
    using PPC.ResourceAccess.PileCreationTarget.Folder;

    public static class PileCreationTargetFactory
    {
        public static IPileCreationTarget GetPileCreationTarget(PileCreationTargetType pileCreationTargetType)
        {
            switch (pileCreationTargetType)
            {
                case PileCreationTargetType.Folder:
                    return new FolderPileCreationTarget();
                default:
                    return null;
            }
        }
    }
}
