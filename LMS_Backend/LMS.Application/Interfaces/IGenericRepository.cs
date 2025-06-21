namespace LMS_Backend.LMS.Application.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<ICollection<T>> GetAllAsync();
        public Task<T> GetByIdAsync(int id);
        public Task AddAsync(T entity);
        public Task UpdateAsync(int id, T entity);
        public Task DeleteAsync(int id);
    }
}