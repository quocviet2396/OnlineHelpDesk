namespace WebApp.Repositories
{
    public interface IAuthenService
    {
        bool IsUserLoggedIn();
        bool IsAdmin();
        bool IsSupporter();
    }
}
