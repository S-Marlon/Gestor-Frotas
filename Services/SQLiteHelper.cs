using SQLite;
using Frotas.Models;

namespace Frotas.Services
{
    public class SQLiteHelper
    {
        private readonly SQLiteAsyncConnection _database;

        public SQLiteHelper(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Veiculo>().Wait(); // outras tabelas depois
        }

        // CRUD Veículos
        public Task<List<Veiculo>> GetVeiculosAsync() =>
            _database.Table<Veiculo>().ToListAsync();

        public Task<Veiculo> GetVeiculoAsync(int id) =>
            _database.Table<Veiculo>().Where(v => v.Id == id).FirstOrDefaultAsync();

        public Task<int> SalvarVeiculoAsync(Veiculo veiculo) =>
            veiculo.Id != 0 ? _database.UpdateAsync(veiculo) : _database.InsertAsync(veiculo);

        public Task<int> DeletarVeiculoAsync(Veiculo veiculo) =>
            _database.DeleteAsync(veiculo);
    }
}