namespace VedouciWeb.Models
{
    public static class Colorer
    {
        private static Dictionary<int, string> _colors = new Dictionary<int, string>()
        {
            {1,"#ff6347"},
            {2,"#bc8f8f"},
            {3,"#bdb76b"},
            {4,"#9acd32"},
            {5,"#20b2aa"},
            {6,"#32cd32"},
            {7,"#8fbc8f"},
            {8,"#d2b48c"},
            {9,"#ff8c00"},
            {10,"#ffd700"},
            {11,"#00ff00"},
            {12,"#00fa9a"},
            {13,"#e9967a"},
            {14,"#00ffff"},
            {15,"#00bfff"},
            {16,"#f4a460"},
            {17,"#adff2f"},
            {18,"#d8bfd8"},
            {19,"#db7093"},
            {20,"#ffff54"},
            {21,"#6495ed"},
            {22,"#dda0dd"},
            {23,"#87ceeb"},
            {24,"#ee82ee"},
            {25,"#98fb98"},
            {26,"#7fffd4"},
            {27,"#ff69b4"},
            {28,"#fffacd"},
            {29,"#ffe4e1"},
            {30,"#e0ffff"},
            {31,"#ffb6c1"},
            {32,"#696969"},
            {33,"#008080"},
            {34,"#4169e1"},
            {35,"#b03060"},
            {36,"#d2691e"},
            {99,"#dc143c"}
        };

        public static string GetColorCode(int id)
        {
            return _colors[id];
        }
    }
}
