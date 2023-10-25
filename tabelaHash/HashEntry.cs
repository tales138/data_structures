using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estruturadedados
{
    class HashEntry<TKey, TValue>
    {
        public TKey Chave { get; }
        public TValue Valor { get; }
        public HashEntry<TKey, TValue> Proximo { get; set; }

        public HashEntry(TKey chave, TValue valor)
        {
            Chave = chave;
            Valor = valor;
            Proximo = null;
        }
    }

}
