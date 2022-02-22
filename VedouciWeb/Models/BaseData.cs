namespace VedouciWeb.Models
{
    public static class BaseData
    {
        public static List<Instructor> Instructors { get; set; }
        public static List<Together> Togethers { get; set; }
        public static List<Rule> Rules { get; set; }

        public static void DefaultConfig()
        {
            Instructors = new List<Instructor>();
            Togethers = new List<Together>();
            Rules = new List<Rule>();

            var simon = new Instructor()
            {
                Id = 1,
                Name = "Šimon",
                Active = true,
                Woman = false,
                Year = 2014
            };
            Instructors.Add(simon);

            var fanda = new Instructor()
            {
                Id = 2,
                Name = "Fanda",
                Active = true,
                Woman = false,
                Year = 2013
            };
            Instructors.Add(fanda);

            var jolka = new Instructor()
            {
                Id = 3,
                Name = "Jolka",
                Active = true,
                Woman = true,
                Year = 2014
            };
            Instructors.Add(jolka);

            var blaza = new Instructor()
            {
                Id = 4,
                Name = "Bláža",
                Active = true,
                Woman = false,
                Year = 2014
            };
            Instructors.Add(blaza);

            var misa = new Instructor()
            {
                Id = 5,
                Name = "Míša",
                Active = true,
                Woman = true,
                Year = 2014
            };
            Instructors.Add(misa);

            var kubam = new Instructor()
            {
                Id = 6,
                Name = "KubaM",
                Active = true,
                Woman = false,
                Year = 2017

            };
            Instructors.Add(kubam);

            var filip = new Instructor()
            {
                Id = 7,
                Name = "Filip",
                Active = true,
                Woman = false,
                Year = 2018
            };
            Instructors.Add(filip);

            var kubaj = new Instructor()
            {
                Id = 8,
                Name = "KubaJ",
                Active = true,
                Woman = false,
                Year = 2018
            };
            Instructors.Add(kubaj);

            var julca = new Instructor()
            {
                Id = 9,
                Name = "Julča",
                Active = true,
                Woman = true,
                Year = 2020
            };
            Instructors.Add(julca);

            var ancad = new Instructor()
            {
                Id = 10,
                Name = "AnčaD",
                Active = true,
                Woman = true,
                Year = 2020
            };
            Instructors.Add(ancad);

            var krna = new Instructor()
            {
                Id = 11,
                Name = "Krňa",
                Active = true,
                Woman = true,
                Year = 2013
            };
            Instructors.Add(krna);

            var tonda = new Instructor()
            {
                Id = 12,
                Name = "Tonda",
                Active = false,
                Woman = false,
                Year = 2010
            };
            Instructors.Add(tonda);

            var nikca = new Instructor()
            {
                Id = 13,
                Name = "Nikča",
                Active = false,
                Woman = true,
                Year = 2017
            };
            Instructors.Add(nikca);

            var jirka = new Instructor()
            {
                Id = 14,
                Name = "Jirka",
                Active = false,
                Woman = false,
                Year = 2010
            };
            Instructors.Add(jirka);

            var julcaG = new Instructor()
            {
                Id = 15,
                Name = "JulčaG",
                Active = false,
                Woman = true,
                Year = 2017
            };
            Instructors.Add(julcaG);

            var ivca = new Instructor()
            {
                Id = 16,
                Name = "Ivča",
                Active = false,
                Woman = true,
                Year = 2014
            };
            Instructors.Add(ivca);

            var evca = new Instructor()
            {
                Id = 17,
                Name = "Evča",
                Active = false,
                Woman = true,
                Year = 2010
            };
            Instructors.Add(evca);

            var betka = new Instructor()
            {
                Id = 19,
                Name = "Betka",
                Active = false,
                Woman = true,
                Year = 2016
            };
            Instructors.Add(betka);

            var andy = new Instructor()
            {
                Id = 20,
                Name = "Andy",
                Active = false,
                Woman = true,
                Year = 2013
            };
            Instructors.Add(andy);

            var ancas = new Instructor()
            {
                Id = 21,
                Name = "AnčaS",
                Active = false,
                Woman = true,
                Year = 2013
            };
            Instructors.Add(ancas);

            var alex = new Instructor()
            {
                Id = 22,
                Name = "Alex",
                Active = false,
                Woman = false,
                Year = 2014
            };
            Instructors.Add(alex);

            var ajka = new Instructor()
            {
                Id = 23,
                Name = "Ajka",
                Active = false,
                Woman = true,
                Year = 2010
            };
            Instructors.Add(ajka);

            var novy1 = new Instructor()
            {
                Id = 24,
                Name = "Nový",
                Active = false,
                Woman = true,
                Year = 2022
            };
            Instructors.Add(novy1);


            // 2021
            Togethers.Add(new Together(jolka, filip, 2021, 1));
            Togethers.Add(new Together(misa, kubaj, 2021, 2));
            Togethers.Add(new Together(blaza, kubam, julca, 2021, 3));
            Togethers.Add(new Together(simon, fanda, ancad, 2021, 4));


            // 2020
            Togethers.Add(new Together(blaza, misa, 2020, 1));
            Togethers.Add(new Together(krna, kubaj, ancad, 2020, 2));
            Togethers.Add(new Together(fanda, jolka, kubam, 2020, 3));
            Togethers.Add(new Together(simon, filip, julca, 2020, 4));

            // 2019
            Togethers.Add(new Together(tonda, misa, filip, 2019, 1));
            Togethers.Add(new Together(jirka, fanda, kubaj, 2019, 2));
            Togethers.Add(new Together(simon, jolka, 2019, 3));
            Togethers.Add(new Together(krna, blaza, 2019, 4));

            //2018
            Togethers.Add(new Together(tonda, krna, kubam, 2018, 1));
            Togethers.Add(new Together(simon, misa, nikca, 2018, 2));
            Togethers.Add(new Together(jirka, jolka, 2018, 3));
            Togethers.Add(new Together(ivca, blaza, 2018, 4));

            // 2017
            Togethers.Add(new Together(tonda, nikca, 2017, 1));
            Togethers.Add(new Together(jirka, julcaG, misa, 2017, 2));
            Togethers.Add(new Together(krna, fanda, 2017, 3));
            Togethers.Add(new Together(simon, jolka, blaza, 2017, 4));

            // 2016
            Togethers.Add(new Together(jirka, evca, betka, 2016, 1));
            Togethers.Add(new Together(ivca, blaza, misa, 2016, 2));
            Togethers.Add(new Together(simon, krna, 2016, 3));
            Togethers.Add(new Together(tonda, fanda, jolka, 2016, 4));

            // 2015
            Togethers.Add(new Together(fanda, andy, 2015, 1));
            Togethers.Add(new Together(simon, evca, 2015, 2));
            Togethers.Add(new Together(tonda, krna, 2015, 3));
            Togethers.Add(new Together(jirka, ivca, 2015, 4));

            // 2014
            Togethers.Add(new Together(tonda, simon, 2014, 1));
            Togethers.Add(new Together(evca, ancas, alex, 2014, 2));
            Togethers.Add(new Together(jirka, krna, ivca, 2014, 3));
            Togethers.Add(new Together(ajka, fanda, 2014, 4));


            // Rules
            Rules.Add(new Rule(simon, jolka));
            Rules.Add(new Rule(simon, fanda));
            Rules.Add(new Rule(simon, misa));
            Rules.Add(new Rule(jolka, fanda));
        }

    }
}
