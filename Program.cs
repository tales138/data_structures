using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estruturadedados
{
    class Program
    {
        static void Main(string[] args)
        {
            var arvore = new ArvoreBinaria();
            Node n0 = new Node();
            Node n1 = new Node();
            Node n2 = new Node();
            Node n3 = new Node();
            Node n4 = new Node();
            Node n5 = new Node();
           
            n0.Data = 1;
            n1.Data = 2;
            n2.Data = 5;
            n3.Data = 3;
            n4.Data = 6;
            n5.Data = 7;
            n0.LeftNode = n1;
            n0.RightNode = n2;
            n1.LeftNode = n2;
            n1.RightNode = n3;
            n2.LeftNode = n4;
            n2.RightNode = n5;
            arvore.Root = n0;
            arvore.Count(n0);
            arvore.PreOrder();
            

            Console.WriteLine("fim da árvore ------------------------------");
            /**Resoluções das questões 1 a 3**/
            var pilhaListaEncadeada = new Pilha<int>();// cria pilha com lista encadeada
            var pilhaArray = new PilhaArray<int>();//cria pilha com array
            var filaListaEncadeada = new Fila<int>();//cria fila com lista encadeada
            var filaArray = new FilaArray<int>();//cria fila com array

            

            for (var i = 1; i < 6; i++)
            {
                pilhaListaEncadeada.Push(i);//inserindo novo elemento na pilha com push lista encadeada
            }

            for (var i = 1; i < 6; i++)
            {
                pilhaArray.Push(i);//inserindo novo elemento na pilha com push array
            }
            for (var i = 1; i < 6; i++)
            {
                filaArray.Insert(i);//inserindo novo elemento na fila com insert array
            }
            for (var i = 1; i < 6; i++)
            {
                filaListaEncadeada.Insert(i);//inserindo novo elemento na fila com insert lista encadeada
            }


            /**Fim das resoluções das questões 1 a 3**/


            /**Resoluções das questões 4 a 8 usando pilhas**/

            //questão 4
            Console.WriteLine("Resultado : "+pilhaArray.getIndexByValue(2));
            try
            {
                Console.WriteLine("Peek elementar pilha  : " + pilhaArray.Peek());//Implementação elementar peek com array
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }

            try
            {
                Console.WriteLine("Peek diverso pilha  : " + pilhaArray.PeekDiverso());//Implementação diversa peek com array
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }


            //questão 5
            if (pilhaArray.IsEmptyElementar())//Implementação elementar verifica se pilha está vazia
            {
                Console.WriteLine("pilha vazia");
            }
            else
            {
                Console.WriteLine("pilha não está");
            }

            if (pilhaArray.IsEmpty())//Implementação diversa verifica se pilha está vazia
            {
                Console.WriteLine("pilha vazia");
            }
            else
            {
                Console.WriteLine("pilha não está");
            }


            //questão 6
            try
            {
                Console.WriteLine("Número de elementos pilha elementar : " + pilhaArray.CountElements());//Implementação elementar número de elementos da pilha 
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }

            if(pilhaArray.CountElementsDiverso() == 0)
            {
                Console.WriteLine("pilha vazia");
            }
            else
            {
                Console.WriteLine("Número de elementos pilha elementar : " + pilhaArray.CountElementsDiverso()+"\n");
            }


            //questão 7
            try
            {
                Console.WriteLine("último elemento da pilha elementar : " + pilhaArray.lastElementElementar());//Implementação elementar último elemento da pilha 
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
            try
            {
                Console.WriteLine("último elemento da pilha diverso : " + pilhaArray.lastElement());//Implementação diversa último elemento da pilha
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }

            //questão 8
            try
            {
                Console.WriteLine("GetElmentById pilha diverso : " + pilhaArray.getElementById(1));//retorna o elemento por indice diverso
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }


            /**Fim das resoluções das questões 4 a 8 usando pilhas**/

            /**Resoluções das questões 4 a 8 usando filas**/

            //questão 4

            try
            {
                Console.WriteLine("Primeiro elmento da Fila elementar : " + filaArray.FirstElement());//Implementação primeiro elemento da fila elementar
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }

            try
            {
                Console.WriteLine("Primeiro elmento da Fila diverso : " + filaArray.FirstElementDiverso());//Implementação primeiro elemento da fila diverso
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //questão 5
        
                                                                                                             
            try
            {
                Console.WriteLine("IsEmpty fila elementar : " + filaArray.IsEmpty()+"fila não está vazia");//Implementação verifica se a fila está vazia elementar
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }

            if (filaArray.IsEmptyDiverso())//Implementação verifica se a fila está vazia diverso
            {
                Console.WriteLine("fila vazia");
            }
            else
            {
                Console.WriteLine("fila não está vazia");
            }

            //questão 6 
            

            try
            {
                Console.WriteLine("Número de elementos da fila elementar : " + filaArray.CountElements() + " \n");//Implementação número de elementos da fila elementar
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }

            if(filaArray.CountElementsDiverso() == 0)
            {
                Console.WriteLine("fila vazia \n");
            }
            else
            {
                Console.WriteLine("fila não está vazia ");
            }
            //questão 7
           
            try
            {
                Console.WriteLine("Último elemento da fila elementar : " + filaArray.lastElement() + " \n");//Implementação último elemento da fila elementar
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }

            try
            {
                Console.WriteLine("último elemento da fila diverso : " + filaArray.lastElementDiverso() + " \n");//Implementação número de elementos da fila diverso
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
            //questão 8
            try
            {
                Console.WriteLine("getElementByIndex diverso : " + filaArray.getElementByIndex(1) + " \n");//Implementação getElementByIndex da fila diverso
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
           


            /**Resoluções das questões 4 a 8 usando filas**/


           

        }
    }
}
