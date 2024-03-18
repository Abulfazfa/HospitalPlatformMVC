using HospitalPlatformMVC.Service.IService;

namespace HospitalPlatformMVC.Service
{
    public class UnitOfWork : IUnitOfWork
    {
        public IDoctorService DoctorService { get ; set ; }
        public ITestService TestService { get; set; }
        public IGroupService GroupService { get; set; }
        public IAccountService AccountService { get; set; }
        public IUserService UserService { get; set; }

        public UnitOfWork(IDoctorService doctorService, ITestService testService, IGroupService groupService, IAccountService accountService, IUserService userService)
        {
            DoctorService = doctorService;
            TestService = testService;
            GroupService = groupService;
            AccountService = accountService;
            UserService = userService;
        }

    }
}
