
using LearnDapperPostgres.Data;

namespace LearnDapperPostgres.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;
        public Service(IGenericRepository<T> repository)
        {
            _repository = repository;
        }
        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await _repository.GetAsync();
        }

        public Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, T Entity)
        {
            throw new NotImplementedException();
        }
    }
}
