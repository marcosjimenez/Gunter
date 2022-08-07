using Gunter.Core.Infrastructure.Exceptions;
using Gunter.Core.Infrastructure.Helpers;
using Gunter.Core.Solutions.Models;
using Gunter.Core.Solutions.Models.SavedComponent;
using System.Diagnostics;
using System.Text.Json;

namespace Gunter.Core.Solutions
{
    public class GunterSolutionHelper
    {

        private static readonly Lazy<GunterSolutionHelper> lazy = new(() => new GunterSolutionHelper());
        public static GunterSolutionHelper Instance { get => lazy.Value; }

        public GunterSolution NewSolution()
        => new GunterSolution();

        public bool SaveSolution(GunterSolution solution)
        {
            if (string.IsNullOrWhiteSpace(solution.FileName) || string.IsNullOrWhiteSpace(solution.FileName))
                return false;

            return SaveSolutionAs(solution, solution.FileName);
        }

        public bool SaveSolutionAs(GunterSolution solutionToSave, string fileName)
        {
            var solution = GetSolutionToSave(solutionToSave);

            try
            {
                var json = JsonSerializer.Serialize(solution, getJsonSerializerOptions());
                File.WriteAllText(fileName, json);
            }
            catch (Exception ex)
            {
                throw new GunterSolutionException($"Error serializing  / writing {fileName}", ex);
            }

            return true;
        }

        public GunterSolution OpenSolution(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new GunterSolutionException($"Cannot find file { fileName }");
            }

            try
            {
                var json = File.ReadAllText(fileName);
                var solution = JsonSerializer.Deserialize<GunterSavedSolution>(json, getJsonSerializerOptions());
                if (solution is null)
                    throw new InvalidCastException("Invalid file");

                return GetSolutionFromSave(solution); ;
            }
            catch (Exception ex)
            {
                throw new GunterSolutionException($"Error reading file {fileName}", ex);
            }
        }

        private GunterSolution GetSolutionFromSave(GunterSavedSolution solution)
        {
            var retVal = new GunterSolution
            {
                Id = solution.Id,
                Name = solution.Name,
                FileName = solution.FileName,
                FilePath = solution.FilePath
            };

            foreach (var folder in solution.Folders)
                retVal.AddFolder(folder);

            foreach (var project in solution.SavedProjects)
            {
                var newProject = new GunterProject(project.Id, project.Name, project.FolderId);
                foreach (var processor in project.SavedProcessors)
                    newProject.AddProcessor(GunterSavedProcessor.ToProcessor(processor));

                retVal.Projects.Add(newProject);
            }

            return retVal;
        }

        private GunterSavedSolution GetSolutionToSave(GunterSolution solution)
        {
            var retVal = new GunterSavedSolution
            {
                Id = solution.Id,
                Name = solution.Name,
                FileName = solution.FileName,
                FilePath = solution.FilePath
            };

            foreach (var folder in solution.Folders)
                retVal.AddFolder(folder);

            foreach (var project in solution.Projects)
            {
                var newProject = new GunterSavedProject
                {
                    Id = project.Id,
                    FolderId = project.FolderId,
                    Name = project.Name
                };
                foreach (var processor in project.Processors)
                    newProject.SavedProcessors.Add(GunterSavedProcessor.FromProcessor(processor));

                retVal.SavedProjects.Add(newProject);
            }

            return retVal;
        }

        private JsonSerializerOptions getJsonSerializerOptions() => new JsonSerializerOptions
        {
            WriteIndented = true
        };
    }
}
