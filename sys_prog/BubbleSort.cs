using System;
using System.Collections.Generic;

namespace sys_prog
{
    public class BubbleSort : IAlgorithm
    {
        private List<int[]> _history; // История изменений
        private int _step; // Текущий индекс в истории

        public BubbleSort(int[] array)
        {
            _history = new List<int[]>();
            SaveState(array); // Сохраняем начальное состояние
            _step = 0;
        }

        public bool NextStep()
        {
            // Получаем текущий массив из истории
            if (_step >= GetCurrentArrayLength() - 1)
                return false;

            // Клонируем текущее состояние массива
            int[] currentArray = (int[])_history[_step].Clone();

            // Выполняем один шаг сортировки
            for (int i = 0; i < currentArray.Length - _step - 1; i++)
            {
                if (currentArray[i] > currentArray[i + 1])
                {
                    Swap(currentArray, i, i + 1);
                }
            }

            // Сохраняем новое состояние
            SaveState(currentArray);

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
            _step = 0; // Возвращаемся к началу
        }

        public int[] GetArray()
        {
            // Возвращаем текущее состояние массива
            return (int[])_history[_step].Clone();
        }

        private void SaveState(int[] array)
        {
            // Сохраняем копию массива в историю
            _history.Add((int[])array.Clone());
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