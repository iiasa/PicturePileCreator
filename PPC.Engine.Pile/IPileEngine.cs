namespace PPC.Engine.Pile
{
    using PPC.Utility.DTO;

    public interface IPileEngine
    {
        PileDefinition ReadPileDefinition(object sourceDescriptor);
        bool SourceDescriptorIsValid(object sourceDescriptor);
        bool TargetDescriptorIsValid(object targetDescriptor);
        bool WritePileDefinition(PileDefinition pileDefinition, object targetDescriptor);
        bool WriteTiles(PileDefinition pileDefinition, object targetDescriptor, int pileId, int mediaItemGroupId);
    }
}
