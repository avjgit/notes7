namespace AndyPike.Castlecasts.IntroToWindsor.FromNonToWindsor
{
    public interface IRepository<T>
    {
        void Save(T entity);
    }
}