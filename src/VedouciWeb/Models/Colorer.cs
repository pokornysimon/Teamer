namespace VedouciWeb.Models
{
    public static class Colorer
    {
        private static Dictionary<int, string> _colors = new Dictionary<int, string>()
        {
           {1,"#F0F8FF"},
            {2,"#FAEBD7"},
            {3,"#00FFFF"},
            {4,"#7FFFD4"},
            {5,"#7FFF00"},
            {6,"#DEB887"},
            {7,"#FF7F50"},
            {8,"#FFF8DC"},
            {9,"#F5315E"},
            {10,"#BDB76B"},
            {11,"#FF8C00"},
            {12,"#8FBC8F"},
            {13,"#DCDCDC"},
            {14,"#FFD700"},
            {15,"#DAA520"},
            {16,"#ADFF2F"},
            {17,"#FF69B4"},
            {18,"#F08080"},
            {19,"#ADD8E6"},
            {20,"#90EE90"},
            {21,"#87CEFA"},
            {22,"#B0C4DE"},
            {23,"#66CDAA"},
            {24,"#48D1CC"},
            {25,"#00FA9A"},
            {26,"#FFC0CB"},
            {27,"#D290E3"},
            {28,"#BC8F8F"},
            {29,"#F4A460"},
            {30,"#C0C0C0"}
        };

        public static string GetColorCode(int id)
        {
            return _colors[id];
        }
    }
}
