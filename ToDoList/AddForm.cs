namespace ToDoList
{
    public partial class AddForm : Form
    {
        MainForm mainForm;
        public AddForm(MainForm _mainForm)
        {
            InitializeComponent();
            mainForm = _mainForm;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            MyTask task = new MyTask
            {
                dateTime = dateTimePicker.Value,
                taskText = taskTextBox.Text
            };

            mainForm.AddMyTask(task);
            this.Close();
        }
    }
}
