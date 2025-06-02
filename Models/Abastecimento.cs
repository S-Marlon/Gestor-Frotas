using SQLite;

namespace Frotas.Models
{
    public class Abastecimento
    {
        [PrimaryKey, AutoIncrement]
        public long Id { get; set; }

        public DateTime Data { get; set; }
        public decimal Litros { get; set; }
        public decimal PrecoLitro { get; set; }
        public long Km { get; set; }

        public long VeiculoId { get; set; } // FK
        public long CombustivelId { get; set; } // FK
    }
}
