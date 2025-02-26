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

        public void Sort()
        {
            int[] array = (int[])_history[0].Clone(); // Берем начальный массив
            PerformMergeSort(array, 0, array.Length - 1);
        }

        private void PerformMergeSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int mid = left + (right - left) / 2;

                // Рекурсивно сортируем левую и правую части
                PerformMergeSort(array, left, mid);
                PerformMergeSort(array, mid + 1, right);

                // Объединяем результаты
                Merge(array, left, mid, right);
            }
        }

        private void Merge(int[] array, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;

            // Создаем временные массивы
            int[] leftArray = new int[n1];
            int[] rightArray = new int[n2];

            Array.Copy(array, left, leftArray, 0, n1);
            Array.Copy(array, mid + 1, rightArray, 0, n2);

            int i = 0, j = 0, k = left;

            // Объединяем временные массивы
            while (i < n1 && j < n2)
            {
                if (leftArray[i] <= rightArray[j])
                {
                    array[k++] = leftArray[i++];
                }
                else
                {
                    array[k++] = rightArray[j++];
                }
            }

            while (i < n1)
            {
                array[k++] = leftArray[i++];
            }

            while (j < n2)
            {
                array[k++] = rightArray[j++];
            }

            // Сохраняем текущее состояние массива
            SaveState((int[])array.Clone());
        }

        private void SaveState(int[] array)
        {
            // Сохраняем копию массива в историю
            _history.Add((int[])array.Clone());
        }
    }
}