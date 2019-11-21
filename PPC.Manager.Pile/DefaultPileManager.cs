using PPC.Engine.Pile;
using PPC.Utility.DTO;

namespace PPC.Manager.Pile
{
    class DefaultPileManager : IPileManager
    {
        private IPileEngine PileEngine { get; }

        public DefaultPileManager()
        {
            PileEngine = PileEngineFactory.GetPileEngine(PileEngineType.Default);
        }

        public ProcessPileDefinitionResult ProcessPileDefinition(object sourceDescriptor, object targetDescriptor)
        {
            if (!PileEngine.SourceDescriptorTypeIsValid(sourceDescriptor)) return ProcessPileDefinitionResult.SourceDescriptorInvalid;
            if (!PileEngine.TargetDescriptorTypeIsValid(targetDescriptor)) return ProcessPileDefinitionResult.TargetDescriptorInvalid;

            PileDefinition pileDefinition = PileEngine.ReadPileDefinition(sourceDescriptor);
            if (pileDefinition == null) return ProcessPileDefinitionResult.PileDefinitionUnreadable;

            bool success = PileEngine.WritePileDefinition(pileDefinition, targetDescriptor);
            if (success == false) return ProcessPileDefinitionResult.FailedWritingPileDefinition;

            return ProcessPileDefinitionResult.Success;
        }

        public ReadTilesResult ProcessTiles(object sourceDescriptor, object targetDescriptor, int pileId, int mediaItemGroupId, bool addTileIdAsPrefix)
        {
            if (!PileEngine.SourceDescriptorTypeIsValid(sourceDescriptor)) return ReadTilesResult.SourceDescriptorInvalid;
            if (!PileEngine.TargetDescriptorTypeIsValid(targetDescriptor)) return ReadTilesResult.TargetDescriptorInvalid;

            PileDefinition pileDefinition = PileEngine.ReadPileDefinition(sourceDescriptor);
            if (pileDefinition == null) return ReadTilesResult.PileDefinitionUnreadable;

            bool success = PileEngine.WriteTiles(pileDefinition, sourceDescriptor, targetDescriptor, pileId, mediaItemGroupId, addTileIdAsPrefix);
            if (success == false) return ReadTilesResult.FailedWritingTiles;

            return ReadTilesResult.Success;
        }
    }
}
