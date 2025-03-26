using System;
using System.Collections.Generic;

namespace sys_prog
{
    public class BubbleSort : IAlgorithm
    {
        private List<int[]> _history; // История изменений
        private int _step; // Текущий индекс в истории
        private int lastSwapped1 = -1, lastSwapped2 = -1; // Индексы последних перестановок

        public BubbleSort(int[] array)
        {
            _history = new List<int[]>();
            SaveState(array, -1, -1); // Начальное состояние, без перестановок
            _step = 0;
        }

        public bool NextStep()
        {
            if (_step >= GetCurrentArrayLength() - 1)
                return false;

            int[] currentArray = (int[])_history[_step].Clone();
            bool swapped = false;

            for (int i = 0; i < currentArray.Length - _step - 1; i++)
            {
                if (currentArray[i] > currentArray[i + 1])
                {
                    Swap(currentArray, i, i + 1);
                    lastSwapped1 = i;
                    lastSwapped2 = i + 1;
                    swapped = true;
                }
            }

            if (!swapped) return false; // Если перестановок не было, выходим

            SaveState(currentArray, lastSwapped1, lastSwapped2);
            _step++;
            return true;
        }

        public bool PreviousStep()
        {
            if (_step <= 0)
                return false;

            _step--;
            return true;
        }

        public void Reset()
        {
            _step = 0;
        }

        public int[] GetArray()
        {
            return (int[])_history[_step].Clone();
        }

        public (int, int) GetSwappedIndices()
        {
            return (lastSwapped1, lastSwapped2);
        }

        private void SaveState(int[] array, int swapped1, int swapped2)
        {
            _history.Add((int[])array.Clone());
            lastSwapped1 = swapped1;
            lastSwapped2 = swapped2;
        }

        private void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        private int GetCurrentArrayLength()
        {
            if (_history.Count == 0)
                return 0;

            return _history[_step].Length;
        }
    }
}
