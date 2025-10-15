namespace Week2_LINQ
{
    public abstract class Dipendente
    {
        public string Nome {  get; set; }
        public string Cognome { get; set; }
        public double StipendioBase { get; set; }

        protected Dipendente(string nome, string cognome, double stipendioBase)
        {
            Nome = nome;
            Cognome = cognome;
            StipendioBase = stipendioBase;
        }

        public abstract double CalcolaStipendio();
    }

    public interface IPremiable
    {
        double calcolaPremio();
    }


    public class Impiegato : Dipendente, IPremiable
    {
        int OreLavorate { get; set; }

        public Impiegato(string nome, string cognome, double stipendioBase, int oreLavorate) 
            : base(nome, cognome, stipendioBase)
        {
            OreLavorate = oreLavorate;
        }

        public override double CalcolaStipendio()
        {
            return StipendioBase + OreLavorate * 10;
        }

        public double calcolaPremio()
        {
            return CalcolaStipendio() * 0.05;
        }
    }

    class Tecnico : Dipendente, IPremiable
    {
        int ProgettiCompletati { get; set; }
        public Tecnico(string nome, string cognome, double stipendioBase, int progettiCompletati)
            : base(nome, cognome, stipendioBase)
        {
            ProgettiCompletati = progettiCompletati;
        }

        public override double CalcolaStipendio()
        {
            return StipendioBase + ProgettiCompletati * 10;
        }

        public double calcolaPremio()
        {
            return ProgettiCompletati * 150 * .10;
        }
    }

    public class Manager : Dipendente, IPremiable
    {

        public double BonusTeam {  get; set; }
        public List<Dipendente> Team { get; set; } = [];
        public Manager(string nome, string cognome, double stipendioBase, double bonusTeam) : base(nome, cognome, stipendioBase)
        {
            BonusTeam = bonusTeam;
        }


        public override double CalcolaStipendio()
        {
            return StipendioBase + calcolaPremio();
        }

        public double calcolaPremio()
        {
            if (Team.Count == 0 || Team == null) return 0;

            double sommaTeam = Team.Sum(d => d.CalcolaStipendio());
            return sommaTeam * BonusTeam;
        }
    }



    // 🔸 Programma principale
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creiamo alcuni dipendenti
            var imp1 = new Impiegato("Marco", "Rossi", 1200, 80);
            var imp2 = new Impiegato("Lucia", "Bianchi", 1300, 90);
            var tech1 = new Tecnico("Giulia", "Neri", 1400, 4);
            var tech2 = new Tecnico("Andrea", "Verdi", 1500, 6);

            var manager = new Manager("Sara", "Mancini", 2500, 0.15);
            manager.Team.AddRange([imp1, imp2, tech1, tech2]);

            // Lista completa di tutti i dipendenti
            List<Dipendente> azienda = [imp1, imp2, tech1, tech2, manager];

            // Stampa dettagli
            Console.WriteLine("🏢 Elenco Dipendenti:\n");

            foreach (var d in azienda)
            {
                Console.WriteLine($"{d,-35} | Stipendio Totale: {d.CalcolaStipendio(),8:C2}");
                if (d is IPremiable p)
                    Console.WriteLine($"   Premio: {p.calcolaPremio():C2}");
            }

            Console.WriteLine();
            
            // 🎯 Uso di LINQ per statistiche
            var stipendioMedio = azienda.Average(d => d.CalcolaStipendio());
            /* Senza LINQ
                double somma = 0;
                foreach (var d in azienda)
                    somma += d.CalcolaStipendio();

                double stipendioMedio = somma / azienda.Count;
             */


            var totalePremi = azienda
                .OfType<IPremiable>() // filtra solo gli oggetti che implementano l’interfaccia
                .Sum(p => p.calcolaPremio());

            Console.WriteLine("📊 Statistiche aziendali:");
            Console.WriteLine($"- Stipendio medio: {stipendioMedio:C2}");
            Console.WriteLine($"- Totale premi:    {totalePremi:C2}");

            Console.WriteLine("\nPremi un tasto per uscire...");
            Console.ReadKey();
        }
    }
}
