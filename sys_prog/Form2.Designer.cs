namespace sys_prog
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            button1 = new Button();
            comboBoxAlgorithm = new ComboBox();
            textBoxArray = new TextBox();
            buttonGenerateArray = new Button();
            buttonInputArray = new Button();
            buttonLastStep = new Button();
            buttonPreviousStep = new Button();
            buttonNextStep = new Button();
            dataGridViewArray = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewArray).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(356, 12);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 0;
            button1.Text = "Теория";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // comboBoxAlgorithm
            // 
            comboBoxAlgorithm.FormattingEnabled = true;
            comboBoxAlgorithm.Items.AddRange(new object[] { "Bubble Sort", "Selection Sort", "Linear Search" });
            comboBoxAlgorithm.Location = new Point(3, 86);
            comboBoxAlgorithm.Name = "comboBoxAlgorithm";
            comboBoxAlgorithm.Size = new Size(151, 28);
            comboBoxAlgorithm.TabIndex = 1;
            comboBoxAlgorithm.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // textBoxArray
            // 
            textBoxArray.Location = new Point(325, 87);
            textBoxArray.Multiline = true;
            textBoxArray.Name = "textBoxArray";
            textBoxArray.Size = new Size(125, 34);
            textBoxArray.TabIndex = 2;
            // 
            // buttonGenerateArray
            // 
            buttonGenerateArray.Location = new Point(325, 129);
            buttonGenerateArray.Name = "buttonGenerateArray";
            buttonGenerateArray.Size = new Size(126, 29);
            buttonGenerateArray.TabIndex = 3;
            buttonGenerateArray.Text = "Сгенерировать";
            buttonGenerateArray.UseVisualStyleBackColor = true;
            // 
            // buttonInputArray
            // 
            buttonInputArray.Location = new Point(343, 164);
            buttonInputArray.Name = "buttonInputArray";
            buttonInputArray.Size = new Size(94, 29);
            buttonInputArray.TabIndex = 4;
            buttonInputArray.Text = "Ввести";
            buttonInputArray.UseVisualStyleBackColor = true;
            // 
            // buttonLastStep
            // 
            buttonLastStep.Location = new Point(325, 269);
            buttonLastStep.Name = "buttonLastStep";
            buttonLastStep.Size = new Size(126, 29);
            buttonLastStep.TabIndex = 5;
            buttonLastStep.Text = "Последний шаг";
            buttonLastStep.UseVisualStyleBackColor = true;
            // 
            // buttonPreviousStep
            // 
            buttonPreviousStep.Location = new Point(343, 199);
            buttonPreviousStep.Name = "buttonPreviousStep";
            buttonPreviousStep.Size = new Size(94, 29);
            buttonPreviousStep.TabIndex = 6;
            buttonPreviousStep.Text = "Пред. шаг";
            buttonPreviousStep.UseVisualStyleBackColor = true;
            // 
            // buttonNextStep
            // 
            buttonNextStep.Location = new Point(343, 234);
            buttonNextStep.Name = "buttonNextStep";
            buttonNextStep.Size = new Size(94, 29);
            buttonNextStep.TabIndex = 7;
            buttonNextStep.Text = "След. шаг";
            buttonNextStep.UseVisualStyleBackColor = true;
            // 
            // dataGridViewArray
            // 
            dataGridViewArray.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewArray.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewArray.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewArray.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridViewArray.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewArray.Dock = DockStyle.Right;
            dataGridViewArray.Location = new Point(500, 0);
            dataGridViewArray.Name = "dataGridViewArray";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridViewArray.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewArray.RowHeadersVisible = false;
            dataGridViewArray.RowHeadersWidth = 51;
            dataGridViewArray.Size = new Size(300, 450);
            dataGridViewArray.TabIndex = 8;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridViewArray);
            Controls.Add(buttonNextStep);
            Controls.Add(buttonPreviousStep);
            Controls.Add(buttonLastStep);
            Controls.Add(buttonInputArray);
            Controls.Add(buttonGenerateArray);
            Controls.Add(textBoxArray);
            Controls.Add(comboBoxAlgorithm);
            Controls.Add(button1);
            Name = "Form2";
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)dataGridViewArray).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private ComboBox comboBoxAlgorithm;
        private TextBox textBoxArray;
        private Button buttonGenerateArray;
        private Button buttonInputArray;
        private Button buttonLastStep;
        private Button buttonPreviousStep;
        private Button buttonNextStep;
        private DataGridView dataGridViewArray;
    }
}