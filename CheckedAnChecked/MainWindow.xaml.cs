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

namespace CheckedAnChecked
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int a = int.Parse(Txt1.Text);
                int b = int.Parse(Txt2.Text);
                checked
                {
                    Res.Content = a * b;
                }
            }
            catch (OverflowException)
            {
                Res.Content = "error of overflow";
            }
            catch (FormatException)
            {
                Res.Content = "error of incorrect input";
            }
        }
    }
}
