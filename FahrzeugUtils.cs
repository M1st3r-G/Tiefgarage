namespace Tiefgarage
{
    public static class FahrzeugUtils
    {
        private static int letzteVergebeneId = 0;
        public static string GibFreieId()
        {
            letzteVergebeneId++;
            return (letzteVergebeneId - 1).ToString();
        }
    }

    public enum FahrzeugTyp
    {
        Auto,
        Motorrad
    }
}