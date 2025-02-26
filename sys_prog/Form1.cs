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

            // ������� ��� ������������ �������
            tabControl1.TabPages.Clear();

            // ��������� TabControl
            tabControl1.Dock = DockStyle.Fill; // �������� �� ��������� ������������
            tabControl1.Location = new Point(0, 50);
            tabControl1.Size = new System.Drawing.Size(800, 400);
            tabControl1.TabIndex = 1;

            // ��������� ���������� � ������ ���������
            AddAlgorithmTab("���������� ���������", "Bubble Sort",
                "���� �������� ����������� �������� �� ������, ���������� �������� �������� � ������ �� �������, ���� ��� ��������� � ������������ �������.",
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

            AddAlgorithmTab("���������� �������", "Selection Sort",
                "�������� �������� ����� ������ ������������ �������� �� ��������������� ����� ������ � �������� ��� � ������.",
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

            AddAlgorithmTab("�������� �����", "Linear Search",
                "������� ����� ������ �������� � �������. �������� ��������������� ��������� ������ ������� �� ��� ���, ���� �� ������ ������ ��� �� ���������� ������.",
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
                return i; // ���������� ������ ���������� ��������
            }
        }
        return -1; // ������� �� ������
    }
}");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide(); // �������� ������ �����
            Form2 form2 = new Form2();
            form2.FormClosed += (s, args) => this.Show(); // ���������� ������ ����� ����� �������� ������
            form2.Show();
        }

        private void AddAlgorithmTab(string title, string algorithmName, string description, string videoUrl, string code)
        {
            // ������� ����� �������
            TabPage tabPage = new TabPage(title);

            // �������� ���������
            Label titleLabel = new Label
            {
                Text = algorithmName,
                Font = new Font("Arial", 14, FontStyle.Bold),
                Dock = DockStyle.Top,
                Height = 30
            };

            // �������� ���������
            RichTextBox descriptionBox = new RichTextBox
            {
                Text = description,
                Dock = DockStyle.Top,
                Height = 100,
                ReadOnly = true
            };

            // ������ �� ����� (���� ����)
            if (!string.IsNullOrEmpty(videoUrl))
            {
                LinkLabel videoLink = new LinkLabel
                {
                    Text = "���������� �����",
                    Dock = DockStyle.Top,
                    Height = 30,
                    LinkArea = new LinkArea(0, "���������� �����".Length)
                };

                // ��������� ���������� ������� LinkClicked
                videoLink.LinkClicked += (s, e) =>
                {
                    try
                    {
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = videoUrl,
                            UseShellExecute = true // ����� ��� ���������� ��������� URL
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"�� ������� ������� �����: {ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };

                // ��������� ������ �� �������
                tabPage.Controls.Add(videoLink);
            }

            // ��� ���������
            TextBox codeBox = new TextBox
            {
                Text = code,
                Dock = DockStyle.Fill,
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Both,
                Font = new Font("Consolas", 10)
            };

            // ��������� �������� �� �������
            tabPage.Controls.Add(codeBox);
            tabPage.Controls.Add(descriptionBox);
            tabPage.Controls.Add(titleLabel);

            // ��������� ������� � TabControl
            tabControl1.TabPages.Add(tabPage);
        }
    }
}