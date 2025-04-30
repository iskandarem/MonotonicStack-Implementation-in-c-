using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MonotonicStack
{
    class MonotonicStack<T> : IEnumerable<T> where T : IComparable<T> 
    {
        private Stack<T> _stack;
        /// <summary>
        /// Indicates whether the stack maintains a monotonic increasing or decreasing order.
        /// If set to true, the stack enforces a decreasing order (greater elements on top).
        /// If set to false, the stack enforces an increasing order (smaller elements on top).
        /// </summary>
        private bool greater = false;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="greater">
        /// Indicates whether the stack maintains a monotonic increasing or decreasing order.
        /// If set to true, the stack enforces a decreasing order (greater elements on top).
        /// If set to false, the stack enforces an increasing order (smaller elements on top).
        /// </param>
        public MonotonicStack([Optional]bool greater)
        {
            _stack = new();
            this.greater = greater;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="greater">
        /// Indicates whether the stack maintains a monotonic increasing or decreasing order.
        /// If set to true, the stack enforces a decreasing order (greater elements on top).
        /// If set to false, the stack enforces an increasing order (smaller elements on top).
        /// </param>
        public MonotonicStack(IEnumerable<T> enumerator, [Optional]bool greater) : this(greater)
        {
            foreach(var item in enumerator)
            {
                Push(item);
            }
        }

        public int Count => _stack.Count;

        public void Push(T data)
        {
            if (Empty())
            {
                _stack.Push(data);
                return;
            }
            if (!Compare(data))
            {
                _stack.Push(data);
                return;
            }
            while (Compare(data))
            {
                Pop();
            }
            Push(data);
        }
        public T Peek()
        {
            return _stack.Peek();
        }
        public T Pop()
        {
            return _stack.Pop();
        }

        public bool Empty() => (Count == 0);
        private bool Compare(T data)
        {
            if (Empty()) return false;
            if (greater) return _stack.Peek().CompareTo(data) > 0;
            return data.CompareTo(_stack.Peek())>0;
        }

        public IEnumerator<T> GetEnumerator() => _stack.GetEnumerator();
        

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        
    }
}
