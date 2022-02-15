using System.Windows;

namespace CoolHacker
{
    /// <summary>
    /// Логика взаимодействия для TotalWindow.xaml
    /// </summary>
    public partial class TotalWindow : Window
    {
        public TotalWindow()
        {
            InitializeComponent();
        }
        public TotalWindow(string TotalMessage)
        {
            InitializeComponent();
            TotalTxtBlk.Text = TotalMessage;
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
