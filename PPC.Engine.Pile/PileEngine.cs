namespace PPC.Engine.Pile
{
    using PPC.ResourceAccess.PileCreationTarget;
    using PPC.ResourceAccess.PileCreationTarget.Contract;
    using PPC.ResourceAccess.PileSource;
    using PPC.ResourceAccess.PileSource.Contract;
    using PPC.Utility.DTO;

    public class PileEngine : IPileEngine
    {
        public IPileSource PileSource { get; private set; }
        public IPileCreationTarget PileCreationTarget { get; private set; }

        public PileEngine()
        {
            PileSource = PileSourceFactory.GetPileSource(PileSourceType.Folder);
            PileCreationTarget = PileCreationTargetFactory.GetPileCreationTarget(PileCreationTargetType.Folder);
        }

        public PileDefinition ReadPileDefinition(object sourceDescriptor)
        {
            PileDefinition pileDefinition = null;
            PileSourceCheckResult pileSourceCheckResult = PileSource.CheckPileSource(sourceDescriptor);

            if (pileSourceCheckResult == PileSourceCheckResult.PileSourceOK)
            {
                pileDefinition = PileSource.ReadPileDefinition(sourceDescriptor);
            }

            return pileDefinition;
        }

        public bool SourceDescriptorIsValid(object sourceDescriptor)
        {
            return PileSource.SourceDescriptorIsValid(sourceDescriptor);
        }

        public bool TargetDescriptorIsValid(object targetDescriptor)
        {
            return PileCreationTarget.TargetDescriptorIsValid(targetDescriptor);
        }

        public bool WritePileDefinition(PileDefinition pileDefinition, object targetDescriptor)
        {
            // TODO: Cleanup pilecreation result enum (split) and don't reuse pileCreationResult
            PileCreationResult pileCreationResult = PileCreationTarget.CheckPileCreationTarget(targetDescriptor);

            if (pileCreationResult == PileCreationResult.Ok)
            {
                pileCreationResult = PileCreationTarget.WritePileDefinition(targetDescriptor);
            }

            return pileCreationResult == PileCreationResult.Ok;
        }

        public bool WriteTiles(PileDefinition pileDefinition, object targetDescriptor, int pileId, int mediaItemGroupId)
        {
            // TODO: Cleanup pilecreation result enum (split) and don't reuse pileCreationResult
            PileCreationResult pileCreationResult = PileCreationTarget.CheckPileCreationTarget(targetDescriptor);

            if (pileCreationResult == PileCreationResult.Ok)
            {
                pileCreationResult = PileCreationTarget.WriteValidationTiles(targetDescriptor, pileId, mediaItemGroupId);
                pileCreationResult = PileCreationTarget.WriteExampleTiles(targetDescriptor, pileId, mediaItemGroupId);
                pileCreationResult = PileCreationTarget.WriteExpertTiles(targetDescriptor, pileId, mediaItemGroupId);
            }

            return pileCreationResult == PileCreationResult.Ok;
        }
    }
}
