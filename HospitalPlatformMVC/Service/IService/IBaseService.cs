using HospitalPlatformMVC.Models;

namespace HospitalPlatformMVC.Service.IService
{
    public interface IBaseService
    {
        Task<ResponseDto?> SendAsync(RequestDto requestDto, bool withBearer = true);
    }
}
