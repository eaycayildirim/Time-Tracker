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
using nsTrackerTask;

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
            _tracker = new Tracker(GetTasks());
            UpdateCombobox();
            PauseButton.IsEnabled = false;
        }

        private void ShowTaskDetails(string index) //**
        {
            CurrentTimeLabel.Content = _tracker.GetTasks()[index].Name + " Started " + DateTime.Now.ToString("HH:mm:ss");
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!IsTextNullOrEmpty() && !DoesTaskAlreadyExist())
            {
                Properties.Settings.Default.Combobox.Add(AddTextBox.Text.ToUpper());
                Properties.Settings.Default.Save();
                UpdateCombobox();
                UpdateTracker(AddTextBox.Text.ToUpper());
            }
            else
                MessageBox.Show("Text is not valid.");
            AddTextBox.Clear();
        }

        private bool IsTextNullOrEmpty()
        {
            return string.IsNullOrEmpty(AddTextBox.Text) ? true : false;
        }

        private bool DoesTaskAlreadyExist()
        {
            return SelectionCombobox.Items.Contains(AddTextBox.Text.ToUpper()) ? true : false;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            string selectedItem = SelectionCombobox.SelectedItem.ToString();
            Properties.Settings.Default.Combobox.Remove(selectedItem);
            Properties.Settings.Default.Save();
            UpdateCombobox();
            UpdateTracker(selectedItem);
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

        private void UpdateTracker(string task) //**
        {
            if(_tracker.GetTasks().ContainsKey(task))
                _tracker.RemoveTask(task);
            else
                _tracker.AddTask(task);
        }

        private void UpdateCombobox()
        {
            SelectionCombobox.Items.Clear();
            foreach (var item in Properties.Settings.Default.Combobox)
            {
                SelectionCombobox.Items.Add(item);
            }
        }

        private string GetSelectedItem()
        {
            return SelectionCombobox.SelectedItem.ToString();
        }

        private void EnableDisableFunctions(bool toggle) //**
        {
            AddButton.IsEnabled = toggle;
            DeleteButton.IsEnabled = toggle;
            AddTextBox.IsEnabled = toggle;
        }

        private bool IsTaskRunning(string index) //**
        {
            return _tracker.IsTaskRunning(index);
        }

        private void UpdateUI(string index) //**
        {
            if (IsTaskRunning(index))
            {
                EnableDisableFunctions(false);
                StartStopButton.Content = "STOP";
                ShowTaskDetails(index);      // not working after pause
            }
            else
            {
                EnableDisableFunctions(true);
                StartStopButton.Content = "START";
            }
        }

        private void StartStopButton_Click(object sender, RoutedEventArgs e)
        {
            PauseButton.IsEnabled = true;
            if (SelectionCombobox.SelectedItem == null)
                MessageBox.Show("Please select a task.");
            else
            {
                var selection = GetSelectedItem();
                _tracker.UpdateTracker(selection);
                ShowElapsedTime();

                //**
                UpdateUI(selection);
            }
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            PauseButton.IsEnabled = false;
            if (SelectionCombobox.SelectedItem == null)
                MessageBox.Show("Please select a task.");
            else
            {
                var selection = GetSelectedItem();
                _tracker.PauseTheTask(selection);

                //**
                UpdateUI(selection);
                StartStopButton.Content = "CONTINUE";
            }
        }

        private void ShowElapsedTime()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += new EventHandler(UpdateElapsedTimeTick);
            timer.Start();
        }

        private void UpdateElapsedTimeTick(object sender, EventArgs e)
        {
            string selection = GetSelectedItem();
            TimerLabel.Content = _tracker.GetElapsedTime(_tracker.GetTasks()[selection]);
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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) //**
        {

        }

        private Tracker _tracker;
    }
}
