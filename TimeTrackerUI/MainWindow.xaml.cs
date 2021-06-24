using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Diagnostics;
using System.IO;
using nsTracker;
using nsTask;

namespace TimeTrackerUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ShowDateTime();
            LoadComboboxItems();

            _tasks = GetTasks();
            _tracker = new Tracker(_tasks);
        }

        private void LoadComboboxItems()
        {
            foreach (var item in Properties.Settings.Default.Combobox)
            {
                SelectionCombobox.Items.Add(item.ToUpper());
            }
        }

        private void ShowDateTime()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += new EventHandler(UpdateTimerTick);
            timer.Start();
        }

        private void UpdateTimerTick(object sender, EventArgs e)
        {
            CurrentTimeLabel.Content = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!IsTextValid())
                MessageBox.Show("Please write something to add");
            else
            {
                if (TaskAlreadyExist())
                    MessageBox.Show("You can not add the same task twice.");
                else
                {
                    SelectionCombobox.Items.Add(AddTextBox.Text.ToUpper());
                    UpdatePropertiesSettings();
                }
                UpdateTasks(AddTextBox.Text.ToUpper());
                AddTextBox.Clear();
            }
        }

        private bool IsTextValid()
        {
            if (string.IsNullOrEmpty(AddTextBox.Text))
                return false;
            else
                return true;
        }

        private bool TaskAlreadyExist()
        {
            if (SelectionCombobox.Items.Contains(AddTextBox.Text.ToUpper()))
                return true;
            else
                return false;
        }

        private void UpdatePropertiesSettings()
        {
            Properties.Settings.Default.Combobox.Clear();
            foreach (var item in SelectionCombobox.Items)
            {
                Properties.Settings.Default.Combobox.Add(item.ToString().ToUpper());
            }
            Properties.Settings.Default.Save();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateTasks(SelectionCombobox.SelectedItem.ToString());
            SelectionCombobox.Items.Remove(SelectionCombobox.SelectedItem);
            UpdatePropertiesSettings();
        }

        private List<Tasks> GetTasks()
        {
            for (int i = 0; i < Properties.Settings.Default.Combobox.Count; i++)
            {
                var comboboxItem = Properties.Settings.Default.Combobox[i];
                _tasks.Add(new Tasks(comboboxItem.ToString().ToUpper()));
            }
            return _tasks;
        }

        private void UpdateTasks(string taskName)
        {
            var response = _tasks.Find(x => x.Name == taskName);
            if (response == null)
                _tasks.Add(new Tasks(taskName));
            else
                _tasks.Remove(response);
        }

        private int GetSelection()
        {
            return SelectionCombobox.SelectedIndex;
        }

        private List<Tasks> _tasks = new List<Tasks>();
        private Tracker _tracker;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (SelectionCombobox.SelectedItem == null)
                MessageBox.Show("Please select a task.");
            else
                _tracker.Update(GetSelection());
        }

        private void CheckLogButton_Click(object sender, RoutedEventArgs e)
        {
            var fileToOpen = _tracker.GetFilePath();
            var process = new Process();

            if (File.Exists(fileToOpen))
            {
                process.StartInfo = new ProcessStartInfo(fileToOpen) { UseShellExecute = true };
                process.Start();
            }
            else
                MessageBox.Show("File not found.");
        }

        //Finish the task when close the program
        //Pause button
        //Make it SOLID
    }
}
