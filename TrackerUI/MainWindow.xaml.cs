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
            StartTimer();
            LoadComboboxItems();
        }

        private void LoadComboboxItems()
        {
            foreach (var item in Properties.Settings.Default.Combobox)
            {
                SelectionCombobox.Items.Add(item);
            }
        }

        private void StartTimer()
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
            if(SelectionCombobox.Items.Contains(AddTextBox.Text))
                MessageBox.Show("You can not add the same task twice.");
            else
            {
                SelectionCombobox.Items.Add(AddTextBox.Text);
                AddTextBox.Clear();
                UpdatePropertiesSettings();
            }

        }
        private void UpdatePropertiesSettings()
        {
            Properties.Settings.Default.Combobox.Clear();
            foreach (var item in SelectionCombobox.Items)
            {
                Properties.Settings.Default.Combobox.Add(item.ToString());
            }
            Properties.Settings.Default.Save();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            SelectionCombobox.Items.Remove(SelectionCombobox.SelectedItem);
            UpdatePropertiesSettings();
        }

        private List<Tasks> GetTasks()
        {
            for (int i = 0; i < Properties.Settings.Default.Combobox.Count; i++)
            {
                var comboboxItem = Properties.Settings.Default.Combobox[i];
                var response = _tasks.Find(x => x.Name == comboboxItem);
                if (response == null)
                    _tasks.Add(new Tasks(comboboxItem.ToString()));
            }
            return _tasks;
        }

        private int GetSelection()
        {
            return SelectionCombobox.SelectedIndex;
        }

        private List<Tasks> _tasks = new List<Tasks>();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _tasks = GetTasks();
            Tracker tracker = new Tracker(_tasks);
            tracker.Update(GetSelection());
        }

        //Check if you can add same task twice
        //Finish the task when close the program
    }
}
