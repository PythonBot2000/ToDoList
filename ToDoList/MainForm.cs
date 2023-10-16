namespace ToDoList
{
    public partial class MainForm : Form
    {
        ApplicationContext context;
        Dictionary<int, bool> notifiedTasks = new Dictionary<int, bool>();

        public MainForm()
        {
            InitializeComponent();
            context = new ApplicationContext();

            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
            idColumn.Name = "IdColumn";
            idColumn.HeaderText = "Идентификатор";
            idColumn.DataPropertyName = "id";
            idColumn.Visible = false;

            DataGridViewTextBoxColumn dateColumn = new DataGridViewTextBoxColumn();
            dateColumn.Name = "DateColumn";
            dateColumn.HeaderText = "Дата";
            dateColumn.DataPropertyName = "dateTime";
            dateColumn.Width = 70;

            DataGridViewTextBoxColumn timeColumn = new DataGridViewTextBoxColumn();
            timeColumn.Name = "TimeColumn";
            timeColumn.HeaderText = "Время";
            timeColumn.DataPropertyName = "dateTime";
            timeColumn.Width = 70;

            DataGridViewTextBoxColumn taskTextColumn = new DataGridViewTextBoxColumn();
            taskTextColumn.Name = "TaskTextColumn";
            taskTextColumn.HeaderText = "Задача";
            taskTextColumn.DataPropertyName = "taskText";
            taskTextColumn.Width = 427;

            dataGridView.Columns.Add(idColumn);
            dataGridView.Columns.Add(dateColumn);
            dataGridView.Columns.Add(timeColumn);
            dataGridView.Columns.Add(taskTextColumn);

            UpdateMyTasks();
        }

        private void WarningMessage(string message) => MessageBox.Show(message, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm(this);
            addForm.ShowDialog();
        }

        private void ChangeButton_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int rowIndex = dataGridView.SelectedRows[0].Index;
                MyTask selectedTask = (MyTask)dataGridView.Rows[rowIndex].DataBoundItem;

                ChangeForm addForm = new ChangeForm(this, selectedTask);
                addForm.ShowDialog();
            }
            else if (dataGridView.SelectedRows.Count == 0)
            {
                WarningMessage("Выберите задачу");
            }
            else
            {
                WarningMessage("Выберите только одну задачу");
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                DialogResult = MessageBox.Show("Вы действительно хотите удалить выбранные записи?", "Удаление записей", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    List<int> ids = new List<int>();
                    MyTask selectedTask;
                    for (int i = 0; i < dataGridView.SelectedRows.Count; i++)
                    {
                        int rowIndex = dataGridView.SelectedRows[i].Index;
                        selectedTask = (MyTask)dataGridView.Rows[rowIndex].DataBoundItem;
                        ids.Add(selectedTask.id);
                    }
                    DeleteMyTask(ids);
                }
            }
            else
            {
                WarningMessage("Выберите задачу");
            }
        }

        // Добавляет задачу
        public void AddMyTask(MyTask task)
        {
            context.tasks.Add(task);
            context.SaveChanges();
            UpdateMyTasks();
        }

        // Изменяет задачу
        public void ChangeMyTask(MyTask task)
        {
            MyTask? tempTask = context.tasks.Find(task.id);
            if (tempTask != null)
            {
                tempTask.dateTime = task.dateTime;
                tempTask.taskText = task.taskText;
                context.tasks.Update(tempTask);
                context.SaveChanges();
                UpdateMyTasks();

                notifiedTasks[task.id] = false;
            }
        }

        // Удаляет задачу
        public void DeleteMyTask(List<int> ids)
        {
            foreach (int id in ids)
            {
                var taskToDelete = context.tasks.First(x => x.id == id);
                context.tasks.Remove(taskToDelete);

                notifiedTasks.Remove(id);
            }
            context.SaveChanges();
            UpdateMyTasks();
        }

        // Обновляет datagridview
        private void UpdateMyTasks()
        {
            var tasks = context.tasks.ToList();
            dataGridView.DataSource = tasks;
        }

        // Проверяет сколько минут осталось до задачи. Если 5 или меньше, то выдает оповещение.
        private void timer_Tick(object sender, EventArgs e)
        {
            var tasks = context.tasks.ToList();
            DateTime currentTime = DateTime.Now;
            foreach (var task in tasks)
            {
                DateTime taskTime = task.dateTime;
                if ((taskTime > currentTime) && (taskTime - currentTime <= TimeSpan.FromMinutes(5)))
                {
                    if (!notifiedTasks.ContainsKey(task.id) || !notifiedTasks[task.id])
                    {
                        string message = $"До задачи \"{task.taskText}\" осталось менее 5 минут";
                        MessageBox.Show(message, "Оповещение", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        notifiedTasks[task.id] = true;
                    }
                }
            }
        }

        // Записывает дату и время в разные колонки
        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                if (dataGridView.Columns[e.ColumnIndex].Name == "DateColumn")
                {
                    if (e.Value is DateTime dateTimeValue)
                    {
                        e.Value = dateTimeValue.ToShortDateString();
                    }
                }
                else if (dataGridView.Columns[e.ColumnIndex].Name == "TimeColumn")
                {
                    if (e.Value is DateTime dateTimeValue)
                    {
                        e.Value = dateTimeValue.ToShortTimeString();
                    }
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            context.Dispose();
        }
    }
}