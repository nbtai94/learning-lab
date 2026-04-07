

using Dapper;

namespace LearnDapperPostgres.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IDatabaseService _databaseService;
        private readonly string _table;
        public GenericRepository(IDatabaseService databaseService,string table)
        {
            _databaseService = databaseService;
        }

        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            using (var conn = _databaseService.GetConnection())
            {
                var query = $"SELECT * FROM {_table}";
                return await conn.QueryAsync<T>(query);
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task InsertAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(int id, T Entity)
        {
            throw new NotImplementedException();
        }
    }
}
