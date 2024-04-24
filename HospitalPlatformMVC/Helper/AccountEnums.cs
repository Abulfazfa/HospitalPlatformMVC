namespace HospitalPlatformMVC.Helper
{
    public enum LoginResult
    {
        Success,
        UserNotFound,
        UserLockedOut,
        InvalidCredentials
    }
    public enum RoleEnum
    {
        Admin,
        SubAdmin,
        Expert,
        User
    }
}
