namespace Indexers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <inheritdoc cref="IMap2D{TKey1,TKey2,TValue}" />
    public class Map2D<TKey1, TKey2, TValue> : IMap2D<TKey1, TKey2, TValue>
    {
        private readonly Dictionary<Tuple<TKey1, TKey2>, TValue> _map = new Dictionary<Tuple<TKey1, TKey2>, TValue>();
        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.NumberOfElements" />
        public int NumberOfElements
        {
            get
            {
                int count = 0;
                foreach (var value in _map.Values)
                {
                    count++;
                }
                return count;
            }
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.this" />
        public TValue this[TKey1 key1, TKey2 key2]
        {
            get => _map[Tuple.Create(key1, key2)];
            set { _map[Tuple.Create(key1, key2)] = value; }
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.GetRow(TKey1)" />
        public IList<Tuple<TKey2, TValue>> GetRow(TKey1 key1)
        {
            List<Tuple<TKey2, TValue>> list = new List<Tuple<TKey2, TValue>>();
            foreach (var key in _map.Keys)
            {
                if (key.Item1.Equals(key1))
                {
                    list.Add(Tuple.Create(key.Item2, _map[key]));
                }
            }
            return list;
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.GetColumn(TKey2)" />
        public IList<Tuple<TKey1, TValue>> GetColumn(TKey2 key2)
        {
            List<Tuple<TKey1, TValue>> list = new List<Tuple<TKey1, TValue>>();
            foreach (var key in _map.Keys)
            {
                if (key.Item2.Equals(key2))
                {
                    list.Add(Tuple.Create(key.Item1, _map[key]));
                }
            }
            return list;
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.GetElements" />
        public IList<Tuple<TKey1, TKey2, TValue>> GetElements()
        {
            List<Tuple<TKey1, TKey2, TValue>> list = new List<Tuple<TKey1, TKey2, TValue>>();
            foreach (var key in _map.Keys)
            {
                list.Add(Tuple.Create(key.Item1, key.Item2, this[key.Item1, key.Item2]));
            }
            return list;
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.Fill(IEnumerable{TKey1}, IEnumerable{TKey2}, Func{TKey1, TKey2, TValue})" />
        public void Fill(IEnumerable<TKey1> keys1, IEnumerable<TKey2> keys2, Func<TKey1, TKey2, TValue> generator)
        {
            foreach (var key1 in keys1)
            {
                foreach (var key2 in keys2)
                {
                    this[key1, key2] = generator(key1, key2);
                }
            }
        }

        /// <inheritdoc cref="IEquatable{T}.Equals(T)" />
        public bool Equals(IMap2D<TKey1, TKey2, TValue> other)
        {
            if (other == null || other.GetType() != _map.GetType())
            {
                return false;
            }
            else if (other == _map as IMap2D<TKey1, TKey2, TValue>)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <inheritdoc cref="object.Equals(object?)" />
        public override bool Equals(object obj)
        {
            // TODO: improve
            return obj is Map2D<TKey1, TKey2, TValue> map2D ? this.Equals(obj as IMap2D<TKey1, TKey2, TValue>) : false ;
        }

        /// <inheritdoc cref="object.GetHashCode"/>
        public override int GetHashCode()
        {
            if (_map == null)
            {
                return 0;
            } 
            else 
            {
                return _map.GetHashCode();
            }

        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.ToString"/>
        public override string ToString()
        {
                return "[" + this.GetElements() + " ]";
            
        }
    }
}
