using Frotas.Models;
using SQLite;

namespace Frotas.Services
{
    public class SQLiteHelper
    {
        private readonly SQLiteAsyncConnection _database;

        public SQLiteHelper(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Veiculo>().Wait();
            _database.CreateTableAsync<Abastecimento>().Wait();
            _database.CreateTableAsync<Combustivel>().Wait();
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

        // CRUD Abastecimentos

        public Task<List<Abastecimento>> GetAbastecimentosPorVeiculoAsync(int veiculoId)
        {
            return _database.Table<Abastecimento>()
                            .Where(a => a.VeiculoId == veiculoId)
                            .ToListAsync();
        }

        public async Task ExcluirAbastecimentosPorVeiculoAsync(int veiculoId)
        {
            var abastecimentos = await GetAbastecimentosPorVeiculoAsync(veiculoId);
            foreach (var a in abastecimentos)
            {
                await _database.DeleteAsync(a);
            }
        }

        // CRUD Combustíveis
        public Task<List<Combustivel>> GetCombustiveisAsync() =>
            _database.Table<Combustivel>().ToListAsync();

        public Task<Combustivel> GetCombustivelAsync(int id) =>
            _database.Table<Combustivel>().Where(c => c.Id == id).FirstOrDefaultAsync();

        public Task<int> SalvarCombustivelAsync(Combustivel combustivel) =>
            combustivel.Id != 0 ? _database.UpdateAsync(combustivel) : _database.InsertAsync(combustivel);

        public Task<int> DeletarCombustivelAsync(Combustivel combustivel) =>
            _database.DeleteAsync(combustivel);

        // Verificar se combustível está em uso
        public async Task<bool> CombustivelEmUsoAsync(int combustivelId)
        {
            return await _database.Table<Abastecimento>()
                .Where(a => a.CombustivelId == combustivelId)
                .CountAsync() > 0;
        }


        // CRUD Avastecimento

        public Task<List<Abastecimento>> GetAbastecimentosAsync() =>
            _database.Table<Abastecimento>().OrderByDescending(a => a.Data).ToListAsync();

        public Task<Abastecimento> GetAbastecimentoAsync(int id) =>
            _database.Table<Abastecimento>().Where(a => a.Id == id).FirstOrDefaultAsync();

        public Task<int> SalvarAbastecimentoAsync(Abastecimento abastecimento) =>
            abastecimento.Id != 0 ? _database.UpdateAsync(abastecimento) : _database.InsertAsync(abastecimento);

        public Task<int> DeletarAbastecimentoAsync(Abastecimento abastecimento) =>
            _database.DeleteAsync(abastecimento);
    }
}