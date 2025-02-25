using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sys_prog
{
    public partial class Form2 : Form
    {
        private IAlgorithm _currentAlgorithm; // Для хранения текущего алгоритма
        private int[] _originalArray; // Для сохранения оригинального массива
        public Form2()
        {
            InitializeComponent();
            dataGridViewArray.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewArray.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;


            dataGridViewArray.DefaultCellStyle.Font = new Font("Arial", 12); // Увеличиваем шрифт
            dataGridViewArray.DefaultCellStyle.ForeColor = Color.Black; // Делаем текст черным
            dataGridViewArray.DefaultCellStyle.BackColor = Color.White; // Убедимся, что фон белый


            comboBoxAlgorithm.SelectedIndex = 0; // Выбираем первый алгоритм по умолчанию

            buttonGenerateArray.Click += buttonGenerateArray_Click;
            buttonInputArray.Click += buttonInputArray_Click;
            buttonNextStep.Click += buttonNextStep_Click;
            buttonPreviousStep.Click += buttonPreviousStep_Click;
            buttonLastStep.Click += buttonLastStep_Click;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private int[] GenerateRandomArray(int size, int minValue, int maxValue)
        {
            Random random = new Random();
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(minValue, maxValue);
            }
            return array;
        }
        private int[] ParseArrayFromTextBox(string input)
        {
            string[] parts = input.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            int[] array = Array.ConvertAll(parts, int.Parse);
            return array;
        }
        private void DisplayArray(int[] array)
        {
            textBoxArray.Text = string.Join(", ", array);
        }
        //private void UpdateDataGridView()
        //{
        //    dataGridViewArray.Rows.Clear();

        //    if (_currentAlgorithm != null)
        //    {
        //        int[] currentArray = _currentAlgorithm.GetArray();

        //        // Если столбцы еще не добавлены, добавляем один
        //        if (dataGridViewArray.ColumnCount == 0)
        //        {
        //            dataGridViewArray.Columns.Add("Value", "Значение");
        //        }

        //        // Заполняем DataGridView
        //        foreach (int value in currentArray)
        //        {
        //            dataGridViewArray.Rows.Add(value);
        //        }
        //    }
        //}
        private void UpdateDataGridView()
        {
            // Очищаем все строки
            dataGridViewArray.Rows.Clear();

            if (_currentAlgorithm == null)
                return;

            int[] currentArray = _currentAlgorithm.GetArray();

            // Если столбцы еще не созданы, создаем один столбец
            if (dataGridViewArray.ColumnCount == 0)
            {
                dataGridViewArray.Columns.Add("Value", "Значение");
            }

            // Добавляем каждое значение массива как новую строку
            foreach (int value in currentArray)
            {
                // Убедитесь, что значение добавляется как объект
                dataGridViewArray.Rows.Add(new object[] { value });
            }
        }
        private void InitializeAlgorithm(int[] array)
        {
            if (comboBoxAlgorithm.SelectedItem == null)
            {
                MessageBox.Show("Выберите алгоритм перед запуском.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string algorithmName = comboBoxAlgorithm.SelectedItem.ToString();
            switch (algorithmName)
            {
                case "Bubble Sort":
                    _currentAlgorithm = new BubbleSort(array);
                    break;
                case "Selection Sort":
                    _currentAlgorithm = new SelectionSort(array);
                    break;
                case "Linear Search":
                    _currentAlgorithm = new LinearSearch(array, 5); // Ищем число 5
                    break;
                default:
                    MessageBox.Show("Неизвестный алгоритм.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            // Обновляем DataGridView после инициализации алгоритма
            UpdateDataGridView();
        }
        private void buttonGenerateArray_Click(object sender, EventArgs e)
        {
            int[] array = GenerateRandomArray(10, 1, 100);
            _originalArray = (int[])array.Clone(); // Сохраняем оригинальный массив
            DisplayArray(array);
            InitializeAlgorithm(array);
        }
        private void buttonInputArray_Click(object sender, EventArgs e)
        {
            try
            {
                int[] array = ParseArrayFromTextBox(textBoxArray.Text);
                _originalArray = (int[])array.Clone(); // Сохраняем оригинальный массив
                DisplayArray(array);
                InitializeAlgorithm(array);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Некорректный формат массива.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonNextStep_Click(object sender, EventArgs e)
        {
            if (_currentAlgorithm == null)
                return;

            bool hasNextStep = _currentAlgorithm.NextStep();
            if (!hasNextStep)
            {
                MessageBox.Show("Алгоритм завершен.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            UpdateDataGridView();
        }
        private void buttonPreviousStep_Click(object sender, EventArgs e)
        {
            if (_currentAlgorithm == null)
                return;

            _currentAlgorithm.Reset(); // Возвращаемся к началу
            UpdateDataGridView();
        }
        private void buttonLastStep_Click(object sender, EventArgs e)
        {
            if (_currentAlgorithm == null)
                return;

            while (_currentAlgorithm.NextStep()) { }
            UpdateDataGridView();
        }

        private void comboBoxAlgorithm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxAlgorithm.SelectedItem == null)
                return;

            if (_originalArray == null)
            {
                MessageBox.Show("Сначала создайте или введите массив.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            InitializeAlgorithm((int[])_originalArray.Clone());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close(); // Закрываем вторую форму
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}