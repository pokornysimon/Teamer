namespace VedouciWeb.Models
{
    public class Rule
    {
        public List<Instructor> instructors = new List<Instructor>();
        public bool Active = true;

        public Rule(Instructor a, Instructor b)
        {
            instructors.Add(a);
            instructors.Add(b);
        }

        public Rule() { }

        public void CannotBeTogether(Instructor i)
        {
            instructors.Add(i);
        }

        public bool MatchTheRule(List<Instructor> team)
        {
            int hits = 0;
            foreach(Instructor instructor in team)
            {
                if (instructors.Contains(instructor))
                    hits++;
            }
            return hits > 1;
        }

        public bool MatchTheRule(Instructor a, Instructor b)
        {
            return instructors.Contains(a) && instructors.Contains(b);
        }
    }
}
