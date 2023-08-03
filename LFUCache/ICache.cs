namespace LfuCache
{
    public interface ICache<in TKey, TValue>
    {
        void Add(TKey key, TValue val);
        TValue Get(TKey key);
    }
}

