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
            WorkoutDetailsTitle.Text = "Workout \"" + workout.Name + "\"";
            LoadExercises(workout);
            LoadStats(workout);
        }

        private void LoadExercises(Workout workout)
        {
            foreach (Exercise exercise in workout.Exercises)
            {
                // Trennlinie zwischen Übungen
                Separator separator = new Separator { Margin = new Thickness(0, 10, 0, 0) };
                ExerciseList.Children.Add(separator);

                // Übungstitel
                TextBlock title = new TextBlock
                {
                    Text = exercise.Name,
                    FontSize = 12,
                    Margin = new Thickness(0, 10, 0, 5)
                };
                ExerciseList.Children.Add(title);

                // Tabelle für Sets, kg, Reps
                DataGrid dataGrid = new DataGrid
                {
                    HorizontalAlignment = HorizontalAlignment.Left,
                    AutoGenerateColumns = false,
                    CanUserAddRows = false,
                    HeadersVisibility = DataGridHeadersVisibility.Column,
                    ItemsSource = exercise.Sets,
                    Width = 250
                };

                dataGrid.Columns.Add(new DataGridTextColumn { Header = "Set", Binding = new Binding("SetId"), Width = 68 });
                dataGrid.Columns.Add(new DataGridTextColumn { Header = "kg", Binding = new Binding("Weight"), Width = 90 });
                dataGrid.Columns.Add(new DataGridTextColumn { Header = "Reps", Binding = new Binding("Reps"), Width = 90 });

                ExerciseList.Children.Add(dataGrid);
            }
        }

        private void LoadStats(Workout workout)
        {
            int volume = 0;
            int sets = 0;
            int reps = 0;
            foreach (Exercise exercise in workout.Exercises)
            {
                sets += exercise.Sets.Count;
                foreach (ExerciseSet exerciseSet in exercise.Sets)
                {
                    volume += exerciseSet.Weight;
                    reps += exerciseSet.Reps;
                }
            }
            WorkoutDetailsVolume.Text = "Total Volume: " + volume + "kg";
            WorkoutDetailsSets.Text = "Total Sets: " + sets;
            WorkoutDetailsReps.Text = "Total Reps: " + reps;
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
