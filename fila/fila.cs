using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estruturadedados
{
    //implementando uma fila com linked list(lista encadeada)
    class Fila<T>
    {

        // the node class
        private class Node<T>
        {
            public T Element { get; set; }
            public Node<T> Next { get; set; }

            public Node(T e)
            {
                Element = e;
                Next = null;
            }


        }

        private Node<T> _front;
        private Node<T> _rear;
        private int _count;

        public Fila()
        {
            _front = null;
            _rear = null;
            _count = 0;
        }
       
      
        // returns whether the queue is empty
        public bool IsEmpty()
        {
            if (_count == 0)
                return true;
            return false;
            
        }

        // Inserts 
        public void Insert(T element)
        {
            Node<T> v = new Node<T>(element);
            if (_count == 0) _front = v;
            else _rear.Next = v;
            _rear = v;
            _count++;
        }

        // Removes 
        public T Remove()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Fila vazia");
                return default(T);
            }
            T element = _front.Element;
            _front = _front.Next;
            _count--;
            if (_count == 0) _rear = null;
            return element;
        }

       
    }
}
