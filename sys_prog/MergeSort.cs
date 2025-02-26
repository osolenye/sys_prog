using System;
using System.Collections.Generic;

namespace sys_prog
{
    public class MergeSort : IAlgorithm
    {
        private List<int[]> _history; // Хранит историю изменений массива
        private int _step; // Текущий индекс в истории

        public MergeSort(int[] array)
        {
            _history = new List<int[]>();
            SaveState(array); // Сохраняем начальное состояние
            _step = 0;
        }

        public bool NextStep()
        {
            if (_step >= _history.Count - 1)
                return false;

            // Переходим к следующему состоянию
            _step++;
            return true;
        }

        public bool PreviousStep()
        {
            if (_step <= 0)
                return false;

            // Возвращаемся к предыдущему состоянию
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

        public void Sort(int[] array)
        {
            if (array.Length <= 1)
            {
                SaveState(array);
                return;
            }

            int mid = array.Length / 2;
            int[] left = new int[mid];
            int[] right = new int[array.Length - mid];

            Array.Copy(array, 0, left, 0, mid);
            Array.Copy(array, mid, right, 0, array.Length - mid);

            // Рекурсивно сортируем левую и правую части
            Sort(left);
            Sort(right);

            // Объединяем результаты
            Merge(array, left, right);
        }

        private void Merge(int[] array, int[] left, int[] right)
        {
            int i = 0, j = 0, k = 0;

            while (i < left.Length && j < right.Length)
            {
                if (left[i] <= right[j])
                {
                    array[k++] = left[i++];
                }
                else
                {
                    array[k++] = right[j++];
                }
            }

            while (i < left.Length)
            {
                array[k++] = left[i++];
            }

            while (j < right.Length)
            {
                array[k++] = right[j++];
            }

            SaveState((int[])array.Clone());
        }

        private void SaveState(int[] array)
        {
            // Сохраняем копию массива в историю
            _history.Add((int[])array.Clone());
        }
    }
}