using System.Data;
using System.Data.CData.D365Sales;
using System.Windows;

namespace CData.XamDataGrid.GropingListApp
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            sqlTextBox.Text = "SELECT name, closeprobability, actualvalue, stepname FROM opportunities";
        }

        private void ExecuteButton_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "InitiateOAuth=GETANDREFRESH;OrganizationUrl=https://sugimomoto24.crm7.dynamics.com/;";

            using (var connection = new D365SalesConnection(connectionString))
            {
                var dataAdapter = new D365SalesDataAdapter(
                sqlTextBox.Text, connection);

                var table = new DataTable();
                dataAdapter.Fill(table);

                this.DataContext = table.Rows;
            }
        }
    }
}
