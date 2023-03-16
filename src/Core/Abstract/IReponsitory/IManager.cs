namespace Core
{
    public interface IManager 
    {
        IAuth Auth { get; }   
        IUser UserService { get; }
        Task SaveAsync();
    }
}
