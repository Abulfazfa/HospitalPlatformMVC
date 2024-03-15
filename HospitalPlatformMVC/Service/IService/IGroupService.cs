using HospitalPlatformMVC.Models;

namespace HospitalPlatformMVC.Service.IService
{
    public interface IGroupService
    {
        Task<ResponseDto?> CreateDepartmentsAsync(DepartmentDto departmentDto);
        Task<ResponseDto?> DeleteDepartmentsAsync(int id);
        Task<List<DepartmentDto>?> GetAllDepartmentsAsync();
        Task<DepartmentDto?> GetDepartmentByIdAsync(int id);
        Task<ResponseDto?> UpdateDepartmentsAsync(DepartmentDto departmentDto);
    }
}
