namespace sys_prog
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
    }
}
