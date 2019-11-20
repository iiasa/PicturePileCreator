using PPC.Engine.Pile;

namespace PPC.Manager.Pile
{
    class PileManager : IPileManager
    {

        public ReadPileDefinitionResult ProcessPileDefinition(object sourceDescriptor)
        {
            if (!(sourceDescriptor is string)) return ReadPileDefinitionResult.SourceDescriptorInvalid; 
            throw new System.NotImplementedException();
        }

        public ReadTilesResult ProcessTiles(object sourceDescriptor, int pileId, int mediaItemGroupId)
        {
            throw new System.NotImplementedException();
        }




        public ReadPileDefinitionResult ProcessPileDefinition(string sourceDescriptor)
        {
            IPileEngine pileEngine = PileEngineFactory.GetPileEngine();


            IPileSource pileSource = new FolderPileSource();


            pileSource.setPileSource(foldername);
            PileSourceCheckResult result = pileSource.checkPileSource();

            if (result == PileSourceCheckResult.PileSourceOK)
            {
                PileDefinition pileDefinition = pileSource.readPileDefinition();

                List<Tile> validationTiles = pileSource.readValidationTiles();
                List<Tile> exampleTiles = pileSource.readExampleTiles();
                List<Tile> expertTiles = pileSource.readExpertTiles();
            }
            else
            {
                // TODO: Output for failed pile source check
            }
        }
    }
}
