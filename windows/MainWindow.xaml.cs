using AthliTrack.models;
using AthliTrack.windows;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AthliTrack;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public ObservableCollection<Workout> Workouts { get; set; }
    private Workout _selectedWorkout;

    public MainWindow()
    {
        InitializeComponent();
        Workouts = new ObservableCollection<Workout>
        {
            new Workout { Name = "Cardio", Start = DateTime.Now.AddMinutes(-30), End = DateTime.Now, Action = "Completed",
                Exercises = new List<Exercise>
                {
                    new Exercise { Name = "Jump Rope", Sets = 3, Reps = 50 },
                    new Exercise { Name = "Burpees", Sets = 3, Reps = 20 }
                }
            },
            new Workout { Name = "Strength", Start = DateTime.Now.AddHours(-1), End = DateTime.Now.AddMinutes(-30), Action = "Completed",
                Exercises = new List<Exercise>
                {
                    new Exercise { Name = "Bench Press", Sets = 4, Reps = 10 },
                    new Exercise { Name = "Squats", Sets = 4, Reps = 12 }
                }
            }
        };

        WorkoutGrid.ItemsSource = Workouts;
    }

    private void WorkoutGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        _selectedWorkout = (Workout)WorkoutGrid.SelectedItem;
        ViewWorkoutButton.IsEnabled = _selectedWorkout != null;
    }

    private void ViewWorkoutButton_Click(object sender, RoutedEventArgs e)
    {
        if (_selectedWorkout != null)
        {
            // Position des aktuellen Fensters speichern
            double left = this.Left;
            double top = this.Top;

            // Neues Fenster mit Position öffnen
            var detailWindow = new WorkoutDetails(_selectedWorkout)
            {
                Left = left,
                Top = top
            };

            detailWindow.Show();

            // Altes Fenster schließen
            this.Close();
        }
    }
}
