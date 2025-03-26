using System;
using System.Collections.Generic;

namespace sys_prog
{
    public class SelectionSort : IAlgorithm
    {
        private List<int[]> _history; // Хранит историю изменений массива
        private int _step; // Текущий индекс в истории
        private int lastSwapped1 = -1, lastSwapped2 = -1; // Индексы последних перестановок

        public SelectionSort(int[] array)
        {
            _history = new List<int[]>();
            SaveState(array, -1, -1); // Сохраняем начальное состояние без перестановок
            _step = 0;
        }

        public bool NextStep()
        {
            // Проверяем, достигли ли конца массива
            if (_step >= GetCurrentArrayLength() - 1)
                return false;

            // Клонируем текущее состояние массива
            int[] currentArray = (int[])_history[_step].Clone();

            // Находим минимальный элемент
            int minIndex = _step;
            for (int i = _step + 1; i < GetCurrentArrayLength(); i++)
            {
                if (currentArray[i] < currentArray[minIndex])
                {
                    minIndex = i;
                }
            }

            // Меняем местами, если нужно
            if (minIndex != _step)
            {
                Swap(currentArray, _step, minIndex);
                lastSwapped1 = _step;
                lastSwapped2 = minIndex;
            }
            else
            {
                lastSwapped1 = -1;
                lastSwapped2 = -1;
            }

            // Сохраняем новое состояние
            SaveState(currentArray, lastSwapped1, lastSwapped2);

            // Переходим к следующему шагу
            _step++;
            return true;
        }

        public bool PreviousStep()
        {
            if (_step <= 0)
                return false;

            // Возвращаемся на предыдущий шаг
            _step--;
            return true;
        }

        public void Reset()
        {
            _step = 0; // Сбрасываем индекс к началу
        }

        public int[] GetArray()
        {
            // Возвращаем текущее состояние массива
            return (int[])_history[_step].Clone();
        }

        public (int, int) GetSwappedIndices()
        {
            return (lastSwapped1, lastSwapped2);
        }

        private void SaveState(int[] array, int swapped1, int swapped2)
        {
            // Сохраняем копию массива в историю
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
            // Возвращаем длину текущего массива из истории
            if (_history.Count == 0)
                return 0;

            return _history[_step].Length;
        }
    }
}
