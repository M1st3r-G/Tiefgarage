namespace Tiefgarage
{
    public abstract class Fahrzeug
    {
        private readonly string id;
        private Parkhaus? meinParkhaus;
        protected FahrzeugTyp typ;

        protected Fahrzeug()
        {
            id = FahrzeugUtils.GibFreieId();
        }

        public void ParkhausBefahren(Parkhaus pParkhaus)
        {
            if (!pParkhaus.FahrzeugHinzufuegen(this))
            {
                SimulationWindow.OnConsolePrint?.Invoke($"Fehler Fahrzeug {id} konnte nicht ins Parkhaus fahren");
                return;
            }
            
            meinParkhaus = pParkhaus;
        }

        public void ParkhausVerlassen()
        {
            if (meinParkhaus is null)
            {
                SimulationWindow.OnConsolePrint?.Invoke($"Fahrzeug {id} ist nicht im Parkhaus.");
                return;
            }
            meinParkhaus.FahrzeugEntfernen(this);
            meinParkhaus = null;
        }

        public Parkhaus? GibParkhaus() => meinParkhaus;
        public FahrzeugTyp GibTyp() => typ;

        public string GibId() => id;

        public void SetzeParkhaus(Parkhaus? p)
        {
            meinParkhaus = p;
        }

        public override string ToString()
        {
            return id;
        }
    }

    public class Motorrad: Fahrzeug
    {
        public Motorrad()
        {
            typ = FahrzeugTyp.Motorrad;
        }
        public override string ToString() { return base.ToString() + " (Motorrad)"; }
    }

    public class Auto: Fahrzeug
    {
        public Auto()
        {
            typ = FahrzeugTyp.Auto;
        }

        public override string ToString() { return base.ToString() + " (Auto)"; }
    }
}
