namespace VedouciWeb.Models
{
    public class Instructor
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public bool Woman { get; set; }
        public int Id { get; set; }
        public bool Active { get; set; }
        public string Color { get; set; }
        public string Photo { get; set; }
        public bool ShowInList { get; set; }

        public Instructor()
        {

        }
    }
}
