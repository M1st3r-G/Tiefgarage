using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

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
                Parketage neueEtage = Parketage(anzahlenUndTypen, this);
                parketagen.Add(neueEtage);
            }
        }
        
        public bool FahrzeugHinzufuegen(Fahrzeug pFahrzeug)
        {
            if (pFahrzeug is null) return false;
            if (pFahrzeug.GibParkhaus() == this) return false; // Nicht zweimal Reinfahren

            if(!ErmittleFreienPlatz(pFahrzeug.GibTyp(), out Parkbucht freierPlatz))
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
            
            if(GibPlatzVonFahrzeug(pFahrzeug, out Parkbucht parkbucht)) // gefunden
            {
                parkbucht.entferneFahrzeug();
                pFahrzeug.ParkhausVerlassen();
                return;
            }

            Console.WriteLine($"Fahrzeug {pFahrzeug} konnte das Parkhaus {this} nicht verlasse, es befand sich nie darin.");
        }

        public bool GibPlatzVonFahrzeug(Fahrzeug pFahrzeug, out Parkbucht parkbucht)
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

        public uint GibAnzahlFreierPlaetze()
        {
            uint sum = 0;

            foreach(Parketage etage in parketagen)
            {
                sum += etage.GibAnzahlFreierPlaetze();
            }

            return sum;
        }

        private bool ErmittleFreienPlatz(FahrzeugTyp typ, out Parkbucht parkbucht)
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
    }
}
