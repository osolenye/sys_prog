using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sys_prog
{
    public interface IAlgorithm
    {
        bool NextStep(); // Выполняет следующий шаг алгоритма
        bool PreviousStep(); // Возвращает на предыдущий шаг
        void Reset(); // Сбрасывает алгоритм к начальному состоянию
        int[] GetArray(); // Возвращает текущее состояние массива
        public (int, int) GetSwappedIndices();
    }
}
