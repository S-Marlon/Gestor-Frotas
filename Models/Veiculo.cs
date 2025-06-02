using SQLite;

namespace Frotas.Models
{
    public class Veiculo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Placa { get; set; }
        public string Fabricante { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public int Ano { get; set; }

        // Relacionamento (não persistido diretamente no SQLite)
        [Ignore]
        public List<Abastecimento> Abastecimentos { get; set; }

        public double MediaConsumo()
        {
            if (Abastecimentos == null || Abastecimentos.Count == 0)
                return 0;

            decimal totalLitros = Abastecimentos.Sum(a => a.Litros);
            long totalKm = Abastecimentos.Sum(a => a.Km);

            return totalLitros > 0 ? (double)totalKm / (double)totalLitros : 0;
        }
    }
}
