using SQLite;

namespace Frotas.Models
{
    public class Abastecimento
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int VeiculoId { get; set; } // FK para Veículo
        public int CombustivelId { get; set; } // FK para Combustível

        public double Litros { get; set; }
        public double ValorTotal { get; set; }
        public DateTime Data { get; set; }
    }
}
