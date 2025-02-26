using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace sys_prog
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Очищаем все существующие вкладки
            tabControl1.TabPages.Clear();

            // Настройка TabControl
            tabControl1.Dock = DockStyle.Fill; // Занимает всё доступное пространство
            tabControl1.Location = new Point(0, 50);
            tabControl1.Size = new System.Drawing.Size(800, 400);
            tabControl1.TabIndex = 1;

            // Добавляем информацию о каждом алгоритме
            AddAlgorithmTab("Сортировка пузырьком", "Bubble Sort",
                "Этот алгоритм многократно проходит по списку, сравнивает соседние элементы и меняет их местами, если они находятся в неправильном порядке.",
                "https://www.youtube.com/watch?v=lyZQPjUT5B4",
                @"
public class BubbleSort
{
    public static void Sort(int[] array)
    {
        int n = array.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
    }
}");

            AddAlgorithmTab("Сортировка выбором", "Selection Sort",
                "Алгоритм работает путем поиска минимального элемента из несортированной части списка и помещает его в начало.",
                "https://www.youtube.com/watch?v=xWbp4lzkoyM",
                @"
public class SelectionSort
{
    public static void Sort(int[] array)
    {
        int n = array.Length;
        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < n; j++)
            {
                if (array[j] < array[minIndex])
                {
                    minIndex = j;
                }
            }
            int temp = array[minIndex];
            array[minIndex] = array[i];
            array[i] = temp;
        }
    }
}");

            AddAlgorithmTab("Линейный поиск", "Linear Search",
                "Простой метод поиска элемента в массиве. Алгоритм последовательно проверяет каждый элемент до тех пор, пока не найдет нужный или не закончится список.",
                "https://www.youtube.com/watch?v=BHr381Guz3Y",
                @"
public class LinearSearch
{
    public static int Search(int[] array, int target)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == target)
            {
                return i; // Возвращаем индекс найденного элемента
            }
        }
        return -1; // Элемент не найден
    }
}");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide(); // Скрываем первую форму
            Form2 form2 = new Form2();
            form2.FormClosed += (s, args) => this.Show(); // Показываем первую форму после закрытия второй
            form2.Show();
        }

        private void AddAlgorithmTab(string title, string algorithmName, string description, string videoUrl, string code)
        {
            // Создаем новую вкладку
            TabPage tabPage = new TabPage(title);

            // Название алгоритма
            Label titleLabel = new Label
            {
                Text = algorithmName,
                Font = new Font("Arial", 14, FontStyle.Bold),
                Dock = DockStyle.Top,
                Height = 30
            };

            // Описание алгоритма
            RichTextBox descriptionBox = new RichTextBox
            {
                Text = description,
                Dock = DockStyle.Top,
                Height = 100,
                ReadOnly = true
            };

            // Ссылка на видео (если есть)
            if (!string.IsNullOrEmpty(videoUrl))
            {
                LinkLabel videoLink = new LinkLabel
                {
                    Text = "Посмотреть видео",
                    Dock = DockStyle.Top,
                    Height = 30,
                    LinkArea = new LinkArea(0, "Посмотреть видео".Length)
                };

                // Добавляем обработчик события LinkClicked
                videoLink.LinkClicked += (s, e) =>
                {
                    try
                    {
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = videoUrl,
                            UseShellExecute = true // Важно для корректной обработки URL
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Не удалось открыть видео: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };

                // Добавляем ссылку на вкладку
                tabPage.Controls.Add(videoLink);
            }

            // Код алгоритма
            TextBox codeBox = new TextBox
            {
                Text = code,
                Dock = DockStyle.Fill,
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Both,
                Font = new Font("Consolas", 10)
            };

            // Добавляем элементы на вкладку
            tabPage.Controls.Add(codeBox);
            tabPage.Controls.Add(descriptionBox);
            tabPage.Controls.Add(titleLabel);

            // Добавляем вкладку в TabControl
            tabControl1.TabPages.Add(tabPage);
        }
    }
}