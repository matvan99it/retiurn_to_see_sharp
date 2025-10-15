namespace Week1_OOP{

    class Veicolo
    {
        public string Targa { get;}
        public string Modello { get;}
        public double PrezzoGiornaliero { get; set; }

        public Veicolo(string targa, string modello, double prezzoGiornaliero)
        {
            Targa = targa;
            Modello = modello;
            PrezzoGiornaliero = prezzoGiornaliero;
        }

        public override string? ToString()
        {
            return $"{Modello} (Targa: {Targa})";
        }

        public string printVeicolo()
        {
            return $"{Modello} (Targa: {Targa}). Costo giornaliero {PrezzoGiornaliero}€";
        }
    }


    internal class Auto : Veicolo
    {
        private int numPosti {  get; set; }
        public Auto(string targa, string modello, double prezzoGiornaliero, int numPosti) : base(targa, modello, prezzoGiornaliero)
        {
            this.numPosti = numPosti;
        }
    }

    internal class Moto : Veicolo
    {
        private int Cilindrata { get; set; }
        public Moto(string targa, string modello, double prezzoGiornaliero, int cilindrata) : base(targa, modello, prezzoGiornaliero)
        {
            this.Cilindrata = cilindrata;
        }
    }

    internal class Furgone : Veicolo
    {
        private bool Aperto { get; set; }
        public Furgone(string targa, string modello, double prezzoGiornaliero, bool aperto) : base(targa, modello, prezzoGiornaliero)
        {
            this.Aperto = aperto;
        }
    }


    /**
     * Soluzione gpt
     */
    interface INoleggiabile
    {
        string Noleggia(Veicolo veicolo, int giorni);
        string Restituisci(Veicolo veicolo);
    }

    class GestoreNoleggi : INoleggiabile
    {
        private readonly List<Veicolo> veicoliDisponibili = new List<Veicolo>();
        private readonly List<Veicolo> veicoliNoleggati   = new List<Veicolo>();

        public void AggiungiVeicolo(Veicolo v) => veicoliDisponibili.Add(v);


        public string Noleggia(Veicolo veicolo, int giorni)
        {
            if (!veicoliDisponibili.Contains(veicolo)) return $"Veicolo {veicolo} non disponibile";

            veicoliDisponibili.Remove(veicolo);
            veicoliNoleggati.Add(veicolo);

            double costoTotale = veicolo.PrezzoGiornaliero * giorni;
            return $"Veicolo {veicolo} noleggatio per {giorni} giorni, Totale {costoTotale}€";
        }

        public string Restituisci(Veicolo veicolo)
        {
            if (!veicoliNoleggati.Contains(veicolo)) return $"Veicolo {veicolo} non noleggiato";

            veicoliNoleggati.Remove(veicolo);
            veicoliDisponibili.Add(veicolo);

            return $"Veicolo {veicolo} restituito";
        }

        public void GetDisponibili()
        {
            Console.WriteLine("Veicoli disponibili");
            veicoliDisponibili.ForEach(v => Console.WriteLine(v.printVeicolo() ) );
        }

        public void GetNoleggiati()
        {
            Console.WriteLine("Veicoli noleggiati");
            veicoliNoleggati.ForEach(v => Console.WriteLine($"{v}"));
        }
    }

    internal class Program
    {
        private static void Main()
        {
            var gestore = new GestoreNoleggi();

            // Aggiungiamo alcuni veicoli
            var auto = new Auto("AB123CD", "Fiat 500", 45.5, 4);
            var moto = new Moto("XY987ZT", "Ducati Monster", 60, 800);
            var furgone = new Furgone("FG456LM", "Iveco Daily", 120, false);

            gestore.AggiungiVeicolo(auto);
            gestore.AggiungiVeicolo(moto);
            gestore.AggiungiVeicolo(furgone);

            gestore.GetDisponibili();

            Console.WriteLine("\n--- Simulazione noleggio ---");
            Console.WriteLine(gestore.Noleggia(moto, 3));
            gestore.GetNoleggiati();
            gestore.GetDisponibili();

            Console.WriteLine("\n--- Restituzione ---");
            Console.WriteLine(gestore.Restituisci(moto));
            gestore.GetDisponibili();

            Console.WriteLine("\nPremi un tasto per uscire...");
            Console.ReadKey();
        }
    }
}