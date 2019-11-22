using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;

namespace PPC.ResourceAccess.PileSource.Folder
{
    using PPC.ResourceAccess.PileSource.Contract;
    using PPC.Utility.DTO;
    using System.Collections.Generic;

    public class FolderPileSource : IPileSource
    {
        public void SetPileSource(object sourceAccessDescriptor)
        {
            throw new System.NotImplementedException();
        }

        public PileSourceCheckResult CheckPileSource(object sourceAccessDescriptor)
        {
            string folderName = (string)sourceAccessDescriptor;
            if (!Checks.SourceFolderExists(folderName)) return PileSourceCheckResult.PileSourceDoesNotExist;
            if (!Checks.SourceFolderContentStructureIsCorrect(folderName)) return PileSourceCheckResult.PileContentMalformed;
            return PileSourceCheckResult.PileSourceOK;
        }

        public PileDefinition ReadPileDefinition(object sourceAccessDescriptor)
        {
            string fileName = Path.Combine((string)sourceAccessDescriptor, "pileInfo.json"); // TODO: assert format valid
            PileDefinition pileDefinition = null;
            try
            {
                pileDefinition = PileDefinition.FromJson(File.ReadAllText(fileName));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return pileDefinition;
        }

        public List<ValidationTile> ReadValidationTiles(object sourceAccessDescriptor)
        {
            string directory = Path.Combine((string)sourceAccessDescriptor, "ordinary"); // TODO: checks?
            List<string> fileNames =
                GetFileNamesFromDirectory(directory, new[] { "*.jpg", "*.jpeg", "*.png" }, new[] { "_scrsh", "_marked" });
            List<ValidationTile> tiles = fileNames.Select(fileName => new ValidationTile() { filename = fileName }).ToList();
            return tiles;
        }

        private List<string> GetFileNamesFromDirectory(string directory, string[] validExtensions, string[] postfixesToExclude = null)
        {
            List<string> fileNames = new List<string>();
            DirectoryInfo directoryInfo = new DirectoryInfo(directory);

            if (postfixesToExclude == null)
            {
                postfixesToExclude = Array.Empty<string>();
            }

            foreach (var extension in validExtensions)
            {
                var files = directoryInfo.GetFiles(extension);
                fileNames.AddRange(from file in files where !postfixesToExclude.Any(x => Path.GetFileNameWithoutExtension(file.Name).EndsWith(x)) select file.Name);
            }

            return fileNames;
        }

        public List<ExampleTile> ReadExampleTiles(object sourceAccessDescriptor)
        {
            string directory = Path.Combine((string)sourceAccessDescriptor, "example"); // TODO: checks?
            List<string> fileNames =
                GetFileNamesFromDirectory(directory, new[] { "*.jpg", "*.jpeg", "*.png" }, new[] { "_scrsh", "_marked" });

            List<AnswerEntry> answers = ReadAnswerFile(Path.Combine((string)sourceAccessDescriptor, "example_answer.csv"));

            return answers.Select(answer => new ExampleTile() { correctAnswer = answer.AnswerIndo, filename = answer.Filename }).ToList();
        }

        public List<ExpertTile> ReadExpertTiles(object sourceAccessDescriptor)
        {
            string directory = Path.Combine((string)sourceAccessDescriptor, "expert"); // TODO: checks?
            List<string> fileNames =
                GetFileNamesFromDirectory(directory, new[] { "*.jpg", "*.jpeg", "*.png" }, new[] { "_scrsh", "_marked" });

            List<AnswerEntry> answers = ReadAnswerFile(Path.Combine((string)sourceAccessDescriptor, "expert_answer.csv"));

            return answers.Select(answer => new ExpertTile() { correctAnswer = answer.AnswerIndo, filename = answer.Filename }).ToList();
        }

        public bool SourceDescriptorTypeIsValid(object sourceDescriptor)
        {
            return (sourceDescriptor is string);
        }

        public void CopyValidationTilesWithPrefix(object sourceDescriptor, object targetDescriptor, int pileId)
        {
            string directory = Path.Combine((string)sourceDescriptor, "ordinary");
            List<string> fileNames =
                GetFileNamesFromDirectory(directory, new[] { "*.jpg", "*.jpeg", "*.png" });
            string targetDirectory = Path.Combine((string)targetDescriptor, "ordinary");
            Directory.CreateDirectory(targetDirectory);
            foreach (var fileName in fileNames)
            {
                string targetFile = Path.Combine(targetDirectory, $"{pileId}_{fileName}");
                if (File.Exists(targetFile))
                {
                    Console.WriteLine("File exists. skipping: " + targetFile);
                    continue;
                }

                File.Copy(Path.Combine(directory, fileName), targetFile);
            }
        }

        public void CopyExpertTilesWithPrefix(object sourceDescriptor, object targetDescriptor, int pileId)
        {
            string directory = Path.Combine((string)sourceDescriptor, "expert");
            List<string> fileNames =
                GetFileNamesFromDirectory(directory, new[] { "*.jpg", "*.jpeg", "*.png" });
            string targetDirectory = Path.Combine((string)targetDescriptor, "expert");
            Directory.CreateDirectory(targetDirectory);
            foreach (var fileName in fileNames)
            {
                string targetFile = Path.Combine(targetDirectory, $"{pileId}_{fileName}");
                if (File.Exists(targetFile))
                {
                    Console.WriteLine("File exists. skipping: " + targetFile);
                    continue;
                }

                File.Copy(Path.Combine(directory, fileName), Path.Combine(targetDirectory, $"{pileId}_{fileName}"));
            }
        }

        public void CopyExampleTilesWithPrefix(object sourceDescriptor, object targetDescriptor, int pileId)
        {
            string directory = Path.Combine((string)sourceDescriptor, "example");
            List<string> fileNames =
                GetFileNamesFromDirectory(directory, new[] { "*.jpg", "*.jpeg", "*.png" });
            string targetDirectory = Path.Combine((string)targetDescriptor, "example");
            Directory.CreateDirectory(targetDirectory);
            foreach (var fileName in fileNames)
            {
                string targetFile = Path.Combine(targetDirectory, $"{pileId}_{fileName}");
                if (File.Exists(targetFile))
                {
                    Console.WriteLine("File exists. skipping: " + targetFile);
                    continue;
                }

                File.Copy(Path.Combine(directory, fileName), Path.Combine(targetDirectory, $"{pileId}_{fileName}"));
            }
        }

        private List<AnswerEntry> ReadAnswerFile(string path)
        {
            List<AnswerEntry> answers = new List<AnswerEntry>();
            using (TextReader reader = File.OpenText(path))
            {
                CsvReader csv = new CsvReader(reader, new Configuration() { HasHeaderRecord = true, Delimiter = ",", MissingFieldFound = null });

                while (csv.Read())
                {
                    answers.Add(csv.GetRecord<AnswerEntry>());
                }
                csv.Dispose();
            }

            return answers;
        }
    }
}