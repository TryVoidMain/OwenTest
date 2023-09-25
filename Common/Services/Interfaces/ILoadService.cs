namespace Common.Services
{
    public interface ILoadService<T> where T : class
    {
        T Load(string path);
    }
}
