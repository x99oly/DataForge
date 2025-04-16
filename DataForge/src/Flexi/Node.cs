
namespace DataForge.src.Flexi
{
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T>? Next { get; set; } = null;

        public Node(T value)
        {
            Value = value;
        }
    }
}