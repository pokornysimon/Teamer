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

        public Instructor()
        {
            
        }

        public Instructor(string name, int year, bool woman, string photo = "", bool active = true, string color = "")
        {
            this.Name = name;
            this.Year = year;
            this.Woman = woman;
            this.Photo = photo;
            this.Active = active;
            this.Color = color;
            Id = Incrementor.Next();
        }
    }
}
