namespace Tiefgarage
{
    public abstract class Fahrzeug
    {
        private string id;
        private Parkhaus? meinParkhaus;
        protected FahrzeugTyp typ;

        protected Fahrzeug(string pId)
        {
            id = pId;
        }

        public void ParkhausBefahren(Parkhaus pParkhaus)
        {
            if (!pParkhaus.FahrzeugHinzufuegen(this))
            {
                Console.WriteLine($"Fehler Fahrzeug {id} konnte nicht ins Parkhaus {pParkhaus} fahren");
                return;
            }
            
            meinParkhaus = pParkhaus;
        }

        public void ParkhausVerlassen()
        {
            if (meinParkhaus is null) return;
            meinParkhaus.fahrzeugEntfernen(this);
            meinParkhaus = null;
        }

        public Parkhaus? GibParkhaus() => meinParkhaus;
        public FahrzeugTyp GibTyp() => typ;
    }

    public class Motorrad: Fahrzeug
    {
        public Motorrad(string pId) : base(pId)
        {
            typ = FahrzeugTyp.Motorrad;
        }
    }

    public class Auto: Fahrzeug
    {
        public Auto(string pId) : base(pId)
        {
            typ = FahrzeugTyp.Auto;
        }
    }
}
