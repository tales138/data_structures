using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estruturadedados
{
    class Pilha<T>
    {
        Entrada _top;

        public void Push(T data)
        {
            _top = new Entrada(_top, data);
        }

        public T Pop()
        {
            if (_top == null)
            {
                throw new Exception("operação inválida");
            }
            T result = _top.Data;
            _top = _top.Next;

            return result;
        }
        class Entrada
        {
            public Entrada Next { get; set; }
            public T Data { get; set; }

            public Entrada(Entrada next, T data)
            {
                Next = next;
                Data = data;
            }
        }
    }
}
