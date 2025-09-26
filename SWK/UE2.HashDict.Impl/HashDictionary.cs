using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace UE2.HashDict.Impl;

public class HashDictionary<TKey, TValue> : IDictionary<TKey, TValue>
{
    private class Node(TKey key, TValue value, Node next = null)
    {
        public TKey Key { get; init; } = key;
        public TValue Value { get; set; } = value;
        public Node Next { get; set; } = next;
    }

    private const int INITIAL_CAPACITY = 16;

    private readonly Node[] _buckets = new Node[INITIAL_CAPACITY];

    private int IndexFor(TKey key) => Math.Abs(key.GetHashCode()) % _buckets.Length;

    private Node FindNode(TKey key, out Node previous)
    {
        Node current = _buckets[IndexFor(key)];
        previous = null;

        while (current != null)
        {
            if (key.Equals(current.Key))
            {
                return current;
            }
            previous = current;
            current = current.Next;
        }

        return null;
    }

    private bool TryGetNode(TKey key, out Node node, out Node previous)
    {
        node = FindNode(key, out previous);
        return node != null;
    }

    private void SetNode(TKey key, TValue value)
    {
        var node = FindNode(key, out var previous);
        if (node != null)
        {
            node.Value = value;
        }
        else
        {
            var newNode = new Node(key, value);
            if (previous == null)
            {
                _buckets[IndexFor(key)] = newNode;
            }
            else
            {
                previous.Next = newNode;
            }
        }
    }

    public TValue this[TKey key]
    {
        get
        {
            if (TryGetNode(key, out var node, out _))
            {
                return node.Value;
            }
            throw new KeyNotFoundException();
        }
        set
        {
            SetNode(key, value);
        }
    }

    public ICollection<TKey> Keys => throw new NotImplementedException();

    public ICollection<TValue> Values => throw new NotImplementedException();

    public int Count => throw new NotImplementedException();

    public bool IsReadOnly => throw new NotImplementedException();

    public void Add(TKey key, TValue value)
    {
        throw new NotImplementedException();
    }

    public void Add(KeyValuePair<TKey, TValue> item)
    {
        throw new NotImplementedException();
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public bool Contains(KeyValuePair<TKey, TValue> item)
    {
        throw new NotImplementedException();
    }

    public bool ContainsKey(TKey key)
    {
        throw new NotImplementedException();
    }

    public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    public bool Remove(TKey key)
    {
        throw new NotImplementedException();
    }

    public bool Remove(KeyValuePair<TKey, TValue> item)
    {
        throw new NotImplementedException();
    }

    public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
