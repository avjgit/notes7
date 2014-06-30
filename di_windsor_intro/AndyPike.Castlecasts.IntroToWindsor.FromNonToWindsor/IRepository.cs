namespace AndyPike.Castlecasts.IntroToWindsor.FromNonToWindsosr
{
    public interface IRepository<T>
    {
        void Save(T entity);
    }
}