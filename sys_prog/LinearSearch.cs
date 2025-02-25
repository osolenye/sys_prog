using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sys_prog
{
    public class LinearSearch : IAlgorithm
    {
        private int[] _array;
        private int _target;
        private int _step;

        public LinearSearch(int[] array, int target)
        {
            _array = (int[])array.Clone();
            _target = target;
            _step = 0;
        }

        public bool NextStep()
        {
            if (_step >= _array.Length)
                return false;

            bool found = _array[_step] == _target;
            _step++;
            return !found; // Если элемент найден, завершаем выполнение
        }

        public void Reset()
        {
            _step = 0;
        }

        public int[] GetArray() => (int[])_array.Clone();
    }
}
