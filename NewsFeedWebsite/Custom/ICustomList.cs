namespace NewsFeedWebsite.Custom
{
    public interface ICustomList<T>
    {
        void Add(T item);
        void Remove(T item);
        T[] Tolist();
    }
}
