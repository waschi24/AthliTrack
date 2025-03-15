using AthliTrack.models;
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
using System.Windows.Shapes;

namespace AthliTrack.windows
{
    /// <summary>
    /// Interaction logic for WorkoutDetails.xaml
    /// </summary>
    public partial class WorkoutDetails : Window
    {
        public WorkoutDetails(Workout workout)
        {
            InitializeComponent();
            ExerciseGrid.ItemsSource = workout.Exercises;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow
            {
                Left = this.Left,
                Top = this.Top
            };

            mainWindow.Show();
            this.Close();
        }
    }
}
