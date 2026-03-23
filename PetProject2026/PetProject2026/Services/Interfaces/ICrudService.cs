namespace PetProject2026.Services.Interfaces
{
    public interface ICrudService<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(int id, T enity);
        Task<bool> DeleteAsync(int id);
        
    }
}
