using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//tabela hash usando lista com keyvaluepair
namespace estruturadedados
{
    class TabelaHashLista<TKey, TValue>
    {
        private const int TamanhoDaTabela = 10;
        private List<KeyValuePair<TKey, TValue>>[] tabela;

        public TabelaHashLista()
        {
            tabela = new List<KeyValuePair<TKey, TValue>>[TamanhoDaTabela];
        }

        private int CalcularHashCode(TKey chave)
        {
            return chave.GetHashCode() % TamanhoDaTabela;
        }

        public void Adicionar(TKey chave, TValue valor)
        {
            int indice = CalcularHashCode(chave);
            if (tabela[indice] == null)
            {
                tabela[indice] = new List<KeyValuePair<TKey, TValue>>();
            }

            // Verificar se a chave já existe na lista
            foreach (var elemento in tabela[indice])
            {
                if (elemento.Key.Equals(chave))
                {
                    throw new ArgumentException("Chave já existe na tabela.");
                }
            }

            tabela[indice].Add(new KeyValuePair<TKey, TValue>(chave, valor));
        }

        public TValue Obter(TKey chave)
        {
            int indice = CalcularHashCode(chave);

            if (tabela[indice] != null)
            {
                foreach (var elemento in tabela[indice])
                {
                    if (elemento.Key.Equals(chave))
                    {
                        return elemento.Value;
                    }
                }
            }

            throw new KeyNotFoundException("Chave não encontrada na tabela.");
        }
    }
}
