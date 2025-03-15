using Microsoft.EntityFrameworkCore;
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

namespace SpeedrunDataAnalyzer;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        FetchRunId();
    }

    private async void FetchRunId()
    {
        using (var context = new DataContext())
        {
            var run = await context.TimerRuns.FirstOrDefaultAsync();
            if (run != null)
            {
                DataContext = run;
            }
        }
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {

    }
}