namespace Tiefgarage
{
    public class Parkhaus
    {
        private List<Parketage> parketagen;
        
        public Parkhaus(List<List<Tuple<uint, FahrzeugTyp>>> anzahlenUndTypenProEtage) 
        {
            parketagen = new List<Parketage>();
            if (anzahlenUndTypenProEtage is null || anzahlenUndTypenProEtage.Count == 0) throw new ArgumentException("Der Veruch ein Etagenloses Parkhaus zu erstellen, wurde unterbrochen.");

            //Check at Least One Level with at Least one Spot
            foreach (List<Tuple<uint, FahrzeugTyp>> anzahlenUndTypen in anzahlenUndTypenProEtage)
            {
                Parketage neueEtage = new Parketage(anzahlenUndTypen, this);
                parketagen.Add(neueEtage);
            }
        }
        
        public bool FahrzeugHinzufuegen(Fahrzeug pFahrzeug)
        {
            if (pFahrzeug is null) return false;
            if (pFahrzeug.GibParkhaus() == this) return false; // Nicht zweimal Reinfahren

            if(!ErmittleFreienPlatz(pFahrzeug.GibTyp(), out Parkbucht? freierPlatz))
            {
                Console.WriteLine($"Es ist kein Platz mehr im Parkhaus {this}");
                return false;
            }

            freierPlatz.ParkeFahrzeug(pFahrzeug);
            return true;
        }

        public void FahrzeugEntfernen(Fahrzeug pFahrzeug)
        {
            if (pFahrzeug == null) return;
            
            if(GibPlatzVonFahrzeug(pFahrzeug, out Parkbucht? parkbucht)) // gefunden
            {
                parkbucht.EntferneFahrzeug();
                pFahrzeug.ParkhausVerlassen();
                return;
            }

            Console.WriteLine($"Fahrzeug {pFahrzeug} konnte das Parkhaus {this} nicht verlasse, es befand sich nie darin.");
        }

        public bool GibPlatzVonFahrzeug(Fahrzeug pFahrzeug, out Parkbucht? parkbucht)
        {
            foreach(Parketage etage in parketagen)
            {
                if(etage.GibPlatzVonFahrzeug(pFahrzeug, out parkbucht)) // gefunden
                {
                    return true;
                }
            }

            parkbucht = null;
            return false;
        }

        public uint GibAnzahlPlaetze(bool mitBesetzten = false)
        {
            uint sum = 0;

            foreach(Parketage etage in parketagen)
            {
                sum += etage.GibAnzahlPlaetze(mitBesetzten);
            }

            return sum;
        }

        private bool ErmittleFreienPlatz(FahrzeugTyp typ, out Parkbucht? parkbucht)
        {
            foreach(Parketage etage in parketagen)
            {
                if (etage.HatFreienPlatz(typ, out parkbucht)) // gefunden
                {
                    return true;
                }
            }

            parkbucht = null;
            return false;
        }

        public override string ToString() =>
            $"Parkhaus mit {parketagen.Count} Etage(n) mit insgesamt {GibAnzahlPlaetze(true)} Plätzen";
    }

    public class Parketage
    {
        private Parkhaus meinParkhaus;
        private List<Parkbucht> parkbuchten;

        public Parketage(List<Tuple<uint, FahrzeugTyp>> anzahlenUndTypen, Parkhaus pParkhaus)
        {
            if(anzahlenUndTypen is null || anzahlenUndTypen.Count == 0) throw new ArgumentException("Der Veruch ein Parkbuchtenlose Etage zu erstellen, wurde unterbrochen.");

            parkbuchten = new List<Parkbucht>();

            foreach(Tuple<uint, FahrzeugTyp> anzahlUndTyp in anzahlenUndTypen)
            {
                for(int i = 0; i < anzahlUndTyp.Item1; i++)
                {
                    Parkbucht neueParkbucht = new Parkbucht(anzahlUndTyp.Item2, this);
                    parkbuchten.Add(neueParkbucht);
                }
            }

            meinParkhaus = pParkhaus;
        }

        public  bool HatFreienPlatz(FahrzeugTyp typ, out Parkbucht? parkbucht)
        {
            foreach(Parkbucht bucht in parkbuchten)
            {
                if (typ != bucht.GibTyp()) continue;
                if (!bucht.HatFreienPlatz(out _)) continue;
                
                parkbucht = bucht;
                return true;
            }

            parkbucht = null;
            return false;
        }

        public bool GibPlatzVonFahrzeug(Fahrzeug fahrzeug, out Parkbucht? parkbucht)
        {
            foreach(Parkbucht bucht in parkbuchten)
            {
                if (bucht.HatFreienPlatz(out Fahrzeug? geparktesFahrzeug)) continue;
                if (geparktesFahrzeug != fahrzeug) continue;
                
                parkbucht = bucht;
                return true;
            }

            parkbucht = null;
            return false;
        }

        public uint GibAnzahlPlaetze(bool mitBesetzen = false)
        {
            if (mitBesetzen) return (uint) parkbuchten.Count;
            return parkbuchten.Aggregate(0u, (c, bucht) => bucht.HatFreienPlatz(out _) ? c + 1 : c);
        }

        public override string ToString() =>
            $"Etage im Parkhaus ({meinParkhaus}) mit Insgesamt {GibAnzahlPlaetze(true)} Plätzen";
    }

    public class Parkbucht
    {
        private Parketage etage; // readonly
        private FahrzeugTyp typ; // readonly
        private Fahrzeug? geparktesFahrzeug;


        public Parkbucht(FahrzeugTyp pTyp, Parketage pEtage)
        {
            etage = pEtage;
            typ = pTyp;
        }

        public void ParkeFahrzeug(Fahrzeug pFahrzeug)
        {
            if (pFahrzeug.GibTyp() != typ) throw new ArgumentException($"Ein Fahrzeug vom Typ {pFahrzeug.GibTyp()} kann nicht in die Parklücke {this}");
            if (geparktesFahrzeug != null) throw new ArgumentException($"Die Parkbucht {this} hat keinen Platz für das Fahrzeug {pFahrzeug}. Es ist von {geparktesFahrzeug} belegt.");

            geparktesFahrzeug = pFahrzeug;
        }

        public Fahrzeug? EntferneFahrzeug()
        {
            Fahrzeug? tmp = geparktesFahrzeug;
            geparktesFahrzeug = null;
            return tmp;
        }

        public bool HatFreienPlatz(out Fahrzeug? pFahrzeug)
        {
            pFahrzeug = geparktesFahrzeug;
            return geparktesFahrzeug == null;
        }

        public FahrzeugTyp GibTyp() => typ;

        public override string ToString()
        {
            return $"Parkbucht im Parkhaus in der Etage ({etage})";
        }
    }
}
