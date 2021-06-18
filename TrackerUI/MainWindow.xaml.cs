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
            SelectionCombobox.Items.Add(AddTextBox.Text);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            SelectionCombobox.Items.RemoveAt(SelectionCombobox.Items.IndexOf(AddTextBox.Text));
        }

        private List<Tasks> GetTasks()
        {
            for (int i = 0; i < SelectionCombobox.Items.Count; i++)
            {
                var comboboxItem = SelectionCombobox.Items[i] as ComboBoxItem;
                _tasks.Add(new Tasks(comboboxItem.Content.ToString()));
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
            GetTasks();
            Tracker tracker = new Tracker(_tasks);
            tracker.Update(GetSelection());
        }

    }
}
