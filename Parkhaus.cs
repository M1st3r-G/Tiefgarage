using Newtonsoft.Json;

namespace Tiefgarage
{
    public class Parkhaus
    {
        [JsonProperty] private List<Parketage> parketagen;

        [JsonConstructor]
        public Parkhaus(List<Parketage> pParketagen)
        {
            parketagen = pParketagen;
        }

        public Parkhaus(List<List<Tuple<uint, FahrzeugTyp>>> anzahlenUndTypenProEtage) 
        {
            parketagen = new List<Parketage>();
            if (anzahlenUndTypenProEtage is null || anzahlenUndTypenProEtage.Count == 0) throw new ArgumentException("Der Veruch ein Etagenloses Parkhaus zu erstellen, wurde unterbrochen.");

            //Check at Least One Level with at Least one Spot
            foreach (List<Tuple<uint, FahrzeugTyp>> anzahlenUndTypen in anzahlenUndTypenProEtage)
            {
                Parketage neueEtage = new(anzahlenUndTypen);
                parketagen.Add(neueEtage);
            }
        }
        
        public bool FahrzeugHinzufuegen(Fahrzeug pFahrzeug)
        {
            if (pFahrzeug is null) return false;
            if (pFahrzeug.GibParkhaus() == this)
            {
                SimulationWindow.OnConsolePrint?.Invoke($"Das Fahrzeug ist bereits im Parkhaus");
                return false; // Nicht zweimal Reinfahren
            }

            if (!ErmittleFreienPlatz(pFahrzeug.GibTyp(), out Parkbucht? freierPlatz))
            {
                SimulationWindow.OnConsolePrint?.Invoke($"Es ist kein Platz mehr im Parkhaus {this}");
                return false;
            }

            freierPlatz.ParkeFahrzeug(pFahrzeug);
            return true;
        }

        public void FahrzeugEntfernen(Fahrzeug pFahrzeug)
        {
            if (pFahrzeug == null) return;
            
            if(GibPlatzVonFahrzeug(pFahrzeug, out Parkbucht? parkbucht, out _)) // gefunden
            {
                parkbucht.EntferneFahrzeug();
                //pFahrzeug.ParkhausVerlassen(); Not Neccessary, Car removes the Parkhouse and calls this
                return;
            }

            SimulationWindow.OnConsolePrint?.Invoke($"Fahrzeug {pFahrzeug} konnte das Parkhaus {this} nicht verlasse, es befand sich nie darin.");
        }

        public bool GibPlatzVonFahrzeug(Fahrzeug pFahrzeug, out Parkbucht? parkbucht, out Point? position)
        {
            foreach(Parketage etage in parketagen)
            {
                if(etage.GibPlatzVonFahrzeug(pFahrzeug, out parkbucht, out int buchtNummer)) // gefunden
                {
                    position = new(parketagen.IndexOf(etage), buchtNummer);
                    return true;
                }
            }

            parkbucht = null;
            position = new(-1, -1);
            return false;
        }

        public uint GibAnzahlPlaetze(bool mitBesetzten = false, bool suchNachTyp = false, FahrzeugTyp typ = FahrzeugTyp.Auto)
        {
            uint sum = 0;

            foreach(Parketage etage in parketagen)
            {
                sum += etage.GibAnzahlPlaetze(mitBesetzten, suchNachTyp, typ);
            }

            return sum;
        }

        public List<Parketage> GibParketagen() => parketagen;

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

        public void Clear()
        {
            foreach (Parketage etage in parketagen)
            {
                etage.Clear();
            }
        }

        public override string ToString() =>
            $"Parkhaus mit {parketagen.Count} Etage(n) mit insgesamt {GibAnzahlPlaetze(true)} Plätzen";
    }

    public class Parketage
    {
        [JsonProperty]  private List<Parkbucht> parkbuchten;

        [JsonConstructor]
        public Parketage(List<Parkbucht> pParkbuchten)
        {
            parkbuchten = pParkbuchten;
        }

        public Parketage(List<Tuple<uint, FahrzeugTyp>> anzahlenUndTypen)
        {
            if(anzahlenUndTypen is null || anzahlenUndTypen.Count == 0) throw new ArgumentException("Der Veruch ein Parkbuchtenlose Etage zu erstellen, wurde unterbrochen.");

            parkbuchten = new List<Parkbucht>();

            foreach(Tuple<uint, FahrzeugTyp> anzahlUndTyp in anzahlenUndTypen)
            {
                for(int i = 0; i < anzahlUndTyp.Item1; i++)
                {
                    Parkbucht neueParkbucht = new(anzahlUndTyp.Item2);
                    parkbuchten.Add(neueParkbucht);
                }
            }
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

        public bool GibPlatzVonFahrzeug(Fahrzeug fahrzeug, out Parkbucht? parkbucht, out int buchtNummer)
        {
            foreach(Parkbucht bucht in parkbuchten)
            {
                if (bucht.HatFreienPlatz(out Fahrzeug? geparktesFahrzeug)) continue;
                if (geparktesFahrzeug != fahrzeug) continue;
                
                parkbucht = bucht;
                buchtNummer = parkbuchten.IndexOf(bucht);
                return true;
            }

            parkbucht = null;
            buchtNummer = -1;
            return false;
        }

        public uint GibAnzahlPlaetze(bool mitBesetzen = false, bool suchNachTyp = false, FahrzeugTyp typ = FahrzeugTyp.Auto)
        {
            IEnumerable<Parkbucht> search = parkbuchten;
            if (suchNachTyp)
            {
                search = parkbuchten.Where(b => b.GibTyp() == typ);
            }
                
            if (mitBesetzen) return (uint) search.Count();
            
            return search.Aggregate(0u, (c, bucht) => bucht.HatFreienPlatz(out _) ? c + 1 : c);
        }

        public void Clear()
        {
            foreach (Parkbucht bucht in parkbuchten)
            {
                bucht.Clear();
            }
        }

        public List<Parkbucht> GibParkbuchten() => parkbuchten;
    }

    public class Parkbucht
    {
        [JsonProperty] private FahrzeugTyp typ; // readonly
        private Fahrzeug? geparktesFahrzeug;


        public Parkbucht(FahrzeugTyp pTyp)
        {
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

        public void Clear()
        {
            if (geparktesFahrzeug == null) return;

            geparktesFahrzeug.SetzeParkhaus(null);
            geparktesFahrzeug = null;
        }

        public FahrzeugTyp GibTyp() => typ;
    }
}
