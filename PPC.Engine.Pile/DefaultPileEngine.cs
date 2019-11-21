using System.Collections.Generic;
using System.Collections.Specialized;

namespace PPC.Engine.Pile
{
    using PPC.ResourceAccess.PileCreationTarget;
    using PPC.ResourceAccess.PileCreationTarget.Contract;
    using PPC.ResourceAccess.PileSource;
    using PPC.ResourceAccess.PileSource.Contract;
    using PPC.Utility.DTO;

    public class DefaultPileEngine : IPileEngine
    {
        public IPileSource PileSource { get; private set; }
        public IPileCreationTarget PileCreationTarget { get; private set; }

        public DefaultPileEngine()
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

        public bool SourceDescriptorTypeIsValid(object sourceDescriptor)
        {
            return PileSource.SourceDescriptorTypeIsValid(sourceDescriptor);
        }

        public bool TargetDescriptorTypeIsValid(object targetDescriptor)
        {
            return PileCreationTarget.TargetDescriptorTypeIsValid(targetDescriptor);
        }

        public bool WritePileDefinition(PileDefinition pileDefinition, object targetDescriptor)
        {
            // TODO: Cleanup pilecreation result enum (split) and don't reuse pileCreationResult
            PileCreationResult pileCreationResult = PileCreationTarget.CheckPileCreationTarget(targetDescriptor);

            if (pileCreationResult == PileCreationResult.Ok) // TODO: use proper enum for this!
            {
                pileCreationResult = PileCreationTarget.WritePileDefinition(targetDescriptor, pileDefinition);
            }

            return pileCreationResult == PileCreationResult.Successful;
        }

        public bool WriteTiles(PileDefinition pileDefinition, object sourceDescriptor, object targetDescriptor, int pileId, int mediaItemGroupId, bool addTileIdAsPrefix)
        {
            // TODO: Cleanup pilecreation result enum (split) and don't reuse pileCreationResult
            PileSourceCheckResult pileSourceCheckResult = PileSource.CheckPileSource(sourceDescriptor);
            PileCreationResult pileCreationResult = PileCreationTarget.CheckPileCreationTarget(targetDescriptor);

            if (pileSourceCheckResult == PileSourceCheckResult.PileSourceOK && pileCreationResult == PileCreationResult.Ok)
            { // TODO: properly handle and return each result
                pileCreationResult = WriteValidationTiles(sourceDescriptor, targetDescriptor, pileId, mediaItemGroupId, addTileIdAsPrefix);
                pileCreationResult = WriteExampleTiles(sourceDescriptor, targetDescriptor, pileId, mediaItemGroupId, addTileIdAsPrefix);
                pileCreationResult = WriteExpertTiles(sourceDescriptor, targetDescriptor, pileId, mediaItemGroupId, addTileIdAsPrefix);
            }

            return pileCreationResult == PileCreationResult.Ok;
        }

        private PileCreationResult WriteValidationTiles(object sourceDescriptor, object targetDescriptor, in int pileId, in int mediaItemGroupId, in bool addTileIdAsPrefix)
        {
            List<Tile> tiles = PileSource.ReadValidationTiles(sourceDescriptor);

            if (addTileIdAsPrefix)
            {
                tiles = CopyValidationTiles(sourceDescriptor, targetDescriptor, tiles, pileId);
            }

            //Write sql

            return PileCreationResult.Successful;
        }

        private PileCreationResult WriteExpertTiles(object sourceDescriptor, object targetDescriptor, in int pileId, in int mediaItemGroupId, in bool addTileIdAsPrefix)
        {
            List<Tile> tiles = PileSource.ReadExpertTiles(sourceDescriptor);
            if (addTileIdAsPrefix)
            {
                tiles = CopyExpertTiles(sourceDescriptor, targetDescriptor, tiles, pileId);
            }

            //Write sql

            return PileCreationResult.Successful;
        }

        private PileCreationResult WriteExampleTiles(object sourceDescriptor, object targetDescriptor, in int pileId, in int mediaItemGroupId, in bool addTileIdAsPrefix)
        {
            List<Tile> tiles = PileSource.ReadExampleTiles(sourceDescriptor);
            if (addTileIdAsPrefix)
            {
                tiles = CopyExampleTiles(sourceDescriptor, targetDescriptor, tiles, pileId);
            }

            //Write sql

            return PileCreationResult.Successful;
        }

        private List<Tile> CopyValidationTiles(object sourceDescriptor, object targetDescriptor, List<Tile> tiles, int pileId)
        {
            PileSource.CopyValidationTilesWithPrefix(sourceDescriptor, targetDescriptor, pileId);
            foreach (var tile in tiles)
            {
                tile.filename = $"{pileId}_{tile.filename}";
            }

            return tiles;
        }

        private List<Tile> CopyExpertTiles(object sourceDescriptor, object targetDescriptor, List<Tile> tiles, int pileId)
        {
            PileSource.CopyExpertTilesWithPrefix(sourceDescriptor, targetDescriptor, pileId);
            foreach (var tile in tiles)
            {
                tile.filename = $"{pileId}_{tile.filename}";
            }

            return tiles;
        }

        private List<Tile> CopyExampleTiles(object sourceDescriptor, object targetDescriptor, List<Tile> tiles, int pileId)
        {
            PileSource.CopyExampleTilesWithPrefix(sourceDescriptor, targetDescriptor, pileId);
            foreach (var tile in tiles)
            {
                tile.filename = $"{pileId}_{tile.filename}";
            }

            return tiles;
        }
    }
}