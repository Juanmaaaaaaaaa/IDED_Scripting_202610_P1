namespace IDED_Scripting_202610_P1
{
    internal class TestMethods
    {
        public static void SeparateElements(Queue<int> input, out Stack<int> included, out Stack<int> excluded)
        {
            included = new Stack<int>();
            excluded = new Stack<int>();

            
            foreach (int num in input)
            {
                bool esIncluido = false;
                int abs;
                if (num < 0)
                    abs = -num;
                else
                    abs = num;


                int raiz = 0;
                for (int i = 1; i * i <= abs; i++)
                {
                    if (i * i == abs)
                    {
                        raiz = i;
                        break;
                    }
                }

                
                if (raiz > 0)
                {
                    if ((raiz % 2 == 1 && num < 0) || (raiz % 2 == 0 && num > 0))
                        esIncluido = true;
                }

                
                if (esIncluido)
                    included.Push(num);
                else
                    excluded.Push(num);
            }

        }
        public static List<int> GenerateSortedSeries(int n) 
        {
            List<int> lista = new List<int>();

            
            for (int i = 1; i <= n; i++)
            {
                int termino;
                if (i % 2 == 0)          
                    termino = i * i;
                else                      
                    termino = -(i * i);

                lista.Add(termino);
            }

            
            for (int i = 0; i < lista.Count - 1; i++)
            {
                for (int j = 0; j < lista.Count - 1 - i; j++)
                {
                    if (lista[j] > lista[j + 1])
                    {
                        int temp = lista[j];
                        lista[j] = lista[j + 1];
                        lista[j + 1] = temp;
                    }
                }
            }

            return lista;
        }

        public static bool FindNumberInSortedList(int target, in List<int> list)
        {
            List<int> copy = new List<int>(list);

            
            for (int i = 0; i < copy.Count - 1; i++)
            {
                for (int j = 0; j < copy.Count - 1; j++)
                {
                    if (copy[j] < copy[j + 1])
                    {
                        int temp = copy[j];
                        copy[j] = copy[j + 1];
                        copy[j + 1] = temp;
                    }
                }
            }

            
            foreach (int value in copy)
            {
                if (value == target)
                    return true;
            }

            return false;
        }

        public static int FindPrime(in Stack<int> list)
        {
            foreach (int value in list)
            {
                int abs;

                if (value < 0)
                    abs = -value;
                else
                    abs = value;

                if (IsPrime(abs))
                    return value;
            }

            return 0;
        }

        public static bool IsPrime(int n)
        {
            if (n < 2)
                return false;

            for (int i = 2; i <= n / 2; i++)
            {
                if (n % i == 0)
                    return false;
            }

            return true;
        }

        public static Stack<int> RemoveFirstPrime(in Stack<int> stack)
        {
            Stack<int> temp = new Stack<int>();
            Stack<int> result = new Stack<int>();

            bool removed = false;

            while (stack.Count > 0)
            {
                int value = stack.Pop();
                int abs;

                if (value < 0)
                    abs = -value;
                else
                    abs = value;

                if (!removed && IsPrime(abs))
                {
                    removed = true;
                }
                else
                {
                    temp.Push(value);
                }
            }

            
            while (temp.Count > 0)
                result.Push(temp.Pop());

            return result;
        }

        public static Queue<int> QueueFromStack(Stack<int> stack)
        {
            Queue<int> queue = new Queue<int>();
            Stack<int> temp = new Stack<int>();

            
            while (stack.Count > 0)
                temp.Push(stack.Pop());

            
            while (temp.Count > 0)
            {
                int value = temp.Pop();
                queue.Enqueue(value);
                stack.Push(value);
            }

            return queue;
        }
    }
}