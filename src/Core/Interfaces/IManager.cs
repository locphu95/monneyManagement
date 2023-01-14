namespace Core
{
    public interface IManager
    {
        IAuth Authen { get; }
        Task SaveAsync();
    }
}
