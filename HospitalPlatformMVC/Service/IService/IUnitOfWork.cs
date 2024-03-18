namespace HospitalPlatformMVC.Service.IService
{
    public interface IUnitOfWork
    {
        IDoctorService DoctorService { get; set; }
        ITestService TestService { get; set; }
        IGroupService GroupService { get; set; }
        IAccountService AccountService { get; set; }
        IUserService UserService { get; set; }
        
    }
}
