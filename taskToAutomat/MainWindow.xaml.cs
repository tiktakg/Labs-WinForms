using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        ObservableCollection<Samples> dataCollection = new ObservableCollection<Samples>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MakeNewSamples_Click(object sender, RoutedEventArgs e)
        {
            Samples sample = new Samples(1,"test","test1","test2");
            dataCollection.Add(sample);
            gridWithSamples.Items.Add(sample);
        }

        private void ShowAnswer_Click(object sender, RoutedEventArgs e)
        {
            var allItems = gridWithSamples.Items;



            //Samples selectedItem = (Samples)gridWithSamples.hea.SelectedItem;

            Samples itemToModify = dataCollection[0];

            Samples sample = new Samples(5, "t2est", "te2st1", "tes2t2");
          


            int index = 0;
            foreach (Samples item in allItems)
            {
                if (item.Answer != item.TrueAnswer)
                {
                    dataCollection[index].Status = false;
                }
                else
                {
                    dataCollection[index].Status = true;
                }

                //dataCollection[index];
                index++;
            }

            gridWithSamples.Items.Refresh();


        }
    }
    public class Samples
    {
        public int ID { get; set; }
        public string Sample { get; set; }
        public string Answer { get; set; }
        public string TrueAnswer { get; set; }
        public bool? Status { get; set; }

        public Samples(int id, string sample, string answer, string trueAnswer)
        {
            ID = id;
            Sample = sample;
            Answer = answer;
            TrueAnswer = trueAnswer;
            Status = null;
        }
    }

}
