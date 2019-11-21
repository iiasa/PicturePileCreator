using System.IO;

namespace PPC.ResourceAccess.PileSource.Folder
{
    public static class Checks
    {
        public static bool SourceFolderExists(string folderName)
        {
            return Directory.Exists(folderName);
        }

        public static bool PileInfoIsAvailable(string folderName)
        {
            return File.Exists(Path.Combine(folderName, "pileInfo.json"));
        }

        public static bool ExampleAnswersFileIsAvailable(string folderName)
        {
            return File.Exists(Path.Combine(folderName, "example_answer.csv"));
        }

        public static bool ExpertAnswersFileIsAvailable(string folderName)
        {
            return File.Exists(Path.Combine(folderName, "expert_answer.csv"));
        }

        public static bool ValidationTileFolderIsCorrect(string folderName) // TODO: combine the following 3 methods
        {
            string directory = Path.Combine(folderName, "ordinary");
            if (!Directory.Exists(directory)) return false;
            return ImageFolderIsCorrect(directory);
        }

        public static bool ExampleTileFolderIsCorrect(string folderName)
        {
            string directory = Path.Combine(folderName, "example");
            if (!Directory.Exists(directory)) return false;
            return ImageFolderIsCorrect(directory);
        }

        public static bool ExpertTileFolderIsCorrect(string folderName)
        {
            string directory = Path.Combine(folderName, "expert");
            if (!Directory.Exists(directory)) return false;
            return ImageFolderIsCorrect(directory);
        }

        public static bool CheckForAdditionalFiles(string folderName) //TODO: implement and create warnings about additional files
        {
            return true;
        }

        private static bool ImageFolderIsCorrect(string directory) //TODO: implement
        {
            return true;
        }

        public static bool SourceFolderContentStructureIsCorrect(string folderName)
        {
            if (!PileInfoIsAvailable(folderName)) return false;
            if (!ExampleAnswersFileIsAvailable(folderName)) return false;
            if (!ExpertAnswersFileIsAvailable(folderName)) return false;
            if (!ValidationTileFolderIsCorrect(folderName)) return false;
            if (!ExampleTileFolderIsCorrect(folderName)) return false;
            if (!ExpertTileFolderIsCorrect(folderName)) return false;
            CheckForAdditionalFiles(folderName);
            return true;
        }
    }
}