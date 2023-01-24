namespace Core
{
    public interface IManager
    {
        IAuth Authen { get; }   
        IUser UserService { get; }

        Task SaveAsync();
    }
}
