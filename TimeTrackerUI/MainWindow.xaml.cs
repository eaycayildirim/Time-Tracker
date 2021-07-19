﻿using System;
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
            LoadCombobox();
            PauseButton.IsEnabled = false;
        }

        private void ShowTaskDetails(string selection)
        {
            TaskDetailsLabel.Content = _tracker.GetTasks()[selection].Name + " Started at " + DateTime.Now.ToString("HH:mm:ss");
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!IsTextNullOrEmpty() && !DoesTaskAlreadyExist())
            {
                string text = AddTextBox.Text.ToUpper();
                Properties.Settings.Default.Combobox.Add(text);
                Properties.Settings.Default.Save();
                UpdateCombobox(text);     //**
                UpdateTracker(text);
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
            if (!IsSelectedItemNull())
            {
                string selectedItem = GetSelectedItem().ToString();
                Properties.Settings.Default.Combobox.Remove(selectedItem);
                Properties.Settings.Default.Save();
                UpdateCombobox(selectedItem);       //**
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

        private bool IsTaskRunning(string selection) //**
        {
            return _tracker.IsTaskJustStarted(selection);
        }

        private void UpdateUI(string selection) //**
        {
            if (IsTaskRunning(selection))
            {
                //StartStopButton.Content = new BitmapImage(new Uri("/Resources/Icons/menu_button.png", UriKind.Relative));
                ShowTaskDetails(selection);
            }
            else
            {
            }
        }

        private bool IsSelectedItemNull()
        {
            return GetSelectedItem() == null ? true : false;
        }

        private void StartStopButton_Click(object sender, RoutedEventArgs e)
        {
            PauseButton.IsEnabled = true;
            if (!IsSelectedItemNull())
            {
                var selection = GetSelectedItem().ToString();
                _tracker.UpdateTracker(selection);
                StartElapsedTime();
                UpdateUI(selection);
            }
            else
                MessageBox.Show("Please select a task.");
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            PauseButton.IsEnabled = false;
            if (!IsSelectedItemNull())
            {
                var selection = GetSelectedItem().ToString();
                _tracker.PauseTheTask(selection);
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
                string selection = GetSelectedItem().ToString();
                TimerLabel.Content = _tracker.GetElapsedTime(_tracker.GetTasks()[selection]);
            }
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

        //TODO: Finish the running task when you close the program
    }
}
