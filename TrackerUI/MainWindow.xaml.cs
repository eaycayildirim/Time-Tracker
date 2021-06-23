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

namespace TrackerUI
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
            if(SelectionCombobox.Items.Contains(AddTextBox.Text.ToUpper()))
                MessageBox.Show("You can not add the same task twice.");
            else
            {
                SelectionCombobox.Items.Add(AddTextBox.Text.ToUpper());
                AddTextBox.Clear();
                UpdatePropertiesSettings();
            }
            UpdateTasks();
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
            SelectionCombobox.Items.Remove(SelectionCombobox.SelectedItem);
            UpdatePropertiesSettings();
            UpdateTasks();
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

        private List<Tasks> UpdateTasks()
        {
            _tasks.Clear();
            GetTasks();
            return _tasks;
        }

        private int GetSelection()
        {
            return SelectionCombobox.SelectedIndex;
        }

        private List<Tasks> _tasks = new List<Tasks>();
        private Tracker _tracker;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _tracker.Update(GetSelection());
        }

        private void CheckLogButton_Click(object sender, RoutedEventArgs e)
        {
            var fileToOpen = "TimeTracker.csv";
            var process = new Process();

            if (File.Exists(fileToOpen))
            {
                process.StartInfo = new ProcessStartInfo(fileToOpen) { UseShellExecute = true };
                process.Start();
            }
            else
                MessageBox.Show("File not found.");
        }

        //A task must be selected to start
        //Textbox can not be empty
        //Finish the task when close the program
        //Pause button
    }
}
