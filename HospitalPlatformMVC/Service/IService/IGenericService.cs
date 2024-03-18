using HospitalPlatformMVC.Models;

namespace HospitalPlatformMVC.Service.IService
{
    public interface IGenericService<T> where T : class
    {
        Task<List<T>?> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<ResponseDto?> CreateAsync(T t);
        Task<ResponseDto?> UpdateAsync(T t);
        Task<ResponseDto?> DeleteAsync(int id);
    }
}
