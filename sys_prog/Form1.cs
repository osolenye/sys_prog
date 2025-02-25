namespace sys_prog
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Заполняем RichTextBox информацией об алгоритмах
            richTextBox1.Text = "";
            AddAlgorithmInfo("Сортировка пузырьком", "Bubble Sort", "Этот алгоритм многократно проходит по списку, сравнивает соседние элементы и меняет их местами, если они находятся в неправильном порядке.");
            AddAlgorithmInfo("Сортировка выбором", "Selection Sort", "Алгоритм работает путем поиска минимального элемента из несортированной части списка и помещает его в начало.");
            AddAlgorithmInfo("Линейный поиск", "Linear Search", "Простой метод поиска элемента в массиве. Алгоритм последовательно проверяет каждый элемент до тех пор, пока не найдет нужный или не закончится список.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide(); // Скрываем первую форму
            Form2 form2 = new Form2();
            form2.FormClosed += (s, args) => this.Show(); // Показываем первую форму после закрытия второй
            form2.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AddAlgorithmInfo(string title, string algorithmName, string description)
        {
            // Добавляем заголовок
            richTextBox1.AppendText(title + Environment.NewLine);
            richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);

            // Добавляем название алгоритма
            richTextBox1.AppendText(algorithmName + Environment.NewLine);
            richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Italic);

            // Добавляем описание
            richTextBox1.AppendText(description + Environment.NewLine + Environment.NewLine);
            richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
        }
    }
}
