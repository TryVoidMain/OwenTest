namespace Common.Services
{
    public interface IProcessService<T> : ILoadService<T>, ISaveService<T> where T : class
    {
        T Value { get; set; }

        public event Action OnFileLoaded;
    }
}
