using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estruturadedados
{
    class FilaArray<T>
    {
        //private T[] queue;

       public T[] queue = new T[] { };

       
        private int tail = 0;
        private int size = 0;

        public FilaArray()
        {
           
        }

        public T FirstElement()
        {
            T firstElement;
            try
            {
                firstElement = Remove();
                Insert(firstElement);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            var control = false;
            var count = 0;
            while (control == false)
            {
                var current = Remove();
                Insert(current);

                count++;
                if (firstElement.Equals(current))
                {
                    for (var i = 0; i < (count - 1); i++)
                    {
                        var auxRemove = Remove();
                        Insert(auxRemove);
                    }
                    control = true;
                }
            }
            return firstElement;
        }

        public T FirstElementDiverso()//implementação diversa first element
        {
            if(queue.Length == 0)
            {
                throw new Exception("fila vazia");
            }
            return queue[0];
        }

        public T lastElement()//last element elementar
        {
            T last;
            try
            {
                var numberElements = CountElements();//reaproveitando a função countelements que só usa implementação elementar
                last = queue[numberElements - 1];
            }
            catch (Exception e )
            {
                throw new Exception(e.Message);

            }
            
            return last;
        }
        public T lastElementDiverso()//pega o último elemento diverso
        {
            if(queue.Length == 0)
            {
                throw new Exception("fila vazia");
            }
            return queue[queue.Length - 1];
        }
        public bool IsEmptyDiverso()
        {
            if(queue.Length == 0)
            {
                return true;
                
            }
            return false;
        }

        public bool IsEmpty()//verificar se a fila está vazia implementação elementar
        {
            T firstElement;
            bool empty;
            try
            {
                firstElement = Remove();
                Insert(firstElement);
                empty = false;
            }
            catch (Exception e)
            {
                return true;
            }

                var control = false;
                var count = 0;
                while (control == false)
                {
                    var current = Remove();
                    Insert(current);

                    count++;
                    if (firstElement.Equals(current))
                    {
                        for (var i = 0; i < (count - 1); i++)
                        {
                            var auxRemove = Remove();
                            Insert(auxRemove);
                        }
                        control = true;
                    }
                }
               
            return empty;

        } 

        public int CountElements()//fila count elements elementar
        {
            T firstElement;
            try
            {
                firstElement = Remove();
                Insert(firstElement);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            var control = false;
            var count = 0;
            while (control == false)
            {
                var current = Remove();
                Insert(current);
                  
                count++;
                if (firstElement.Equals(current))
                    {
                        for(var i = 0;i < (count - 1); i++)
                        {
                            var auxRemove = Remove();
                            Insert(auxRemove);
                        }
                        control = true;
                    }
            }
            return count;
        }
        public int CountElementsDiverso()
        {
           
            return queue.Length;
        }
        public void Insert(T element)
        {
            Array.Resize(ref queue, size + 1);

            queue[tail] = element;
            size++;
            tail++;

        }

        public T getElementByIndex(int index)//retorna um elemento da fila por index diverso
        {
           
            if(queue.Length == 0)
            {
                throw new Exception("fila vazia");
            }
            var element = queue[index - 1];
            return element;
        }
        

        public int? getIndexByValueElementar(T value)//getIndexByValueElementar elementar questão 9
        {
            int queueSize;
            try
            {
                 queueSize = CountElements();//usando função CountElements() elementar para obter o número de elementos da fila
            }
            catch
            {
                throw new Exception("fila vazia");
            }

            int ?index = null;
            bool control = false;
            for (var i = 0; i < queueSize;i++)
            {
                var current = Remove();
                if (current.Equals(value) && control == false)
                {
                    index = i;
                    control = true;
                }
                Insert(current);
            }
            return index;
        }
        public int getIndexByValue(T value)// getIndexByValue diverso questão 9
        {
            if (queue.Length == 0)
            {
                throw new Exception("pilha vazia");
            }
            else
            {
                int index = Array.IndexOf(queue, value);
                return index;
            }
        }

        public int[] getAllIndexByValueElementar(T value)//getAllIndexByValueElementar elementar questão 10
        {
            int queueSize;
            int[] indexValues = new int[] { };
            try
            {
                queueSize = CountElements();//usando função CountElements() elementar para obter o número de elementos da fila
            }
            catch
            {
                throw new Exception("fila vazia");
            }

           
            int sizeIndexValues = 0;
            for (var i = 0; i < queueSize; i++)
            {
                var current = Remove();
                if (current.Equals(value))
                {
                    Array.Resize(ref indexValues, sizeIndexValues+1);
                    indexValues[sizeIndexValues] = i; 
                    
                    sizeIndexValues++;
                }
                Insert(current);
            }
            return indexValues;
        }
        public int[] getAllIndexByValue(T value)//getAllIndexByValue diverso questão 10
        {

            if (queue.Length == 0)
            {
                throw new Exception("fila vazia");
            }
            else
            {
                int[] indexes = new int[] { };
                var indexAux = 0;

                for (var j = 0; j < queue.Length; j++)
                {
                    if (queue[j].ToString() == value.ToString())
                    {
                        Array.Resize(ref indexes, indexAux + 1);
                        indexes[indexAux] = j;
                    }

                }

                return indexes;
            }
        }

        public T[] getValuesByIndexesElementar(int[]indexes)//getValuesByIndexesElementar elementar questão 11
        {
            int queueSize;
           
            try
            {
                queueSize = CountElements();//usando função CountElements() elementar para obter o número de elementos da fila
            }
            catch
            {
                throw new Exception("fila vazia");
            }

            T[] indexValues = new T[indexes.Length];
           
            int indexesSize = indexes.Length;

            for (var i = 0; i < queueSize; i++)
            {
                var current = Remove();
                if (i == indexes[indexesSize])
                {
                    indexValues[indexes.Length - indexesSize] = current;

                    indexesSize--;
                }
                Insert(current);
            }
            return indexValues;
        }
        public T[] getValuesByIndexes(int[] indexes)//getValuesByIndexes diverso questão 11
        {
            if (queue.Length == 0)
            {
                throw new Exception("fila vazia");
            }
            else
            {
                T[] values = new T[] { };
                Array.Resize(ref values, indexes.Length);

                for (var j = 0; j < indexes.Length; j++)
                {
                    values[j] = queue[indexes[j]];
                }
                return values;
            }
        }

        public T[] getValuesByScliceElementar(int limitA, int limitB)//getValuesByScliceElementar elementar questão 12
        {
            int queueSize;

            try
            {
                queueSize = CountElements();//usando função CountElements() elementar para obter o número de elementos da fila
            }
            catch
            {
                throw new Exception("fila vazia");
            }
            int range = limitB - limitA;

            T[] indexValues = new T[range+1];
           
            

            for (var i = 0; i < queueSize; i++)
            {
                var current = Remove();
                if (i >= limitA && i <= limitB)
                {
                    indexValues[(limitB - limitA) - range] = current;

                    range--;
                }
                Insert(current);
            }
            return indexValues;
        }
        public T[] getValuesBySlice(int limitA, int limitB)//getValuesBySlice diverso questão 12
        {

            if (queue.Length == 0)
            {
                throw new Exception("pilha vazia");
            }
            else
            {
                var values = queue.Skip(limitA - 1).Take(limitB - 1);
                var subset = values.ToArray();
                
                return subset;
            }

        }

        public void deleteElementsElementar()// deleteElements elementar questão 13
        {
            int queueSize;

            try
            {
                queueSize = CountElements();//usando função CountElements() elementar para obter o número de elementos da fila
            }
            catch
            {
                throw new Exception("fila vazia");
            }

            for (var i = 0; i < queueSize; i++)
            {
                Remove();
            }
            Console.Write("Todos os elmentos da fila foram apagados");
        }
        public void deleteElements()//deleteElements diverso questão 13
        {
            Array.Resize(ref queue, 0);
        }


        public void removeByIndexElementar(int indexToRemove)//removeByIndexElementar elementar questão 14
        {
            int queueSize;

            try
            {
                queueSize = CountElements();//usando função CountElements() elementar para obter o número de elementos da fila
            }
            catch
            {
                throw new Exception("fila vazia");
            }

            for (var i = 0; i< queueSize;i++)
            {
                var current = Remove();
                if(i != indexToRemove)
                {
                    Insert(current);
                }
            }
        }
        public void removeByIndex(int indexToRemove)//removeByIndex diverso questão 14
        {
            queue = queue.Where((source, index) => index != indexToRemove).ToArray();
        }

        public void removeByValue(T value)//removeByValue diverso questão 15
        {
            int numIndex = Array.IndexOf(queue, value);
            queue = queue.Where((val, idx) => idx != numIndex).ToArray();
        }

        public void removeByValueElementar(T value)//removeByValue elementar questão 15
        {
            int queueSize;

            try
            {
                queueSize = CountElements();//usando função CountElements() elementar para obter o número de elementos da fila
            }
            catch
            {
                throw new Exception("fila vazia");
            }
            bool controle = false;
            for (var i = 0; i < queueSize; i++)
            {
                var current = Remove();
                if (current.Equals(value) && controle == false)
                {
                    controle = true;
                    
                }
                else
                {
                    Insert(current);
                }
            }
        }

        //Console.WriteLine(String.Join(',', array));
        public void removeAllByValueElementar(T value)//removeAllByValueElementar elementar questao 16
        {
            int queueSize;

            try
            {
                queueSize = CountElements();//usando função CountElements() elementar para obter o número de elementos da fila
            }
            catch
            {
                throw new Exception("fila vazia");
            }

            for (var i = 0; i < queueSize; i++)
            {
                var current = Remove();
                if (!current.Equals(value))
                {
                    Insert(current);
                }
            }
        }
        public void removeAllByValue(T value)//removeAllByValue diverso questão 16
        {
            queue = queue.Where(val => !val.Equals(value)).ToArray();
            queue.Where(
                (val,index)=> index == 2
                );
        }

        public void removeAllByIndexes(int[] indexes)//removeAllByIndexes diverso questão 17
        {
            for (int i = 0; i < indexes.Length; i++)
            {
                queue = queue.Where((source, index) => index != indexes[i]).ToArray();
            }

        }
        public void removeAllByIndexesElementar(int[] indexes)//removeAllByIndexElementar elementar questão 17
        {
            int queueSize;
            try
            {
                queueSize = CountElements();//usando função CountElements() elementar para obter o número de elementos da fila
            }
            catch
            {
                throw new Exception("fila vazia");
            }
            for (var i = 0; i < queueSize; i++)
            {
                var current = Remove();
                if (!indexes.Contains(i))
                {
                    Insert(current);
                }
            }
        }
        public void removeAllBySlice(int limitA, int limitB)//removeAllByIndex diverso questão 18
        {
            if (queue.Length == 0)
            {
                throw new Exception("pilha vazia");
            }
            else
            {

                for (int i = limitA; i == limitB; i++)
                {
                    queue = queue.Where((source, index) => index != i).ToArray();
                }

            }

        }

        public void removeAllBySliceElementar(int limitA,int limitB)//removeAllBySliceElementar elementar questão 18
        {
            int queueSize;

            try
            {
                queueSize = CountElements();//usando função CountElements() elementar para obter o número de elementos da fila
            }
            catch
            {
                throw new Exception("fila vazia");
            }

            for (var i = 0; i < queueSize; i++)
            {
                var current = Remove();
                if (i < limitA || i > limitB)
                {
                    Insert(current);
                }
                
            }
            
        }

        public void setValueInIndex(int index, T value)//setValueInIndex diverso questão 19
        {
            queue[index] = value;
        }
        
        public void setValueInIndexElementar(int index, T value)//setValueInIndex elementar questão 19
        {
            int queueSize;

            try
            {
                queueSize = CountElements();//usando função CountElements() elementar para obter o número de elementos da fila
            }
            catch
            {
                throw new Exception("fila vazia");
            }

            for (var i = 0; i < queueSize; i++)
            {
                var current = Remove();
                if (i == index)
                {
                    Insert(value);
                }
                else
                {
                    Insert(current);
                }
            }
        }

        public void setValuesInIndexes(int[] indexes, T[] values)//setValuesInIndexes diverso questão 20
        {
            for (int i = 0; i < indexes.Length; i++)
            {
                queue[indexes[i]] = values[i];
            }
        }
        public void setValuesInIndexesElementar(int[] indexes, T[] values)//setValuesInIndexes elementar questão 20
        {
            int queueSize;

            try
            {
                queueSize = CountElements();//usando função CountElements() elementar para obter o número de elementos da fila
            }
            catch
            {
                throw new Exception("fila vazia");
            }
            int indexAux = 0;
            for (var i = 0; i < queueSize; i++)
            {
                var current = Remove();
                if (indexes.Contains(i))
                {
                    Insert(values[indexAux]);
                    indexAux++;
                }
                else
                {
                    Insert(current);
                }
            }
        }
        //https://learn.microsoft.com/pt-br/dotnet/csharp/linq/write-linq-queries //link queries

        public T Remove()
        {
         
          
            try { 
                var firstitem = queue[0];
                for (var i = 1; i < size; i++)
                {

                    var aux = queue[i];
                    queue[i - 1] = aux;

                }
                Array.Resize(ref queue, size - 1);
                size = size - 1;
                tail = tail - 1;


                return firstitem;
            }
            catch(Exception e)
            {
                
                throw new Exception("fila vazia");
            }
        }
    }
}

