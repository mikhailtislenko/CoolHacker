using System.Windows;
using System.Windows.Input;

namespace CoolHacker
{
    /// <summary>
    /// Логика взаимодействия для PurposeWindow.xaml
    /// </summary>
    public partial class PurposeWindow : Window
    {
        public PurposeWindow()
        {
            InitializeComponent();
        }

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Manager.purpose_of_the_machine = "Low";
            this.Close();
        }

        private void Label_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            Manager.purpose_of_the_machine = "Middle";
            this.Close();
        }

        private void Label_MouseDoubleClick_2(object sender, MouseButtonEventArgs e)
        {
            Manager.purpose_of_the_machine = "Gaming";
            this.Close();
        }
    }
}
