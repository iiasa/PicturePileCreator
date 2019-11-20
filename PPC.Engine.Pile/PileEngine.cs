using PPC.Utility.DTO;

namespace PPC.Engine.Pile
{
    public class PileEngine : IPileEngine
    {
        public PileDefinition ReadPileDefinition(object sourceDescriptor)
        {
            throw new System.NotImplementedException();
        }

        public bool SourceDescriptorIsValid(object sourceDescriptor)
        {
            throw new System.NotImplementedException();
        }

        public bool TargetDescriptorIsValid(object targetDescriptor)
        {
            throw new System.NotImplementedException();
        }

        public bool WritePileDefinition(PileDefinition pileDefinition, object targetDescriptor)
        {
            throw new System.NotImplementedException();
        }




        public ProcessPileDefinitionResult ProcessPileDefinition(string sourceDescriptor)
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
