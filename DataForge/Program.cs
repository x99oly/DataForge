using System;  // Para Console e InvalidOperationException

class Program
{
    static void Main(string[] args)
    {
        RefStack<string> stack = new RefStack<string>();
        string seq = Console.ReadLine();
        
        for(int i=0; i<seq.Length; i++)
        {
            try
            {
                if(seq[i] == ']')
                {
                    if(stack.RipOff() != "["){
                        Console.WriteLine("errada");
                        return;
                    }
                }
                else if(seq[i]==')')
                {
                    if(stack.RipOff() != "("){
                        Console.WriteLine("errada");
                        return;
                    }
                }
                else
                {
                    stack.PutOn(seq[i].ToString());
                }
            }
            catch(InvalidOperationException e)
            {
                string p = e.Message;
                Console.WriteLine("errada"); 
                return;
            }
            catch(Exception e)
            {
                string p = e.Message;
                Console.WriteLine("errada");
                return;
            }
        }
        if (stack.Count == 0){
            Console.WriteLine("correta");
        }
    }
}

public class RefStack<T>
{
    public Node<T> Last { get; private set; }
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
}

public class Node<T>
{
    public T Value { get; set; }
    public Node<T> Next { get; set; } = null;

    public Node(T value)
    {
        Value = value;
    }
}
