using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Diagnostics;
using System.IO;
using nsTracker;
using nsTrackerTask;
using nsCSV;

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
            _tracker = new Tracker(GetTasks(), new CSV());
            LoadCombobox();
            PauseButton.IsEnabled = false;
        }

        private void ShowTaskDetails(string taskKey)
        {
            var symbol = '\u25B6';
            var name = _tracker.GetTasks()[taskKey].Name;
            SetTheFontSize(name);
            TaskDetailsLabel.Content = symbol.ToString() + " " + _tracker.GetTasks()[taskKey].Name + " | " + DateTime.Now.ToString("HH:mm:ss");
        }

        private void SetTheFontSize(string name)
        {
            if(name.Length > 7)
                TaskDetailsLabel.FontSize = 12;
            else
                TaskDetailsLabel.FontSize = 20;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!IsTextNullOrEmpty() && !DoesTaskAlreadyExist())
            {
                string text = AddTextBox.Text.ToUpper();
                Properties.Settings.Default.Combobox.Add(text);
                Properties.Settings.Default.Save();
                UpdateCombobox(text);
                UpdateTracker(text);
            }
            else
                MessageBox.Show("Text is not valid.");
            AddTextBox.Clear();
        }

        private bool IsTextNullOrEmpty()
        {
            return string.IsNullOrEmpty(AddTextBox.Text);
        }

        private bool DoesTaskAlreadyExist()
        {
            return SelectionCombobox.Items.Contains(AddTextBox.Text.ToUpper());
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (!IsSelectedItemNull())
            {
                string selectedItem = GetSelectedItem().ToString();
                Properties.Settings.Default.Combobox.Remove(selectedItem);
                Properties.Settings.Default.Save();
                UpdateCombobox(selectedItem);
                UpdateTracker(selectedItem);
            }
            else
                MessageBox.Show("Please select a task.");
        }

        private Dictionary<string, TrackerTask> GetTasks()
        {
            Dictionary<string, TrackerTask> tasks = new Dictionary<string, TrackerTask>();
            foreach (var item in Properties.Settings.Default.Combobox)
            {
                tasks.Add(item, new TrackerTask(item));
            }
            return tasks;
        }

        private void UpdateTracker(string task)
        {
            if(_tracker.GetTasks().ContainsKey(task))
                _tracker.RemoveTask(task);
            else
                _tracker.AddTask(task);
        }

        private void UpdateCombobox(string task)
        {
            if (SelectionCombobox.Items.Contains(task))
                SelectionCombobox.Items.Remove(task);
            else
                SelectionCombobox.Items.Add(task);
        }

        private void LoadCombobox()
        {
            SelectionCombobox.Items.Clear();
            foreach (var item in Properties.Settings.Default.Combobox)
            {
                SelectionCombobox.Items.Add(item);
            }
        }

        private object GetSelectedItem()
        {
            return SelectionCombobox.SelectedItem;
        }

        private bool IsTaskRunning(string selection)
        {
            return _tracker.IsTaskRunning(selection);
        }

        private void UpdateUI(string selection)
        {
            if(_tracker.IsTaskJustStarted(selection))
                ShowTaskDetails(selection);

            if (IsTaskRunning(selection))
                StartStopButton.Template = FindResource("StopButtonTemplate") as ControlTemplate;
            else
                StartStopButton.Template = FindResource("PlayButtonTemplate") as ControlTemplate;
        }

        private bool IsSelectedItemNull()
        {
            return GetSelectedItem() == null;
        }

        private void StartStopButton_Click(object sender, RoutedEventArgs e)
        {
            if (!IsSelectedItemNull())
            {
                PauseButton.IsEnabled = true;
                var selectedItem = GetSelectedItem().ToString();
                _tracker.UpdateTracker(selectedItem);
                StartElapsedTime();
                UpdateUI(selectedItem);
            }
            else
                MessageBox.Show("Please select a task.");
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            if (!IsSelectedItemNull())
            {
                PauseButton.IsEnabled = false;
                var selectedItem = GetSelectedItem().ToString();
                _tracker.PauseTheTask(selectedItem);
                UpdateUI(selectedItem);
            }
            else
                MessageBox.Show("Please select a task.");
        }

        private void StartElapsedTime()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += new EventHandler(UpdateElapsedTimeTick);
            timer.Start();
        }

        private void UpdateElapsedTimeTick(object sender, EventArgs e)
        {
            if (!IsSelectedItemNull())
            {
                string selectedItem = GetSelectedItem().ToString();
                TimerLabel.Content = _tracker.GetElapsedTime(_tracker.GetTasks()[selectedItem]);
            }
        }

        private void CheckLogButton_Click(object sender, RoutedEventArgs e)
        {
            var filePath = _tracker.GetFilePath();
            var process = new Process();

            if (File.Exists(filePath))
            {
                process.StartInfo = new ProcessStartInfo(filePath) { UseShellExecute = true };
                process.Start();
            }
            else
                MessageBox.Show("File not found.");
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _tracker.FinishTheTasks();
        }

        private Tracker _tracker;
    }
}
