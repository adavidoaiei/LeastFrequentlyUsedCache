using System.Collections.Generic;
using System.Linq;

namespace LfuCache
{
    public class LfuCache<TKey, TValue> : ICache<TKey, TValue>
    {
        private class CacheNode
        {
            public TKey Key { get; set; }
            public TValue Data { get; set; }
            public int UseCount { get; set; }
        }

        private readonly int _size;

#if DEBUG
        public delegate void EvictDelegate(TValue value);
        public event EvictDelegate EvictEvent;
#endif

        private readonly Dictionary<TKey, LinkedListNode<CacheNode>> _cache = new Dictionary<TKey, LinkedListNode<CacheNode>>();
        private readonly SortedDictionary<int, LinkedList<CacheNode>> _lfuBinaryTree = new SortedDictionary<int, LinkedList<CacheNode>>();

        private int _entriesCount;

        public LfuCache(int size)
        {
            _size = size;
        }

        public void Add(TKey key, TValue val)
        {
            TValue existing;

            if (!TryGet(key, out existing))
            {
                var node = new CacheNode() { Key = key, Data = val };

                if (_entriesCount == _size)
                {
                    var removedData = Evict();
                    _entriesCount--;
#if DEBUG
                    RaiseEvictEvent(removedData); 
#endif
                }

                var insertedNode = InsertCacheNodeInLfuBinaryTree(node);

                _cache[key] = insertedNode;
                _entriesCount++;
            }
        }

        private TValue Evict()
        {
            var minimumUseCountLinkedList = _lfuBinaryTree.First().Value;

            var cacheNode = minimumUseCountLinkedList.First.Value;

            var dataToRemove = cacheNode.Data;
            _cache.Remove(cacheNode.Key);

            minimumUseCountLinkedList.RemoveFirst();

            return dataToRemove;
        }

#if DEBUG
        private void RaiseEvictEvent(TValue data)
        {
            EvictDelegate handler = EvictEvent;
            if (handler != null)
            {
                handler(data);
            }
        }
#endif

        private LinkedListNode<CacheNode> InsertCacheNodeInLfuBinaryTree(CacheNode node)
        {
            return InsertCacheNodeInLfuBinaryTree(node, node.UseCount);
        }

        public TValue Get(TKey key)
        {
            TValue val;
            TryGet(key, out val);
            return val;
        }

        public bool TryGet(TKey key, out TValue val)
        {
            LinkedListNode<CacheNode> linkedListCacheNode;
            bool success = false;

            if (_cache.TryGetValue(key, out linkedListCacheNode))
            {
                var cacheNode = linkedListCacheNode.Value;
                val = cacheNode.Data;

                RemoveLinkedListNodeFromLfuBinaryTree(linkedListCacheNode);

                var newIndex = ++cacheNode.UseCount;

                var newNode = InsertCacheNodeInLfuBinaryTree(cacheNode, newIndex);

                _cache[key] = newNode;

                success = true;
            }
            else
            {
                val = default(TValue);
            }

            return success;
        }

        private void RemoveLinkedListNodeFromLfuBinaryTree(LinkedListNode<CacheNode> linkedListNode)
        {
            var cacheNode = linkedListNode.Value;
            var oldIndex = cacheNode.UseCount;

            _lfuBinaryTree[oldIndex].Remove(linkedListNode);
            if (_lfuBinaryTree[oldIndex].Count == 0)
            {
                _lfuBinaryTree.Remove(oldIndex);
            }
        }

        private LinkedListNode<CacheNode> InsertCacheNodeInLfuBinaryTree(CacheNode node, int index)
        {
            LinkedList<CacheNode> cacheNodes;

            if (!_lfuBinaryTree.TryGetValue(index, out cacheNodes))
            {
                cacheNodes = new LinkedList<CacheNode>();
                _lfuBinaryTree.Add(index, cacheNodes);
            }

            var insertedNode = cacheNodes.AddLast(node);

            return insertedNode;
        }
    }
}
