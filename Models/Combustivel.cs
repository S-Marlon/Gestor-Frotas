using SQLite;

namespace Frotas.Models
{
    public class Combustivel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
