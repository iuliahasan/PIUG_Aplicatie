using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PIUG_Aplicatie
{
    /// <summary>
    /// Interaction logic for Task_Manager.xaml
    /// </summary>
    public partial class Task_Manager : Window
    {
        public ObservableCollection<Task> Tasks { get; set; }
        public Task_Manager()
        {
            InitializeComponent();
            Tasks = new ObservableCollection<Task>();
            taskListView.ItemsSource = Tasks;
        }

        public void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            string taskName = taskNameTextBox.Text;
            if (!string.IsNullOrWhiteSpace(taskName))
            {
                Task newTask = new Task { Name = taskName, Priority = "Normal", Deadline = DateTime.Today, Status = "Activă" };
                Tasks.Add(newTask);
                taskNameTextBox.Text = "";
            }
            else
            {
                MessageBox.Show("Introduceți un nume pentru sarcină.", "Eroare", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public void searchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchTerm = searchTextBox.Text.ToLower();

            if (Tasks != null)
            {
                var filteredTasks = Tasks.Where(task => task.Name.ToLower().Contains(searchTerm)).ToList();
                taskListView.ItemsSource = filteredTasks;
            }
        }

        private void filterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)filterComboBox.SelectedItem;
            string filter = selectedItem.Content.ToString();
            if (filter == "Active")
            {
                var activeTasks = Tasks.Where(task => task.Status == "Activă").ToList();
                taskListView.ItemsSource = activeTasks;
            }
            else if (filter == "Încheiate")
            {
                var completedTasks = Tasks.Where(task => task.Status == "Încheiată").ToList();
                taskListView.ItemsSource = completedTasks;
            }
            else
            {
                taskListView.ItemsSource = Tasks;
            }
        }

        private void QuiButton_Click(object sender, RoutedEventArgs e)
        {
            Quiz quiz = new Quiz();
            quiz.Show();
            this.Close();
        }
    }

    public class Task
    {
        public string Name { get; set; }
        public string Priority { get; set; }
        public DateTime Deadline { get; set; }
        public string Status { get; set; }
    }
}
