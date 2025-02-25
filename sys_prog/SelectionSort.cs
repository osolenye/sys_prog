using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sys_prog
{
    public class SelectionSort : IAlgorithm
    {
        private int[] _array;
        private int _step;

        public SelectionSort(int[] array)
        {
            _array = (int[])array.Clone();
            _step = 0;
        }

        public bool NextStep()
        {
            if (_step >= _array.Length - 1)
                return false;

            int minIndex = _step;
            for (int i = _step + 1; i < _array.Length; i++)
            {
                if (_array[i] < _array[minIndex])
                {
                    minIndex = i;
                }
            }

            if (minIndex != _step)
            {
                Swap(_array, _step, minIndex);
            }

            _step++;
            return true;
        }

        public void Reset()
        {
            _step = 0;
        }

        public int[] GetArray() => (int[])_array.Clone();

        private void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
