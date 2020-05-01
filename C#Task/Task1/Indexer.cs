using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Indexer
    {
        private double[] array;
        private int begin;
        private int length;

        private bool CheckArguments(int arrayLength, int begin, int length)
        {
            if (begin < 0 || length < 0 || begin + length > arrayLength)
                return false;
            else
                return true;
        }

        private bool CheckIndex(int index)
        {
            if (index < 0 || index >= Length || index + begin >= array.Length)
                return false;
            else
                return true;
        }
        public Indexer(double[] arr, int begin, int length)
        {
            if (CheckArguments(arr.Length, begin, length))
            {
                this.array = arr;
                this.begin = begin;
                this.length = length;
            }
            else 
                throw new ArgumentException();
        }

        public int Length
        {
            get => length;
        }
        public double this[int index]
        {
            get
            {
                if (CheckIndex(index))
                    return array[index + begin];
                else 
                    throw new IndexOutOfRangeException();
            }
            set
            {
                if (CheckIndex(index))
                    array[index + begin] = value; 
                else 
                    throw new IndexOutOfRangeException();
            }
        }  
    }
}
