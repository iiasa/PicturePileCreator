using PPC.Engine.Pile;
using PPC.Utility.DTO;

namespace PPC.Manager.Pile
{
    class PileManager : IPileManager
    {
        public IPileEngine PileEngine { get; private set; }

        public PileManager()
        {
            PileEngine = PileEngineFactory.GetPileEngine();
        }

        public ProcessPileDefinitionResult ProcessPileDefinition(object sourceDescriptor, object targetDescriptor)
        {
            if (!PileEngine.SourceDescriptorIsValid(sourceDescriptor)) return ProcessPileDefinitionResult.SourceDescriptorInvalid;
            if (!PileEngine.TargetDescriptorIsValid(targetDescriptor)) return ProcessPileDefinitionResult.TargetDescriptorInvalid;

            PileDefinition pileDefinition = PileEngine.ReadPileDefinition(sourceDescriptor);
            if (pileDefinition == null) return ProcessPileDefinitionResult.PileDefinitionUnreadable;

            bool success = PileEngine.WritePileDefinition(pileDefinition, targetDescriptor);
            if (success == false) return ProcessPileDefinitionResult.FailedWritingPileDefinition;

            return ProcessPileDefinitionResult.Success;
        }

        public ReadTilesResult ProcessTiles(object sourceDescriptor, object targetDescriptor, int pileId, int mediaItemGroupId)
        {
            if (!PileEngine.SourceDescriptorIsValid(sourceDescriptor)) return ReadTilesResult.SourceDescriptorInvalid;
            if (!PileEngine.TargetDescriptorIsValid(targetDescriptor)) return ReadTilesResult.TargetDescriptorInvalid;

            PileDefinition pileDefinition = PileEngine.ReadPileDefinition(sourceDescriptor);
            if (pileDefinition == null) return ReadTilesResult.PileDefinitionUnreadable;

            bool success = PileEngine.WriteTiles(pileDefinition, targetDescriptor, pileId, mediaItemGroupId);
            if (success == false) return ReadTilesResult.FailedWritingTiles;

            return ReadTilesResult.Success;
        }
    }
}
