namespace VedouciWeb.Models
{
    public static class Incrementor
    {
        private static int _number = 1;

        public static int Next()
        {
            return ++_number;
        }

        public static int Next(int number)
        {
            if (number > _number)
            {
                _number = number++;
                return number;
            }

            return Next();
        }
    }
}
