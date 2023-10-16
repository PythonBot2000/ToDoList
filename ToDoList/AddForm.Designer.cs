namespace ToDoList
{
    partial class AddForm
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
            taskTextBox = new TextBox();
            dateTimePicker = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            AddButton = new Button();
            SuspendLayout();
            // 
            // taskTextBox
            // 
            taskTextBox.Location = new Point(100, 72);
            taskTextBox.MaxLength = 500;
            taskTextBox.Multiline = true;
            taskTextBox.Name = "taskTextBox";
            taskTextBox.Size = new Size(289, 70);
            taskTextBox.TabIndex = 0;
            // 
            // dateTimePicker
            // 
            dateTimePicker.CustomFormat = "HH:mm  dd.MM.yyyy";
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.Location = new Point(100, 25);
            dateTimePicker.MaxDate = new DateTime(2100, 12, 31, 0, 0, 0, 0);
            dateTimePicker.MinDate = new DateTime(2000, 1, 1, 0, 0, 0, 0);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(179, 23);
            dateTimePicker.TabIndex = 1;
            dateTimePicker.Value = DateTime.Now;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 25);
            label1.Name = "label1";
            label1.Size = new Size(79, 15);
            label1.TabIndex = 2;
            label1.Text = "Дата и время";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 75);
            label2.Name = "label2";
            label2.Size = new Size(45, 15);
            label2.TabIndex = 3;
            label2.Text = "Задача";
            // 
            // AddButton
            // 
            AddButton.Location = new Point(154, 164);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(132, 41);
            AddButton.TabIndex = 6;
            AddButton.Text = "Добавить";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // AddForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 223);
            Controls.Add(AddButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dateTimePicker);
            Controls.Add(taskTextBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "AddForm";
            Text = "Добавить задачу";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox taskTextBox;
        private DateTimePicker dateTimePicker;
        private Label label1;
        private Label label2;
        private Button AddButton;
    }
}