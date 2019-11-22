using System.Collections.Generic;

namespace PPC.ResourceAccess.PileCreationTarget.Contract
{
    using PPC.Utility.DTO;

    public interface IPileCreationTarget
    {
        PileCreationResult CheckPileCreationTarget(object targetAccessDescriptor);

        PileCreationResult WritePileDefinition(object targetAccessDescriptor, PileDefinition pileDefinition);

        PileCreationResult WriteValidationTiles(object targetAccessDescriptor, List<ValidationTile> tiles, PileDefinition pileDefinition, int pileId, int mediaItemGroupId);

        PileCreationResult WriteExampleTiles(object targetAccessDescriptor, List<ExampleTile> tiles, PileDefinition pileDefinition, int pileId, int mediaItemGroupId);

        PileCreationResult WriteExpertTiles(object targetAccessDescriptor, List<ExpertTile> tiles, PileDefinition pileDefinition, int pileId, int mediaItemGroupId);

        bool TargetDescriptorTypeIsValid(object targetDescriptor);
    }
}