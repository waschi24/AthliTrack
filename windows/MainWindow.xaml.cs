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
        Workouts = createTestWorkout();

        WorkoutGrid.ItemsSource = Workouts;
    }

    private void WorkoutGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        _selectedWorkout = (Workout)WorkoutGrid.SelectedItem;
        ViewWorkoutButton.IsEnabled = _selectedWorkout != null;
    }

    private void ViewWorkoutButton_Click(object sender, RoutedEventArgs e)
    {
        moveToDetails();
    }

    private void WorkoutGrid_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        moveToDetails();
    }

    private void moveToDetails()
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

    private ObservableCollection<Workout> createTestWorkout()
    {
        return new ObservableCollection<Workout>
        {
            new Workout
            {
                Name = "Strength Training",
                Start = DateTime.Now.AddHours(-1).AddMinutes(-7),
                End = DateTime.Now,
                Action = "DELETE",
                Exercises = new List<Exercise>
                {
                    new Exercise
                    {
                        Name = "Bench Press",
                        Sets = new List<ExerciseSet>
                        {
                            new ExerciseSet { SetId = 1, Weight = 40, Reps = 10 },
                            new ExerciseSet { SetId = 2, Weight = 35, Reps = 8 },
                            new ExerciseSet { SetId = 3, Weight = 30, Reps = 6 }
                        }
                    },
                    new Exercise
                    {
                        Name = "Squats",
                        Sets = new List<ExerciseSet>
                        {
                            new ExerciseSet { SetId = 1, Weight = 60, Reps = 12 },
                            new ExerciseSet { SetId = 2, Weight = 55, Reps = 10 },
                            new ExerciseSet { SetId = 3, Weight = 50, Reps = 8 }
                        }
                    }
                }
            }
        };
    }
}
