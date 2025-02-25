using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sys_prog
{
    public class BubbleSort : IAlgorithm
    {
        private int[] _array;
        private int _step;

        public BubbleSort(int[] array)
        {
            _array = (int[])array.Clone();
            _step = 0;
        }

        public bool NextStep()
        {
            if (_step >= _array.Length - 1)
                return false;

            for (int i = 0; i < _array.Length - _step - 1; i++)
            {
                if (_array[i] > _array[i + 1])
                {
                    Swap(_array, i, i + 1);
                }
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
