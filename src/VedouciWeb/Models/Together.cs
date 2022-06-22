namespace VedouciWeb.Models
{
    public class Together
    {
        public List<Instructor> Instructors;
        public int Year;
        public int Weight { get { return 100 / (DateTime.Now.Year - this.Year); } }

        public int TeamNubmer;

        public Together(int year, int number)
        {
            this.Instructors = new List<Instructor>();
            this.Year = year;
            this.TeamNubmer = number;
        }

        public Together(Instructor a, Instructor b, int year, int number)
        {
            this.Instructors = new List<Instructor> { a, b };
            Year = year;
            TeamNubmer = number;
        }

        public Together(Instructor a, Instructor b, Instructor c, int year, int number)
        {
            this.Instructors = new List<Instructor> { a, b , c};
            Year = year;
            TeamNubmer = number;
        }
    }
}
