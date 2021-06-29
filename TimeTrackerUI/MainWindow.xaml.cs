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
            _tracker = new Tracker(GetTasks());
            UpdateCombobox();
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

        private List<Tasks> GetTasks()
        {
            List<Tasks> tasks = new List<Tasks>();
            foreach (var item in Properties.Settings.Default.Combobox)
            {
                tasks.Add(new Tasks(item));
            }
            return tasks;
        }

        private void UpdateTracker(string taskName)
        {
            var response = _tracker.GetTasks().Find(x => x.Name == taskName);
            if (response == null)
                _tracker.AddTask(new Tasks(taskName));
            else
                _tracker.RemoveTask(response);
        }

        private void UpdateCombobox()
        {
            SelectionCombobox.Items.Clear();
            foreach (var item in Properties.Settings.Default.Combobox)
            {
                SelectionCombobox.Items.Add(item);
            }
        }

        private int GetSelectedIndex()
        {
            return SelectionCombobox.SelectedIndex;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (SelectionCombobox.SelectedItem == null)
                MessageBox.Show("Please select a task.");
            else
                _tracker.UpdatePressedButtons(GetSelectedIndex());
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

        private Tracker _tracker;

        //Finish the task when close the program
        //Pause button
        //Make it SOLID
    }
}
