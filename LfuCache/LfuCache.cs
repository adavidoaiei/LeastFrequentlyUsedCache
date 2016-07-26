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

        public delegate void EvictDelegate(TValue value);
        public event EvictDelegate EvictEvent;

        private Dictionary<TKey, LinkedListNode<CacheNode>> _cache = new Dictionary<TKey, LinkedListNode<CacheNode>>();
        private SortedDictionary<int, LinkedList<CacheNode>> _lfuBinaryTree = new SortedDictionary<int, LinkedList<CacheNode>>();

        private int _counter;

        public LfuCache(int size)
        {
            _size = size;
            _counter = 0;
        }

        public void Add(TKey key, TValue val)
        {
            TValue existing;

            if (!TryGet(key, out existing))
            {
                var node = new CacheNode() { Key = key, Data = val, UseCount = 0 };

                if (_counter == _size)
                {
                    var removedData = Evict();
                    _counter--;
                    RaiseEvictEvent(removedData);
                }

                var insertedNode = InsertCacheNodeInLfuBinaryTree(node);

                _cache[key] = insertedNode;
                _counter++;
            }
        }

        private TValue Evict()
        {
            var minimumLinkedList = _lfuBinaryTree.First().Value;
            var dataToRemove = minimumLinkedList.First.Value.Data;
            _cache.Remove(minimumLinkedList.First.Value.Key);
            minimumLinkedList.RemoveFirst();
            return dataToRemove;
        }

        private void RaiseEvictEvent(TValue data)
        {
            EvictDelegate handler = EvictEvent;
            if (handler != null)
            {
                handler(data);
            }
        }

        private LinkedListNode<CacheNode> InsertCacheNodeInLfuBinaryTree(CacheNode node)
        {
            LinkedListNode<CacheNode> insertedNode;

            if (_lfuBinaryTree.ContainsKey(node.UseCount))
            {
                insertedNode = _lfuBinaryTree[node.UseCount].AddLast(node);
            }
            else
            {
                _lfuBinaryTree.Add(node.UseCount, new LinkedList<CacheNode>());
                insertedNode = _lfuBinaryTree[node.UseCount].AddLast(node);
            }

            return insertedNode;
        }

        public TValue Get(TKey key)
        {
            TValue val;
            TryGet(key, out val);
            return val;
        }

        public bool TryGet(TKey key, out TValue val)
        {
            LinkedListNode<CacheNode> linkedListNode;
            bool success = false;

            if (_cache.TryGetValue(key, out linkedListNode))
            {
                var cacheNode = linkedListNode.Value;
                val = cacheNode.Data;

                RemoveLinkedListNodeFromLfuBinaryTree(linkedListNode);

                var newIndex = ++cacheNode.UseCount;

                var newNode = UpdateCacheNodeInLfuBinaryTree(newIndex, cacheNode);

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

        private LinkedListNode<CacheNode> UpdateCacheNodeInLfuBinaryTree(int newIndex, CacheNode cacheNode)
        {
            LinkedListNode<CacheNode> newNode;

            if (_lfuBinaryTree.ContainsKey(newIndex))
            {
                newNode = _lfuBinaryTree[newIndex].AddLast(cacheNode);
            }
            else
            {
                _lfuBinaryTree.Add(newIndex, new LinkedList<CacheNode>());
                newNode = _lfuBinaryTree[newIndex].AddLast(cacheNode);
            }

            return newNode;
        }
    }
}
