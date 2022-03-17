namespace VedouciWeb.Models
{
    public class Team
    {
        public List<Together> Together { get; set; }

        public int Year { get; set; }

        private bool[] _genderOkay { get; set; }

        public bool GenderOkay
        {
            get
            {
                return _genderOkay.All(g => g);
            }
        }

        private string _fingerprint = string.Empty;
        public string Fingerprint
        {
            get
            {
                return _fingerprint;
            }
        }

        public Team(int Year, int CountOfTeams = 4)
        {
            this.Together = new List<Together>();

            for (int i = 1; i <= CountOfTeams; i++)
            {
                this.Together.Add(new Together(Year, i));    
            }

            this.Year = Year;
            this._genderOkay = new bool[CountOfTeams];
        }

        public void AddInstructor(int teamNumber, Instructor instructor)
        {
            Together[teamNumber].Instructors.Add(instructor);
            this._genderOkay[teamNumber] = Together[teamNumber].Instructors.Any(i => i.Woman) && Together[teamNumber].Instructors.Any(i => !i.Woman);
        }

        public void RemoveInstructor(int teamNumber, Instructor instructor)
        {
            Together[teamNumber].Instructors.Remove(instructor);
            this._genderOkay[teamNumber] = Together[teamNumber].Instructors.Any(i => i.Woman) && Together[teamNumber].Instructors.Any(i => !i.Woman);
        }


        public string CountFingerpirnt()
        {
            List<string> fingerprints = new List<string>();
            foreach(Together together in this.Together)
            {
                string finger = string.Empty;
                together.Instructors.OrderBy(i => i.Id).ToList().ForEach(i => finger += i.Id.ToString());
                fingerprints.Add(finger);
            }
            this._fingerprint = string.Empty;

            fingerprints.OrderBy(f => f).ToList().ForEach(f => this._fingerprint += f);

            return this._fingerprint;
        }
    }
}
