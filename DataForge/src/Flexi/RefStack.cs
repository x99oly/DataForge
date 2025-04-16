
using System.Text;

namespace DataForge.src.Flexi
{
    public class RefStack<T>
    {
        public Node<T>? Last { get; private set; }
        public int Count { get; private set; } = 0;

        public RefStack(){}
        public RefStack(T val)
        {
            PutOn(val);         
        }

        public void PutOn(T val)
        {
            var newNode = new Node<T>(val);
            newNode.Next = Last;
            Last = newNode;  
            Count++;        
        }

        public T RipOff()
        {
            if (Last == null) 
                throw new InvalidOperationException("Any value to exclude.");

            T ripped = Last.Value;

            var temp = Last.Next;
            Last.Next = null;
            Last = temp;
            Count--;

            return ripped;
        }

        public override string ToString()
        {
            if (Last == null)
                return "empty";

            StringBuilder sb = new StringBuilder();
            for (Node<T> i = Last; i != null; i = i.Next){
                sb.Append($"{i.Value} ");
            }
            return sb.ToString();
        }

    }
}