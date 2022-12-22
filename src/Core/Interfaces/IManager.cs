namespace Core
{
    public interface IManager
    {
        IUserAuth Authen { get; }
        Task SaveAsync();
    }
}
