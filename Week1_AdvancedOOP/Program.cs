using System.IO;
using System.Text.Json;

namespace Week1_OOP {

    class Veicolo
    {
        public string Targa { get; }
        public string Modello { get; }
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
        private int numPosti { get; set; }
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
    record struct VeicoloNoleggiatoInfo
    {
        public Veicolo Veicolo { get; set; }
        public int GiorniNoleggio { get; set; }
        public DateTime DataInizio { get; set; }
        public DateTime? DataFine { get; set; }
    }

    class GestoreNoleggi : INoleggiabile
    {
        private List<Veicolo> veicoliDisponibili { get; } = [];
        private List<VeicoloNoleggiatoInfo> veicoliNoleggiati = [];
        private double totIncassato { get; set; } = 0.0;

        public void AggiungiVeicolo(Veicolo v) => veicoliDisponibili.Add(v);

        public string Noleggia(Veicolo veicolo, int giorni)
        {
            if (!veicoliDisponibili.Contains(veicolo))
                return $"Il veicolo {veicolo} non è disponibile.";

            veicoliDisponibili.Remove(veicolo);

            var info = new VeicoloNoleggiatoInfo
            {
                Veicolo = veicolo,
                GiorniNoleggio = giorni,
                DataInizio = DateTime.Now,
                DataFine = null  // ancora non restituito
            };
            veicoliNoleggiati.Add(info);

            double costoTotale = veicolo.PrezzoGiornaliero * giorni;
            totIncassato += costoTotale;

            return $"Veicolo {veicolo} noleggatio per {giorni} giorni, Totale {costoTotale}€";
        }

        public string Restituisci(Veicolo veicolo)
        {
            var info = veicoliNoleggiati.FirstOrDefault(i => i.Veicolo == veicolo);
            if (info.DataFine != null)
                return "Questo veicolo non risulta noleggiato.";

            info.DataFine = DateTime.Now;
            // eventualmente puoi aggiornare GiorniNoleggio se vuoi basarti su data inizio/fine
            
            veicoliDisponibili.Add(veicolo);

            return $"Veicolo {veicolo} restituito con successo. Giorni noleggiati: {info.GiorniNoleggio}";
        }


        public void GetDisponibili()
        {
            Console.WriteLine("Veicoli disponibili");
            veicoliDisponibili.ForEach(v => Console.WriteLine(v.printVeicolo()));
        }

        public void GetNoleggiati()
        {
            Console.WriteLine("Veicoli noleggiati");
            veicoliNoleggiati.ForEach(v => Console.WriteLine($"{v}"));
        }

        public List<Veicolo> GetVeicoliDisponibili()
        {
            return veicoliDisponibili;
        }

        public List<VeicoloNoleggiatoInfo> GetVeicoliNoleggiati()
        {
            return veicoliNoleggiati;
        }

        public double getTotIncassato()
        {
            return totIncassato;
        }
    }

    class GestoreNoleggiJSON : GestoreNoleggi
    {
        private const string FileDati = "veicoli.json";

        public void SalvaDati()
        {
            var dati = new
            {
                Disponibili = GetVeicoliDisponibili(),
                Noleggiati = GetVeicoliNoleggiati(),
                TotIncassato = getTotIncassato(),
            };

            var options = new JsonSerializerOptions {WriteIndented = true};
            string json = JsonSerializer.Serialize(dati, options);
            File.WriteAllText(FileDati, json);
            Console.WriteLine("Dati salvati");
        }

        public void CaricaDati()
        {
            if (!File.Exists(FileDati)) 
            { 
                Console.WriteLine("File non trovato"); 
                return;
            }

            string json = File.ReadAllText(FileDati);
            Console.WriteLine("Dati caricati");


        }

    }

    internal class Program
    {
        private static void Main()
        {
            var gestore = new GestoreNoleggiJSON();

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
            gestore.SalvaDati();


            Console.WriteLine("\n--- Restituzione ---");
            Console.WriteLine(gestore.Restituisci(moto));
            gestore.GetDisponibili();
            Console.WriteLine($"Totale incassato: {gestore.getTotIncassato()}");
            gestore.SalvaDati();

            Console.WriteLine("\n--- Simulazione noleggio ---");
            Console.WriteLine(gestore.Noleggia(moto, 10));
            gestore.GetNoleggiati();
            gestore.GetDisponibili();
            gestore.SalvaDati();

            Console.WriteLine("\nPremi un tasto per uscire...");
            Console.ReadKey();


            /**DELEGATI*/
            Pippo p = Paperino;

            p.Invoke(3, 4);
            p(4, 5);
        }
        static void Paperino(int x, int y)
        {
            Console.WriteLine("PORCODIO");
        }
    }


    delegate void Pippo(int x, int y); // firma di un metodo


    






}