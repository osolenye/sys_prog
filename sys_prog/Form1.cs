namespace sys_prog
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // ��������� RichTextBox ����������� �� ����������
            richTextBox1.Text = "";
            AddAlgorithmInfo("���������� ���������", "Bubble Sort", "���� �������� ����������� �������� �� ������, ���������� �������� �������� � ������ �� �������, ���� ��� ��������� � ������������ �������.");
            AddAlgorithmInfo("���������� �������", "Selection Sort", "�������� �������� ����� ������ ������������ �������� �� ��������������� ����� ������ � �������� ��� � ������.");
            AddAlgorithmInfo("�������� �����", "Linear Search", "������� ����� ������ �������� � �������. �������� ��������������� ��������� ������ ������� �� ��� ���, ���� �� ������ ������ ��� �� ���������� ������.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide(); // �������� ������ �����
            Form2 form2 = new Form2();
            form2.FormClosed += (s, args) => this.Show(); // ���������� ������ ����� ����� �������� ������
            form2.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AddAlgorithmInfo(string title, string algorithmName, string description)
        {
            // ��������� ���������
            richTextBox1.AppendText(title + Environment.NewLine);
            richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);

            // ��������� �������� ���������
            richTextBox1.AppendText(algorithmName + Environment.NewLine);
            richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Italic);

            // ��������� ��������
            richTextBox1.AppendText(description + Environment.NewLine + Environment.NewLine);
            richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
        }
    }
}
