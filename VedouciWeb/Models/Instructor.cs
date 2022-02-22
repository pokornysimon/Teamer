namespace VedouciWeb.Models
{
    public class Instructor
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public bool Woman { get; set; }
        public int Id { get; set; }
        public bool Active { get; set; }
        public string color { get; set; }

        public Instructor()
        {
            
        }

        public Instructor(string name, int year, bool woman, bool active = true)
        {
            Name = name;
            Year = year;
            Woman = woman;
            active = active;
            Id = Incrementor.Next();
        }
    }
}
