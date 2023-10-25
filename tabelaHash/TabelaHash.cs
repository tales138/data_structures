using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//tabela hash sem usar auxilio de bibliotecas nativas
namespace estruturadedados
{
    class TabelaHash<TKey, TValue>
    {
        private int capacidade;
        private HashEntry<TKey, TValue>[] tabela;

        public TabelaHash(int capacidade)
        {
            this.capacidade = capacidade;
            tabela = new HashEntry<TKey, TValue>[capacidade];
        }

        private int CalcularHashCode(TKey chave)
        {
            int hashCode = chave.GetHashCode();
            return Math.Abs(hashCode) % capacidade; // garantir que o resultado seja positivo.
        }

        public void Adicionar(TKey chave, TValue valor)
        {
            int indice = CalcularHashCode(chave);

            if (tabela[indice] == null)
            {
                tabela[indice] = new HashEntry<TKey, TValue>(chave, valor);
            }
            else
            {
                // Lidando com colisões usando encadeamento.
                HashEntry<TKey, TValue> atual = tabela[indice];
                while (atual.Proximo != null)
                {
                    if (atual.Chave.Equals(chave))
                    {
                        throw new ArgumentException("Chave já existe na tabela.");
                    }
                    atual = atual.Proximo;
                }
                atual.Proximo = new HashEntry<TKey, TValue>(chave, valor);
            }
        }

        public TValue Obter(TKey chave)
        {
            int indice = CalcularHashCode(chave);
            HashEntry<TKey, TValue> atual = tabela[indice];

            while (atual != null)
            {
                if (atual.Chave.Equals(chave))
                {
                    return atual.Valor;
                }
                atual = atual.Proximo;
            }

            throw new KeyNotFoundException("Chave não encontrada na tabela.");
        }
    }

}
