using System.DirectoryServices.ActiveDirectory;

namespace Tiefgarage
{
    public static class FahrzeugUtils
    {
        private static readonly List<string> vergebenIDs = new();
        public static string GibFreieId()
        {
            string id = GenerateRandomID(new Random());
            vergebenIDs.Add(id);
            return id;
        }

        private static string GenerateRandomID(Random rnd)
        {
            string[] placesPrefixes = new string[]
            {
                "AB", "AZE", "BAD", "BI", "CUX", "DD", "DN", "DUD", "ER", "FÜ", "GUB", "Y", "ZZ", "WHV"
            };

            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVXYZ";

            string id = placesPrefixes[rnd.Next(0, placesPrefixes.Length)] + " ";

            for (int i = 0; i < rnd.Next(1, 3); i++)
            {
                id += alphabet[rnd.Next(0, alphabet.Length)];
            }

            id += " ";

            for (int i = 0; i < rnd.Next(1, 5); i++)
            {
                id += rnd.Next(0, 10);
            }


            if(vergebenIDs.Contains(id)) return GenerateRandomID(rnd);
            return id;
        }
    }

    

    public enum FahrzeugTyp
    {
        Auto,
        Motorrad
    }
}