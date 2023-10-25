using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estruturadedados
{

    class Node
    {
        public Node LeftNode { get; set; }
        public Node RightNode { get; set; }
        public int Data { get; set; }
    }
    class ArvoreBinaria
    {

        public Node Root { get; set; }

        public int[] PreOrder(Node parent = null)// questão 22 // visita a raiz, percorre a esquerda e a direita
        {
            List<int> termsList = new List<int>();
            if (parent == null)
                parent = Root;
            termsList.Add(parent.Data);
            if (parent.LeftNode != null)
                PreOrder(parent.LeftNode);
            if (parent.RightNode != null)
                PreOrder(parent.RightNode);
            int[] array = termsList.ToArray();

            return array;
        }

        public int[] InOrder(Node parent)//questão 23 //percorre a esquerda,visita a raiz e percorre a direita
        {
            List<int> termsList = new List<int>();
            if (parent == null)
                parent = Root;
            termsList.Add(parent.Data);
            if (parent.LeftNode != null)
                InOrder(parent.LeftNode);
            if (parent.RightNode != null)
                InOrder(parent.RightNode);
            int[] array = termsList.ToArray();

            return array;
        }

        public int[] PostOrder(Node parent)//questão 24 // percorre a esquerda,percorre a direita e visita a raiz
        {
            List<int> termsList = new List<int>();
            if (parent == null)
                parent = Root;
            termsList.Add(parent.Data);
            if (parent.LeftNode != null)
                PostOrder(parent.LeftNode);
            if (parent.RightNode != null)
                PostOrder(parent.RightNode);
            int[] array = termsList.ToArray();

            return array;
        }

        public int Height(Node parent)//questão 26 // retorna a altura da árvore
        {
            int hleft = 0;
            int hright = 0;
            if (parent == null)
                parent = Root;
            if (parent.LeftNode != null)
                hleft++;
                PostOrder(parent.LeftNode);
            if (parent.RightNode != null)
                hright++;
                PostOrder(parent.RightNode);
            if (hright > hleft)
                return hright + 1;
            return hleft + 1;
        }

        public int[] EmNivel(Node parent = null)//questão 25 // retorna árvore em nível
        {
            if (parent == null)
                parent = Root;
            Queue<Node> fila = new Queue<Node>();
            List<int> termsList = new List<int>();
            fila.Enqueue(parent);
            while (fila.Count >0)
            {
                parent = fila.Dequeue();
                if (parent.LeftNode != null)
                    fila.Enqueue(parent.LeftNode);
                if (parent.RightNode != null)
                    fila.Enqueue(parent.RightNode);
                termsList.Add(parent.Data);
            }
            int[] arrayNivel = termsList.ToArray();
            return arrayNivel;
        }

        public int Count(Node parent = null,int count)//questão 27 // retorn a quantidade de elementos de uma árvore binária
        {
            int countAux = count;
            countAux++;
            if (parent == null)
                parent = Root;
            if (parent.LeftNode != null)
                Count(parent.LeftNode, countAux);
            if (parent.RightNode != null)
                Count(parent.RightNode, countAux);
                
            Console.WriteLine(count);
            return countAux;
        }

        public int[] Folhas(Node parent = null)//questão 28 // retorna as fohas da árvore
        {

             Queue<Node> fila = new Queue<Node>();
             List<int> folhasList = new List<int>();
             fila.Enqueue(parent);
             while (fila.Count > 0)
             {
                 parent = fila.Dequeue();
                 if (parent.LeftNode == null && parent.RightNode == null)
                     fila.Enqueue(parent);
                 folhasList.Add(parent.Data);
             }
             int[] arrayFolhas = folhasList.ToArray();
             Console.WriteLine(arrayFolhas.Length);
             return arrayFolhas;
        }

    }
}
