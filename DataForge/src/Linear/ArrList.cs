using System.Text;

namespace DataForge.src.Linear
{
    public class ArrList<T>
    {
        public T? Value { get; set; }
        private T[] _arr;
        
        public int Count { get; private set; } = 0;

        public int Capacity => _arr.Length;

        public ArrList()
        {
            _arr = new T[4];
        }
        public ArrList(T param) : this()
        {
            Value = param;            
        }

        public int CountIncidence(T value)
        {
            int count = 0;
            for (int i=0; i<Count; i++){
                if (AreEquals(_arr[i], value)) count++;
            }
            return count;
        }

        /// <summary>
        /// Verifies the existence of a value in the list.
        /// </summary>
        /// <param name="value">The value to be found.</param>
        /// <returns>The index of the position if the value exists; otherwise, -1.</returns>
        public int Contains(T value)
        {
            for (int i = 0; i < Count; i++){
                if (AreEquals(_arr[i], value)) return i;
            }
            return -1;
        }

        /// <summary>
        /// Removes the first occurrence of the specified value from the list.
        /// </summary>
        /// <param name="value">The value to remove.</param>
        /// <returns>The removed value.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the value does not exist in the list.
        /// </exception>
        public T RemoveItem(T value)
        {
            return Remove(Contains(value));
        }

        /// <summary>
        /// Removes the last item of the list.
        /// </summary>
        /// <returns>
        /// Returns the removed value if the list is not empty.
        /// Throws an exception if the list is empty.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when attempting to remove an item from an empty list.
        /// </exception>
        public T RemoveLast()
        {
            return RemoveT(Count-1);
        }

        /// <summary>
        /// Removes the first item of the list.
        /// </summary>
        /// <returns>
        /// Returns the removed value if the list is not empty.
        /// Throws an exception if the list is empty or the position is invalid.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when attempting to remove an item from an empty list.
        /// </exception>
        public T Remove()
        {
            return RemoveT(0);
        }

        /// <summary>
        /// Removes an item at the specified position in the list.
        /// </summary>
        /// <param name="n">The position of the item to remove.</param>
        /// <returns>
        /// Returns the removed value if the list is not empty and the position is valid.
        /// Throws an exception if the list is empty or the position is out of bounds.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when attempting to remove an item from an empty list or if the given position is invalid.
        /// </exception>
        public T Remove(int n)
        {
            return RemoveT(n);
        }

        /// <summary>
        /// Internal method to remove an item from the specified position in the array.
        /// </summary>
        /// <param name="pos">The position of the item to remove.</param>
        /// <returns>
        /// Returns the removed value if the position is valid.
        /// Throws an exception if the list is empty or the position is out of bounds.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the list is empty or if the specified position is greater than the number of elements.
        /// </exception>
        private T RemoveT(int pos)
        {
            if (Count == 0) throw new InvalidOperationException("Não há valores a serem removidos.");
            if (pos >= Count) throw new InvalidOperationException("Não há valores na posição informada");

            T removed;

            if (pos == Count-1)
            {
                removed = _arr[pos];
                Count--;
                return removed;
            }

            removed = _arr[pos];
            MoveElementsToOutInArr(pos);

            Count--;
            return removed;
        }

        public void Add(T value, int pos)
        {
            if (Count == _arr.Length - 1) ResizeArr();

            if (pos >= Count){
                AddT(value, Count);
            }
            else{
                MoveElementsToPutInArr(pos);
                AddT(value, pos);  
            }          
        }

        public void Add(T value)
        {
            Add(value,0);
        }

        public void AddEnd(T value)
        {
            Add(value, Count);
        }

        private void AddT(T value, int pos)
        {
            _arr[pos] = value;
            Count++;
        }
        
        private void MoveElementsToPutInArr(int pos)
        {
            for (int i = Count+1; i > pos; i--)
            {
                _arr[i] = _arr[i-1];
            }
        }
 
        private void MoveElementsToOutInArr(int pos)
        {
            for (int i = pos; Count > i; i++)
            {
                _arr[i] = _arr[i+1];
            }
        }

        private void ResizeArr()
        {
            T[] arr = new T[_arr.Length * 2];

            for (int i = 0; i < _arr.Length; i++){
                arr[i] = _arr[i];
            }

            _arr = arr;
        }
       
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (Count == 0) return "empty";

            for (int i = 0; i < Count; i ++)
            {
                sb.Append($"{_arr[i]} ");
            }
            return sb.ToString();
        }

        public bool AreEquals(T one, T two)
        {
            if (one == null && two == null) return true;
            if (one == null || two == null) return false;

            return one.Equals(two);
        }
    }
}