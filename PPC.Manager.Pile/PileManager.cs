using PPC.Engine.Pile;
using PPC.Utility.DTO;

namespace PPC.Manager.Pile
{
    class PileManager : IPileManager
    {
        private IPileEngine pileEngine;

        public IPileEngine PileEngine { get => pileEngine; }

        public PileManager()
        {
            pileEngine = PileEngineFactory.GetPileEngine();
        }

        public ProcessPileDefinitionResult ProcessPileDefinition(object sourceDescriptor, object targetDescriptor)
        {
            if (!pileEngine.SourceDescriptorIsValid(sourceDescriptor)) return ProcessPileDefinitionResult.SourceDescriptorInvalid;
            if (!pileEngine.TargetDescriptorIsValid(targetDescriptor)) return ProcessPileDefinitionResult.TargetDescriptorInvalid;

            PileDefinition pileDefinition = pileEngine.ReadPileDefinition(sourceDescriptor);
            if (pileDefinition == null) return ProcessPileDefinitionResult.PileDefinitionUnreadable;

            bool success = pileEngine.WritePileDefinition(pileDefinition, targetDescriptor);
            if (success == false) return ProcessPileDefinitionResult.FailedWritingPileDefinition;

            return ProcessPileDefinitionResult.Success;
        }

        public ReadTilesResult ProcessTiles(object sourceDescriptor, object targetDescriptor, int pileId, int mediaItemGroupId)
        {
            if (!pileEngine.SourceDescriptorIsValid(sourceDescriptor)) return ReadTilesResult.SourceDescriptorInvalid;
            if (!pileEngine.TargetDescriptorIsValid(targetDescriptor)) return ReadTilesResult.TargetDescriptorInvalid;

            PileDefinition pileDefinition = pileEngine.ReadPileDefinition(sourceDescriptor);
            if (pileDefinition == null) return ReadTilesResult.PileDefinitionUnreadable;

            bool success = pileEngine.WriteTiles(pileDefinition, targetDescriptor, pileId, mediaItemGroupId);
            if (success == false) return ReadTilesResult.FailedWritingTiles;

            return ReadTilesResult.Success;
        }
    }
}
