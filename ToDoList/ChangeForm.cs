namespace ToDoList
{
    public partial class ChangeForm : Form
    {
        MainForm mainForm;
        MyTask myTask;
        public ChangeForm(MainForm _mainForm, MyTask _myTask)
        {
            InitializeComponent();
            mainForm = _mainForm;
            myTask = _myTask;
        }

        private void ChangeButton_Click(object sender, EventArgs e)
        {
            MyTask task = new MyTask
            {
                id = myTask.id,
                dateTime = dateTimePicker.Value,
                taskText = taskTextBox.Text
            };

            mainForm.ChangeMyTask(task);
            this.Close();
        }

        private void ChangeForm_Load(object sender, EventArgs e)
        {
            dateTimePicker.Value = myTask.dateTime;
            taskTextBox.Text = myTask.taskText;
        }
    }
}
