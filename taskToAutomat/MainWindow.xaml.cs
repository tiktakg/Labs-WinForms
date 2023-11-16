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

namespace taskToAutomat
{
 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MakeNewSamples_Click(object sender, RoutedEventArgs e)
        {
            gridWithSamples.Items.Add("12", "he");
        }

        private void ShowAnswer_Click(object sender, RoutedEventArgs e)
        {

           


        }
    }
    public class Customer
    {
        public int ID { get; set; }
        public string Sample { get; set; }
        public string Answer { get; set; }
        public string TrueAnswer { get; set; }
        public bool Status { get; set; }
    }

}
