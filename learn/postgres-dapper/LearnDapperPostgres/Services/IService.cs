namespace LearnDapperPostgres.Services
{
    public interface IService<T> where T : class
    {
        Task<IEnumerable<T>> GetAsync();
        Task<T> GetByIdAsync(int id);
        Task InsertAsync(T entity);
        Task UpdateAsync(int id, T Entity);
        Task DeleteAsync(int id);
    }
}
