namespace PPC.Engine.Pile
{
    using PPC.Utility.DTO;

    public interface IPileEngine
    {
        PileDefinition ReadPileDefinition(object sourceDescriptor);
        bool SourceDescriptorTypeIsValid(object sourceDescriptor);
        bool TargetDescriptorTypeIsValid(object targetDescriptor);
        bool WritePileDefinition(PileDefinition pileDefinition, object targetDescriptor);
        bool WriteTiles(PileDefinition pileDefinition, object sourceDescriptor, object targetDescriptor, int pileId, int mediaItemGroupId, bool addPileIdAsPrefix);
    }
}
