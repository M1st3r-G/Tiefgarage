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

    public class SaveObject
    {
        public List<TypenUndAnzahlenProEtage>? etagen;

        public SaveObject() { }

        public void AddTypUndAnzahl(TypenUndAnzahlenProEtage pTypUndAnzahl)
        {
            etagen ??= new();
            etagen.Add(pTypUndAnzahl);
        }

        public Parkhaus ToParkhaus()
        {
            List<List<Tuple<uint, FahrzeugTyp>>> fuerJedeEtage = new();

            foreach (TypenUndAnzahlenProEtage proEtage in etagen)
            {
                List<Tuple<uint, FahrzeugTyp>> tmp = new();
                foreach(var ka in proEtage.typUndAnzahl)
                {
                    tmp.Add(new Tuple<uint, FahrzeugTyp>((uint)ka.anzahl, ka.typ));
                }

                fuerJedeEtage.Add(tmp);
            }

            return new(fuerJedeEtage);
        }

        public class TypenUndAnzahlenProEtage
        {
            public List<TA> typUndAnzahl;

            public void AddTA(FahrzeugTyp pTyp, int pAnazahl)
            {
                typUndAnzahl ??= new List<TA>();
                typUndAnzahl.Add(new TA(pTyp, pAnazahl));
            }

            public struct TA
            {
                public FahrzeugTyp typ;
                public int anzahl;

                public TA(FahrzeugTyp pTyp, int pAnazahl)
                {
                    typ = pTyp;
                    anzahl = pAnazahl;
                }
            }
        }
    }
}