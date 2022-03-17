namespace VedouciWeb.Models
{
    public static class Combinator
    {
        public static int MIN_YEARS_WITHOUT_EACH_OTHER = 3;
        public static int MAX_COMPUTE_TIME_SECONDS = 5;

        public static List<Instructor> Instructors { get; set; }
        public static List<Together> Together { get; set; }
        public static List<Rule> Rules { get; set; }


        public static DateTime ComputationStarted { get; set; }
        public static DateTime ComputationFinished { get; set; }
        public static bool ComputationExcited { get; set; }

        // Settings
        public static bool BoyAndGirl = true;


        public async static Task<List<Team>> MakeCombinations()
        {
            ComputationExcited = false;
            var combinationOfInstructors = new List<Team>();

            Team workingTeam = new Team(DateTime.Now.Year, 4);


            ComputationStarted = DateTime.Now;
            Console.WriteLine($"Recurse start  {ComputationStarted.ToString("HH':'mm':'ss.ffff")}");
            CombRecursive(combinationOfInstructors, workingTeam, Instructors.ToArray());
            ComputationFinished = DateTime.Now;
            Console.WriteLine($"Recurse finish {ComputationFinished.ToString("HH':'mm':'ss.ffff")} ({(ComputationFinished - ComputationStarted).TotalMilliseconds})");

            return combinationOfInstructors;
        }

        private static void CombRecursive(List<Team> combinations, Team workingTeam, ReadOnlySpan<Instructor> availableInstructorStack)
        {
            if ((DateTime.Now - ComputationStarted).Seconds >= MAX_COMPUTE_TIME_SECONDS)
            {
                ComputationExcited = true;
                return;
            }

            if (availableInstructorStack.Length == 0)
            {
                if (!CheckTeamValid(workingTeam, combinations))
                    return;

                if (combinations.Count < 100)
                {
                    var teamCombination = new Team(DateTime.Now.Year);

                    for (int i = 0; i < 4; i++)
                        workingTeam.Together[i].Instructors.ForEach(inst => teamCombination.Together[i].Instructors.Add(inst));

                    teamCombination.CountFingerpirnt();
                    combinations.Add(teamCombination);
                }
            }
            else
            {
                Instructor workingInstructor = availableInstructorStack[0];
                for (int i = 0; i < 4; i++)
                {
                    if (workingTeam.Together[i].Instructors.Count == 3)
                        continue;

                    workingTeam.AddInstructor(i, workingInstructor);

                    if (!Rules.Any(rule => rule.MatchTheRule(workingTeam.Together[i].Instructors) && !rule.Together))
                        CombRecursive(combinations, workingTeam, availableInstructorStack[1..]);

                    workingTeam.RemoveInstructor(i, workingInstructor);
                }
            }
        }


        private static bool CheckTeamValid(Team combination, List<Team> combinations)
        {
            if (!CheckTeamCount(combination))
                return false;


            if (BoyAndGirl)
            {
                if (!combination.GenderOkay)
                    return false;
            }

            if (DuplicateTeam(combination, combinations))
                return false;

            if (!CheckMustBeTogether(combination))
                return false;

            return true;
        }

        private static bool CheckMustBeTogether(Team combination)
        {
            foreach (var rule in Rules.Where(r => r.Together))
            {
                if (!combination.Together.Any(t => rule.MatchTheRule(t.Instructors)))
                    return false;
            }

            return true;
        }

        private static bool CheckTeamCount(Team combination)
        {
            foreach (var team in combination.Together)
            {
                if (team.Instructors.Count > 3)
                    return false;

                if (team.Instructors.Count < 2)
                    return false;

            }
            return true;
        }

        private static bool DuplicateTeam(Team combination, List<Team> AlreadyFoundCombinations)
        {
            var currentFingerprint = combination.CountFingerpirnt();
            return AlreadyFoundCombinations.Any(combination => combination.Fingerprint == currentFingerprint);
        }
    }
}
