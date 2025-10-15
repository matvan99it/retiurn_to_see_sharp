using System.Globalization;
using System.Net.Sockets;

namespace Module2_es1_LINQAnalysis
{
    public class Order
    {
        public string Cliente { get; set; }
        public double Importo { get; set; }
        public DateTime DataOrdine {  get; set; }
        public string Categoria { get; set; }

        public override string? ToString()
        {
            return $"Cliente: {Cliente}; Importo: {Importo}; DataOrdine: {DataOrdine}; Categoria: {Categoria};";
        }
    }



    internal class Program
    {
        private static void Main(string[] args)
        {


            List<Order> ordini = [
                new Order { Cliente = "Marco",  Importo = 120.50, DataOrdine = DateTime.Now.AddDays(-10), Categoria = "Elettronica" },
                new Order { Cliente = "Lucia",  Importo = 300.00, DataOrdine = DateTime.Now.AddDays(-25), Categoria = "Abbigliamento" },
                new Order { Cliente = "Giulia", Importo = 850.00, DataOrdine = DateTime.Now.AddDays(-60), Categoria = "Elettronica" },
                new Order { Cliente = "Andrea", Importo = 180.00, DataOrdine = DateTime.Now.AddDays(-5),  Categoria = "Casa" },
                new Order { Cliente = "Sara",   Importo = 900.00, DataOrdine = DateTime.Now.AddDays(-15), Categoria = "Elettronica" },
                new Order { Cliente = "Luca",   Importo = 450.00, DataOrdine = DateTime.Now.AddDays(-3),  Categoria = "Abbigliamento" },
                new Order { Cliente = "Lucia",  Importo = 150.00, DataOrdine = DateTime.Now.AddDays(-1),  Categoria = "Casa" },
                new Order { Cliente = "Andrea", Importo = 1200.00,DataOrdine = DateTime.Now.AddDays(-40), Categoria = "Elettronica" },
                new Order { Cliente = "Marco",  Importo = 600.00, DataOrdine = DateTime.Now.AddDays(-7),  Categoria = "Sport" },
                new Order { Cliente = "Sara",   Importo = 220.00, DataOrdine = DateTime.Now.AddDays(-4),  Categoria = "Casa" }
            ];

            Console.WriteLine("Tutti gli ordini");
            foreach (var item in ordini)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            /*
             * SELECT Cliente, Sum(Importo) As Totale From Ordini
             * GroupBy Cliente
             * OrderBy Totale
             */

            var spendaccioni = ordini.GroupBy(o => o.Cliente)
                .Select(g => new
                {
                    Cliente = g.Key,
                    TotaleSpeso = g.Sum(o => o.Importo),
                    OrdiniTotali = g.Count()
                })
                .OrderByDescending(x => x.TotaleSpeso)
                .Take(3);
            Console.WriteLine("🏆 Top 3 clienti per spesa totale:");
            foreach (var c in spendaccioni)
                Console.WriteLine($"- {c.Cliente,-10} | Totale: {c.TotaleSpeso,8:C2} | Ordini totali: {c.OrdiniTotali}");
            Console.WriteLine();


            var categories = ordini.GroupBy(o => o.Categoria)
                .Select(g => new
                {
                    Categoria = g.Key,
                    ValoreMedio = g.Average(o => o.Importo),
                    ValoreTotale = g.Sum(o => o.Importo),
                    Ordini = g.Count()
                });
            Console.WriteLine("🏆 Media per categoria:");
            foreach (var c in categories)
                Console.WriteLine($"- {c.Categoria,-10} | Totale: {c.ValoreMedio,8:C2}");
            Console.WriteLine();

            var ultimomese = ordini.OrderByDescending(o => o.DataOrdine).Where(o => o.DataOrdine.Month == DateTime.Now.Month);
            Console.WriteLine("Ordini dell'ultimo mese");
            foreach (var item in ultimomese)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            var unmesefa = DateTime.Now.AddMonths(-1);
            var ordiniRecenti = ordini
                .Where(o => o.DataOrdine >= unmesefa)
                .OrderByDescending(o => o.DataOrdine);

            Console.WriteLine("🗓️  Ordini dell’ultimo mese GPT:");
            foreach (var o in ordiniRecenti)
                Console.WriteLine(o);
            Console.WriteLine();


            // ─────────────────────────────────────────────
            // 🎯 BONUS – Query Expression equivalente
            // ─────────────────────────────────────────────
            var queryExpression =
                
                from o in ordini
                where o.DataOrdine >= unmesefa
                orderby o.DataOrdine descending
                select o;

            Console.WriteLine("🎯 Stessa query con sintassi 'query expression':");
            foreach (var o in queryExpression)
                Console.WriteLine(o);
        }
    }
}