using SQLite;

namespace Frotas.Models
{
    public class Combustivel
    {
        [PrimaryKey, AutoIncrement]
        public long Id { get; set; }

        public string Nome { get; set; }
        public decimal Valor { get; set; }
    }
}
