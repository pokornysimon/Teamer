﻿namespace VedouciWeb.Models
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
                Year = 2014,
                Photo = "/img/simon.png",
                ShowInList = true
            };
            Instructors.Add(simon);

            var fanda = new Instructor()
            {
                Id = 2,
                Name = "Fanda",
                Active = true,
                Woman = false,
                Year = 2014,
                Photo = "/img/fanda.png",
                ShowInList = true
            };
            Instructors.Add(fanda);

            var jolka = new Instructor()
            {
                Id = 3,
                Name = "Jolka",
                Active = false,
                Woman = true,
                Year = 2016,
                Photo = "/img/jolka.png",
                ShowInList = true
            };
            Instructors.Add(jolka);

            var blaza = new Instructor()
            {
                Id = 4,
                Name = "Bláža",
                Active = true,
                Woman = false,
                Year = 2016,
                Photo = "/img/blaza.png",
                ShowInList = true
            };
            Instructors.Add(blaza);

            var misa = new Instructor()
            {
                Id = 5,
                Name = "Míša",
                Active = false,
                Woman = true,
                Year = 2016,
                Photo = "/img/misa.png",
                ShowInList = true
            };
            Instructors.Add(misa);

            var kubam = new Instructor()
            {
                Id = 6,
                Name = "KubaM",
                Active = true,
                Woman = false,
                Year = 2018,
                Photo = "/img/kubam.png",
                ShowInList = true

            };
            Instructors.Add(kubam);

            var filip = new Instructor()
            {
                Id = 7,
                Name = "Filip",
                Active = false,
                Woman = false,
                Year = 2019,
                Photo = "/img/filip.png",
                ShowInList = true
            };
            Instructors.Add(filip);

            var kubaj = new Instructor()
            {
                Id = 8,
                Name = "KubaJ",
                Active = false,
                Woman = false,
                Year = 2019,
                Photo = "/img/kubaj.png",
                ShowInList = true
            };
            Instructors.Add(kubaj);

            var julca = new Instructor()
            {
                Id = 9,
                Name = "Julča",
                Active = true,
                Woman = true,
                Year = 2020,
                Photo = "/img/julca.png",
                ShowInList = true
            };
            Instructors.Add(julca);

            var ancad = new Instructor()
            {
                Id = 10,
                Name = "AnčaD",
                Active = true,
                Woman = true,
                Year = 2020,
                Photo = "/img/ancad.png",
                ShowInList = true
            };
            Instructors.Add(ancad);

            var krna = new Instructor()
            {
                Id = 11,
                Name = "Krňa",
                Active = false,
                Woman = false,
                Year = 2013,
                Photo = "/img/krna.png",
                ShowInList = false
            };
            Instructors.Add(krna);

            var tonda = new Instructor()
            {
                Id = 12,
                Name = "Tonda",
                Active = false,
                Woman = false,
                Year = 2010,
                Photo = "/img/tonda.png",
                ShowInList = false
            };
            Instructors.Add(tonda);

            var nikca = new Instructor()
            {
                Id = 13,
                Name = "Nikča",
                Active = false,
                Woman = true,
                Year = 2017,
                Photo = "/img/nikca.png",
                ShowInList = false
            };
            Instructors.Add(nikca);

            var jirka = new Instructor()
            {
                Id = 14,
                Name = "Jirka",
                Active = false,
                Woman = false,
                Year = 2010,
                Photo = "/img/jirka.png",
                ShowInList = true
            };
            Instructors.Add(jirka);

            var julcaG = new Instructor()
            {
                Id = 15,
                Name = "JulčaG",
                Active = false,
                Woman = true,
                Year = 2017,
                Photo = "/img/julcag.png",
                ShowInList = false
            };
            Instructors.Add(julcaG);

            var ivca = new Instructor()
            {
                Id = 16,
                Name = "Ivča",
                Active = false,
                Woman = true,
                Year = 2014,
                Photo = "/img/ivca.png",
                ShowInList = false
            };
            Instructors.Add(ivca);

            var evca = new Instructor()
            {
                Id = 17,
                Name = "Evča",
                Active = false,
                Woman = true,
                Year = 2010,
                Photo = "/img/evca.png",
                ShowInList = false
            };
            Instructors.Add(evca);

            var betka = new Instructor()
            {
                Id = 18,
                Name = "Betka",
                Active = false,
                Woman = true,
                Year = 2016,
                Photo = "/img/betka.png",
                ShowInList = false
            };
            Instructors.Add(betka);

            var andy = new Instructor()
            {
                Id = 19,
                Name = "Andy",
                Active = false,
                Woman = true,
                Year = 2013,
                Photo = "/img/andy.png",
                ShowInList = false
            };
            Instructors.Add(andy);

            var ancas = new Instructor()
            {
                Id = 20,
                Name = "AnčaS",
                Active = false,
                Woman = true,
                Year = 2013,
                Photo = "/img/ancas.png",
                ShowInList = false
            };
            Instructors.Add(ancas);

            var alex = new Instructor()
            {
                Id = 21,
                Name = "Alex",
                Active = false,
                Woman = false,
                Year = 2014,
                Photo = "/img/ymca.png",
                ShowInList = false
            };
            Instructors.Add(alex);

            var ajka = new Instructor()
            {
                Id = 22,
                Name = "Ajka",
                Active = false,
                Woman = true,
                Year = 2010,
                Photo = "/img/ajka.png",
                ShowInList = false
            };
            Instructors.Add(ajka);

            var tomas = new Instructor()
            {
                Id = 23,
                Name = "TomH",
                Active = true,
                Woman = false,
                Year = 2021,
                Photo = "/img/tomash.png",
                ShowInList = true
            };
            Instructors.Add(tomas);

            var misat = new Instructor()
            {
                Id = 24,
                Name = "MíšaT",
                Active = true,
                Woman = true,
                Year = 2022,
                Photo = "/img/misat.png",
                ShowInList = true
            };
            Instructors.Add(misat);

            var zuzka = new Instructor()
            {
                Id = 25,
                Name = "Zuzka",
                Active = false,
                Woman = true,
                Year = 2023,
                Photo = "/img/zuzka.png",
                ShowInList = true
            };
            Instructors.Add(zuzka);

            var kackaP = new Instructor()
            {
                Id = 26,
                Name = "Kačka P",
                Active = true,
                Woman = true,
                Year = 2024,
                Photo = "/img/kackap.png",
                ShowInList = true
            };
            Instructors.Add(kackaP);

            var justa = new Instructor()
            {
                Id = 27,
                Name = "Jusťa",
                Active = false,
                Woman = true,
                Year = 2024,
                Photo = "/img/justa.png",
                ShowInList = true
            };
            Instructors.Add(justa);

            var kubah = new Instructor()
            {
                Id = 28,
                Name = "Kuba H",
                Active = true,
                Woman = false,
                Year = 2024,
                Photo = "/img/kubah.png",
                ShowInList = true
            };
            Instructors.Add(kubah);

            var kackad = new Instructor()
            {
                Id = 29,
                Name = "Kačka D",
                Active = true,
                Woman = true,
                Year = 2024,
                Photo = "/img/kackad.png",
                ShowInList = true
            };
            Instructors.Add(kackad);

            var novy1 = new Instructor()
            {
                Id = 99,
                Name = "Nový",
                Active = false,
                Woman = true,
                Year = 2099,
                Photo = "/img/ymca.png",
                ShowInList = true
            };
            Instructors.Add(novy1);

            
            // 2024
            Togethers.Add(new Together(blaza, kubah, julca, 2024, 1));
            Togethers.Add(new Together(simon, filip, kackad, 2024, 2));
            Togethers.Add(new Together(kubaj, misat, kackaP, 2024, 3));
            Togethers.Add(new Together(fanda, tomas, ancad, 2024, 4));

            // 2023
            Togethers.Add(new Together(fanda, blaza, zuzka, 2023, 1));
            Togethers.Add(new Together(kubaj, tomas, julca, 2023, 2));
            Togethers.Add(new Together(kubam, filip, ancad, 2023, 3));
            Togethers.Add(new Together(simon, misa, misat, 2023, 4));


            // 2022
            Togethers.Add(new Together(blaza, filip, misat, 2022, 1));
            Togethers.Add(new Together(simon, kubaj, ancad, 2022, 2));
            Togethers.Add(new Together(fanda, julca, 2022, 3));
            Togethers.Add(new Together(misa, tomas, kubam, 2022, 4));


            // 2021
            Togethers.Add(new Together(jolka, filip, 2021, 1));
            Togethers.Add(new Together(misa, kubaj, 2021, 2));
            Togethers.Add(new Together(blaza, kubam, julca, 2021, 3));
            Togethers.Add(new Together(simon, fanda, tomas, 2021, 4));


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
            // Rules.Add(new Rule(kackaP, kubah));
        }

    }
}
