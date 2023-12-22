using HospitalPlatformMVC.Models;

namespace HospitalPlatformMVC.Service.IService
{
    public interface IGroupService
    {
        Task<ResponseDto?> CreateDepartmentsAsync(DepartmentDto departmentDto);
        Task<ResponseDto?> DeleteDepartmentsAsync(int id);
        Task<ResponseDto?> GetAllDepartmentsAsync();
        Task<ResponseDto?> GetDepartmentByIdAsync(int id);
        Task<ResponseDto?> UpdateDepartmentsAsync(DepartmentDto departmentDto);
    }
}
