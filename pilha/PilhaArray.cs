using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estruturadedados
{
    class PilhaArray<T>
    {
        private int top = 0;
        private int size = 0;

        public T[] stack;

        public PilhaArray()
        {

        }

        public int CountElements()//número de elementos da pilha elementar
        {
            T[] pilhaAux = new T[size];

            var index = 1;
            var condition = true;
            while (condition == true)
            {
                try {

                    var current = Pop();
                    pilhaAux[index - 1] = current;
                    index++;
                }
                catch (Exception e)
                {
                    condition = false;
                    if (index == 1)
                    {
                        index = 0;
                    }
                    Console.Write(e.Message + "\n");
                }
            }

            if (index == 0)
                return 0;

            var r = 2;
            for (var i = 0; i < (index - 1); i++)
            {

                var controle = index - r;

                Push(pilhaAux[controle]);

                r++;
            }
            return (index - 1);

        }
        public int CountElementsDiverso()//retorna o tamanho da pilha diverso
        {
            return stack.Length;
        }

        public T lastElement()//last element divreso
        {
            if (stack.Length == 0)
            {
                throw new Exception("pilha vazia");

            }
            return stack[0];
        }

        public T lastElementElementar()//last element elementar
        {
            T[] pilhaAux = new T[size];
            T last;
            var index = 1;
            var condition = true;
            while (condition == true)
            {
                try
                {

                    var current = Pop();
                    pilhaAux[index - 1] = current;
                    index++;
                }
                catch (Exception e)
                {
                    condition = false;
                    if (index == 1)
                    {
                        index = 0;
                    }

                }

            }


            if (index == 0)
                throw new Exception("pilha vazia");
            else
            {
                last = pilhaAux[index - 1];
            }

            var r = 2;
            for (var i = 0; i < (index - 1); i++)
            {

                var controle = index - r;

                Push(pilhaAux[controle]);

                r++;
            }


            return last;

        }

        public bool IsEmptyElementar() {//verifica se a pilha está vazia elementar
            T[] pilhaAux = new T[size];

            var index = 1;
            var condition = true;
            while (condition == true)
            {
                try
                {
                    var current = Pop();
                    pilhaAux[index - 1] = current;
                    index++;
                }
                catch (Exception e)
                {
                    condition = false;
                    if (index == 1)
                    {
                        index = 0;
                    }
                }
            }

            if (index == 0)
            {

                return true;
            }


            var r = 2;
            for (var i = 0; i < (index - 1); i++)
            {

                var controle = index - r;

                Push(pilhaAux[controle]);

                r++;
            }

            return false;
        }

        public bool IsEmpty()//verifica se a pilha está vazia diverso
        {
            if (stack.Length > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public T getElementById(int index)//procura o elemento por id diverso
        {

            if (IsEmpty())
            {
                throw new Exception("Pilha vazia");
            }

            var element = stack[index - 1];
            return element;
        }

        public T PeekDiverso()//retorna o primeiro elemento da pilha
        {
            if (stack.Length == 0)
            {
                throw new Exception("Pilha está vazia");
            }
            else
            {
                var firstElementIndex = stack.Length;
                var firstElement = stack[firstElementIndex - 1];
                return firstElement;
            }
            //Array.Resize(ref stack, size - 1);


        }

        public T Peek()//implementação peek elementar
        {
            try
            {
                var firstElement = Pop();
                Push(firstElement);
                return firstElement;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int? getIndexByValueElementar(T value)//getIndexByValueElementar elementar questão 9
        {
            int stackSize;

            try
            {
                stackSize = CountElements();//usando função CountElements() elementar para obter o número de elementos da fila
            }
            catch
            {
                throw new Exception("fila vazia");
            }

            T[] pilhaAux = new T[stackSize];
            bool indexCondition = true;
            int ?indexValue = null;

            for (var i = 0; i< stackSize;i++)
            {
                var current = Pop();
                pilhaAux[i] = current;
                if (current.Equals(value) && indexCondition == true)
                {
                    indexCondition = false;
                    indexValue = i;
                }
            }
            transferStackDataElementar(pilhaAux,stackSize);
            return indexValue;
            
        }
        public int getIndexByValue(T value)// getIndexByValue diverso questão 9
        {
            if (stack.Length == 0)
            {
                throw new Exception("pilha vazia");
            }
            else
            {
                int index = Array.IndexOf(stack, value);
                return index;
            }
        }

        public int[] getAllIndexByValueElementar(T value)//getAllIndexByValueElementar elementar questão 10
        {
            int stackSize;

            try
            {
                stackSize = CountElements();//usando função CountElements() elementar para obter o número de elementos da fila
            }
            catch
            {
                throw new Exception("fila vazia");
            }

            T[] pilhaAux = new T[stackSize];
            int[] indexValues = new int[] { };
            int indexAux = 0;
            for (var i = 0; i < stackSize; i++)
            {
                var current = Pop();
                pilhaAux[i] = current;
                if (current.Equals(value))
                { 
                    Array.Resize(ref indexValues, indexAux+1);
                    indexValues[indexAux] = i;
                    indexAux++;
                }

            }
            transferStackDataElementar(pilhaAux,stackSize);
            return indexValues;
        }
        public int[] getAllIndexByValue(T value)//getAllIndexByValue diverso questão 10
        {
           
            if (stack.Length == 0)
            {
                throw new Exception("pilha vazia");
            }
            else
            {
                int[] indexes = new int[] { };
                var indexAux = 0;
               
                for (var j = 0; j < stack.Length; j++)
                {
                    if (stack[j].ToString() == value.ToString())
                    {
                        Array.Resize(ref indexes, indexAux + 1);
                        indexes[indexAux] = j;
                    }

                }

                return indexes;
            }
        }

        public T[] getValuesByIndexesElementar(int[] indexes)//getValuesByIndexesElementar elementar questão 11
        {
            int stackSize;

            try
            {
                stackSize = CountElements();//usando função CountElements() elementar para obter o número de elementos da fila
            }
            catch
            {
                throw new Exception("fila vazia");
            }

            T[] pilhaAux = new T[stackSize];
            T[] indexValues = new T[] { };
            int indexesControle = 0;

            for (var i = 0; i < stackSize; i++)
            {
                var current = Pop();
                pilhaAux[i] = current;

                if(i == indexes[indexesControle])
                {
                    Array.Resize(ref indexValues, indexesControle+1);
                    indexValues[indexesControle] = current;
                    indexesControle++;
                }
            }

            transferStackDataElementar(pilhaAux,stackSize);

            return indexValues;

        }
        public T[] getValuesByIndexes(int[] indexes)//getValuesByIndexes diverso questão 11
        {
            if (stack.Length == 0)
            {
                throw new Exception("pilha vazia");
            }
            else
            {
                T[] values = new T[] { };
                Array.Resize(ref values, indexes.Length);

                for (var j = 0; j < indexes.Length; j++)
                {
                    values[j] = stack[indexes[j]];
                }
                return values;
            }
        }

        public T[] getValuesBySlice(int limitA, int limitB)//getValuesBySlice diverso questão 12
        {
            
            if (stack.Length == 0)
            {
                throw new Exception("pilha vazia");
            }
            else
            {
                var values = stack.Skip(limitA - 1).Take(limitB - 1);
                var subset = values.ToArray();
                return subset;
            }
            
        }
        public T[] getValuesByScliceElementar(int limitA, int limitB)//getValuesByScliceElementar elementar questão 12
        {
            int stackSize;

            try
            {
                stackSize = CountElements();//usando função CountElements() elementar para obter o número de elementos da fila
            }
            catch
            {
                throw new Exception("fila vazia");
            }

            T[] pilhaAux = new T[stackSize];
            T[] indexValues = new T[] { };
            int indexesControle = 0;

            for (var i=0;i<stackSize;i++)
            {
                var current = Pop();
                pilhaAux[i] = current;
                if (i >= limitA && i <= limitB)
                {
                    Array.Resize(ref indexValues, indexesControle+1);
                    indexValues[indexesControle] = current;
                    indexesControle++;
                }
            }

            transferStackDataElementar(pilhaAux, stackSize);

            return indexValues;

        }

        public void deleteElements()//deleteElements diverso questão 13
        {
            Array.Resize(ref stack,0);
        }
        public void deleteElementsElementar()// deleteElements elementar questão 13
        {
            int stackSize;

            try
            {
                stackSize = CountElements();//usando função CountElements() elementar para obter o número de elementos da fila
            }
            catch
            {
                throw new Exception("fila vazia");
            }

            for (var i = 0; i < stackSize; i++)
            {
                Pop();

            }
            Console.Write("Todos os elmentos da pilha foram apagados");

        }

        public void removeByIndexElementar(int indexToRemove)//removeByIndexElementar elementar questão 14
        {
            int stackSize;

            try
            {
                stackSize = CountElements();//usando função CountElements() elementar para obter o número de elementos da fila
            }
            catch
            {
                throw new Exception("fila vazia");
            }


            T[] pilhaAux = new T[stackSize - 1];
            int indexAux = 0;
            for (var i = 0; i < stackSize; i++)
            {
                var current = Pop();
                if (i != indexToRemove)
                {
                    pilhaAux[indexAux] = current;
                    indexAux++;
                }
            }
            transferStackDataElementar(pilhaAux, stackSize-1);

           
            
        }
        public void removeByIndex(int indexToRemove)//removeByIndex diverso questão 14
        {
            stack = stack.Where((source, index) => index != indexToRemove).ToArray();
        }

        public void removeByValueElementar(T value)//removeByValueElementar questão 15
        {
            int stackSize;

            try
            {
                stackSize = CountElements();//usando função CountElements() elementar para obter o número de elementos da fila
            }
            catch
            {
                throw new Exception("fila vazia");
            }
            
            T[] pilhaAux = new T[stackSize - 1];
           
            bool controle = false;
            int indexAux = 0;
            for (var i =0;i < stackSize; i++)
            {
                var current = Pop();
                if (current.Equals(value) && controle == false)
                {
                    controle = true;
                }
                else
                {
                    pilhaAux[indexAux] = current;
                    indexAux++;
                }
            }

            transferStackDataElementar(pilhaAux, stackSize);

        }
        public void removeByValue(T value)//removeByValue diverso questão 15
        {
            int numIndex = Array.IndexOf(stack, value);
            stack = stack.Where((val, idx) => idx != numIndex).ToArray();
        }

        public void removeAllByValue(T value)//removeAllByValue diverso questão 16
        {
            stack = stack.Where(val => val.Equals(value)).ToArray();
        }
        public void removeAllByValueElementar(T value)//removeAllByValueElementar elementar questao 16
        {
            int stackSize;

            try
            {
                stackSize = CountElements();//usando função CountElements() elementar para obter o número de elementos da fila
            }
            catch
            {
                throw new Exception("fila vazia");
            }

            T[] pilhaAux = new T[] { };
            int indexAux = 0;
            for (var i=0;i< stackSize;i++)
            {
                var current = Pop();
                if (!current.Equals(value))
                {
                    Array.Resize(ref pilhaAux, indexAux + 1);
                    pilhaAux[indexAux] = current;
                    indexAux++;
                }
            }

            transferStackDataElementar(pilhaAux,stackSize-1);

        }

        public void removeAllByIndexes(int[] indexes)//removeAllByIndexes diverso questão 17
        {
            for (int i = 0; i < indexes.Length; i++)
            {
                stack = stack.Where((source, index) => index != indexes[i]).ToArray();
            }

        }
        public void removeAllByIndexesElementar(int[] indexes)//removeAllByIndexElementar elementar questão 17
        {
            int stackSize;

            try
            {
                stackSize = CountElements();//usando função CountElements() elementar para obter o número de elementos da fila
            }
            catch
            {
                throw new Exception("fila vazia");
            }

            int pilhaAuxsize = stackSize - indexes.Length;
            T[] pilhaAux = new T[pilhaAuxsize];
            int indexAux = 0;
            for (var i = 0; i < stackSize; i++)
            {
                var current = Pop();
                if (!indexes.Contains(i))
                {
                    pilhaAux[indexAux] = current;
                    indexAux++;
                }
            }
            transferStackDataElementar(pilhaAux, pilhaAuxsize);
           
             

        }

        public void removeAllBySlice(int limitA,int limitB)//removeAllByIndex diverso questão 18
        {
            if (stack.Length == 0)
            {
                throw new Exception("pilha vazia");
            }
            else
            {
               
                for (int i = limitA; i == limitB; i++)
                {
                    stack = stack.Where((source, index) => index != i).ToArray();
                }

            }

        }
        public void removeAllBySliceElementar(int limitA, int limitB)//removeAllBySliceElementar elementar questão 19
        {
            int stackSize;

            try
            {
                stackSize = CountElements();//usando função CountElements() elementar para obter o número de elementos da fila
            }
            catch
            {
                throw new Exception("fila vazia");
            }

            int range = (limitB - limitA) + 1;
            int pilhaAuxSize = stackSize - range;

            T[] pilhaAux = new T[pilhaAuxSize];
           
            int indexesControle = 0;

            for (var i = 0; i < stackSize; i++)
            {
                var current = Pop();
                
                if (i < limitA || i > limitB)
                {
                    pilhaAux[indexesControle] = current;
                    indexesControle++;  
                }
            }

            transferStackDataElementar(pilhaAux, pilhaAuxSize);

        }
        public void setValueInIndex(int index,T value)//setValueInIndex diverso questão 19
        {
            stack.SetValue(value, index);
        }

        public void setValueInIndexElementar(int index, T value)//setValueInIndexElementar elementar questão 19
        {
            int stackSize;

            try
            {
                stackSize = CountElements();//usando função CountElements() elementar para obter o número de elementos da fila
            }
            catch
            {
                throw new Exception("fila vazia");
            }


            T[] pilhaAux = new T[stackSize];
            int indexAux = 0;
            for (var i = 0; i < stackSize; i++)
            {
                var current = Pop();
                if (i == index)
                {
                    pilhaAux[indexAux] = value;
                    indexAux++;
                }
                else
                {
                    pilhaAux[indexAux] = current;
                    indexAux++;
                }
            }
            transferStackDataElementar(pilhaAux, stackSize);
        }

        public void setValuesInIndexes(int[]indexes,T[]values)//setValuesInIndexes diverso questão 20
        {
            for (int i = 0;i < indexes.Length;i++)
            {
                stack[indexes[i]] = values[i];
            }
        }

        public void setValuesInIndexesElementar(int[] indexes, T[] values)//setValuesInIndexesElementar elementar questão 20
        {
            int stackSize;

            try
            {
                stackSize = CountElements();//usando função CountElements() elementar para obter o número de elementos da fila
            }
            catch
            {
                throw new Exception("fila vazia");
            }


            T[] pilhaAux = new T[stackSize];
            int valuesIndex = 0;
           
            for (var i = 0; i < stackSize; i++)
            {
                var current = Pop();
                if (indexes.Contains(i))
                {
                    
                    pilhaAux[i] = values[valuesIndex];
                    valuesIndex++;
                }
                else
                {
                    pilhaAux[i] = current; 
                }
            }
            transferStackDataElementar(pilhaAux, stackSize);
        }

        private void transferStackDataElementar(T[] stackdata,int count)//elementar
            {
           
            var r = 1;
            for (var i = 0; i < count; i++)
            {
                Push(stackdata[count - r]);

                r++;
            }
        }

        private void transferStackData(T[] stackdata)// transferStackData diverso
        {
            Array.Reverse(stackdata);
            foreach (var data in stackdata)
            {
                Push(data);
            }
        }
        //https://stackoverflow.com/questions/496896/how-to-delete-an-element-from-an-array-in-c-sharp
        public void Push(T element)
        {
            Array.Resize(ref stack, size + 1);
            stack[top] = element;
            size++;
            top++;
        }


        public T Pop()
        {
            if (IsEmpty())
            {
               
                    throw new Exception("Pilha vazia");
               
            }
            else
            {
                top--;
                var elementTop = stack[top];
                Array.Resize(ref stack, size - 1);
                size--;
                return elementTop;


            }

        }
    }
}
