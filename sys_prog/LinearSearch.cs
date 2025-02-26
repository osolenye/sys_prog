using System;
using System.Collections.Generic;

namespace sys_prog
{
    public class LinearSearch : IAlgorithm
    {
        private int[] _array; // Массив для поиска
        private int _target; // Целевое значение
        private int _step;   // Текущий индекс

        public LinearSearch(int[] array, int target)
        {
            _array = (int[])array.Clone(); // Клонируем массив
            _target = target; // Запоминаем целевое значение
            _step = 0; // Начинаем с первого элемента
        }

        public bool NextStep()
        {
            if (_step >= _array.Length)
                return false; // Если достигли конца массива, завершаем

            bool found = _array[_step] == _target; // Проверяем, найден ли элемент
            _step++; // Переходим к следующему элементу
            return !found; // Если элемент найден, завершаем выполнение
        }

        public bool PreviousStep()
        {
            if (_step <= 0)
                return false; // Если уже на первом элементе, нельзя вернуться назад

            _step--; // Возвращаемся к предыдущему элементу
            return true;
        }

        public void Reset()
        {
            _step = 0; // Сбрасываем индекс к началу массива
        }

        public int[] GetArray()
        {
            return (int[])_array.Clone(); // Возвращаем копию массива
        }
    }
}