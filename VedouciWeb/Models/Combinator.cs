namespace VedouciWeb.Models
{
    public static class Combinator
    {
        public static int MIN_YEARS_WITHOUT_EACH_OTHER = 3;

        public static List<Instructor> Instructors { get; set; }
        public static List<Together> Together { get; set; }
        public static List<Rule> Rules { get; set; }


        // Settings
        public static bool BoyAndGirl = true;

        public async static Task<List<List<Together>>> MakeCombinations()
        {
            
            var combinationOfInstructors = new List<List<Together>>();
            
            List<Together> workingTeam = new List<Together>
            {
                new Together(DateTime.Now.Year, 1),
                new Together(DateTime.Now.Year, 2),
                new Together(DateTime.Now.Year, 3),
                new Together(DateTime.Now.Year, 4),
            };

            Console.WriteLine("Recurse start");
            CombRecursive(combinationOfInstructors, workingTeam, Instructors.ToArray());
            Console.WriteLine("Recurse finish");

            return combinationOfInstructors;
        }

        private static void CombRecursive(List<List<Together>> combinations, List<Together> workingTeam, ReadOnlySpan<Instructor> availableInstructorStack)
        {
            if (availableInstructorStack.Length == 0)
            {
                if (!CheckTeamValid(workingTeam, combinations))
                    return;

                if (combinations.Count < 100)
                {
                    var teamCombination = new List<Together>{
                        new Together(DateTime.Now.Year, 1),
                        new Together(DateTime.Now.Year, 2),
                        new Together(DateTime.Now.Year, 3),
                        new Together(DateTime.Now.Year, 4),
                    };

                    for (int i = 0; i < 4; i++)
                        workingTeam[i].Instructors.ForEach(inst => teamCombination[i].Instructors.Add(inst));

                    combinations.Add(teamCombination);
                }
            }
            else
            {
                Instructor workingInstructor = availableInstructorStack[0];
                for (int i = 0; i < 4; i++)
                {
                    if (workingTeam[i].Instructors.Count == 3)
                        continue;

                    workingTeam[i].Instructors.Add(workingInstructor);

                    if(!Rules.Any(rule => rule.MatchTheRule(workingTeam[i].Instructors)))
                        CombRecursive(combinations, workingTeam, availableInstructorStack[1..]);

                    workingTeam[i].Instructors.Remove(workingInstructor);
                    //workingTeam[i].Instructors = workingTeam[i].Instructors.Where(ins => ins.Id != workingInstructor.Id).ToList();
                }
            }
        }


        private static bool CheckTeamValid(List<Together> combination, List<List<Together>> combinations)
        {
            if (!CheckTeamCount(combination))
                return false;

            if(BoyAndGirl)
                if (!CheckTeamGender(combination))
                    return false;

            if (!NotTogetherForYear(combination))
                return false;

            if (DuplicateTeam(combination, combinations))
                return false;

            return true;
        }

        private static bool CheckTeamCount(List<Together> combination)
        {
            foreach (var team in combination)
            {
                if (team.Instructors.Count > 3)
                    return false;

                if (team.Instructors.Count < 2)
                    return false;

            }
            return true;
        }

        private static bool CheckTeamGender(List<Together> combination)
        {
            foreach (var team in combination)
            {
                if (!(team.Instructors.Any(i => i.Woman) && team.Instructors.Any(i => !i.Woman)))
                    return false;
            }
            return true;
        }

        private static bool NotTogetherForYear(List<Together> combination)
        {
            foreach (var team in combination)
            {
                for(int i = 0; i < team.Instructors.Count; i++)
                {
                    for(int j = i+1; j < team.Instructors.Count; j++)
                    {
                        var instructor = team.Instructors[i];
                        var instructor2 = team.Instructors[j];

                        int year = Together.Where(t => t.Instructors.Contains(instructor) && t.Instructors.Contains(instructor2)).Max(t => (int?)t.Year) ?? 2000;
                        int yearsWithoutEachOther = DateTime.Now.Year - year;
                        // Console.WriteLine($"{instructor.Name.PadRight(10)} x {instructor2.Name.PadRight(10)} - {year} = {yearsWithoutEachOther}");
                        if (yearsWithoutEachOther < MIN_YEARS_WITHOUT_EACH_OTHER)
                            return false;
                    }
                }
            }

            
            return true;
        }

        private static bool DuplicateTeam(List<Together> combination, List<List<Together>> AlreadyFoundCombinations)
        {
            var currentFingerprint = Fingerprint(combination);

            foreach(var comparatorCombination in AlreadyFoundCombinations)
            {
                int hits = 0;
                var testingFingerprint = Fingerprint(comparatorCombination);
                for(int i = 0; i < currentFingerprint.Count; i++)
                {
                    if(currentFingerprint[i] == testingFingerprint[i])
                        hits++;
                }
                if (hits == 4)
                    return true;
            }

            return false;
        }

        private static List<string> Fingerprint(List<Together> combination)
        {
            return combination.Select(c => TeamFingerprint(c)).OrderBy(s => s).ToList();
        }

        private static string TeamFingerprint(Together team)
        {
            string fingerprint = "";
            team.Instructors.OrderBy(i => i.Id).ToList().ForEach(i => fingerprint += i.Id.ToString());
            return fingerprint;
        }
    }
}
