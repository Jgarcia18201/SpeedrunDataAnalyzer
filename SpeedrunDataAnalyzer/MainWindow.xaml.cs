using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
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
using System.Windows.Threading;

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

    private void StartButton_Click(object sender, RoutedEventArgs e)
    {
        string queryString = "SELECT StartTime FROM TimerRuns";
        string connectionString = "Data Source=DESKTOP-TVG7VL8;Initial Catalog=SpeedrunDB;Integrated Security=True;Trust Server Certificate=True";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(queryString, connection);
            //command.Parameters.AddWithValue("@tPatSName", "Your-Parm-Value");
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    Debug.WriteLine(String.Format("{0}",
                    reader["StartTime"]));// etc
                }
            }
            finally
            {
                // Always call Close when done reading.
                reader.Close();
            }
        }
    }
}