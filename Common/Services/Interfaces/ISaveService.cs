namespace Common.Services
{
    public interface ISaveService<T> where T : class
    {
        void Save(T entity, string path);
    }
}
