namespace Gunter.Core.Constants
{
    public static class IdentificationConstants
    {

        public const string MessagingHelper = "MessagingHelper_1";


        public static class CLASSID
        {
            // Component Class Id's
            public const string GunterSolution = "85ea1aef20de45498e803b9bbee0fed9";
            public const string GunterSolutionFolder = "e6aaecb47a304e099d9b6d92a5219c87";
            public const string GunterProject = "b088aadf1b504d7986e02e183ca354ea";
            public const string GunterProcessor = "78aa7f7c4334432588ef0770ac22c85e";
            public const string GunterInfoItem = "5559ee42713d40db9157da10bb75ecf6";
            public const string GunterInfoSource = "3dc67037c9514d17a6e843d6ea4b1229";
            public const string GunterVisualizationHandler = "a2a37c1887f84b0180024db1286331fe";

            private static Dictionary<string, string> ClassIds = new Dictionary<string, string>
            {
                    { GunterSolution, "GunterSolution" },
                    { GunterSolutionFolder, "GunterSolutionFolder" },
                    { GunterProject, "GunterProject" },
                    { GunterProcessor, "Processor" },
                    { GunterInfoItem, "InfoItem" },
                    { GunterInfoSource, "InfoSource" },
                    { GunterVisualizationHandler , "VisualizationHandler"}
            };

            public static Dictionary<string, string> GetClassIds() => ClassIds;

            public static string ClassIdNameOf(string classId)
            {
                ClassIds.TryGetValue(classId, out var retVal);
                return retVal ?? string.Empty;
            }

        }
    }
}
