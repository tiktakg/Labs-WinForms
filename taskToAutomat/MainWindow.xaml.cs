using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Threading;

namespace taskToAutomat
{
    public partial class MainWindow : Window
    {
        #region make a variable
        double countOfTimerSeconds , countOfTrueAnswer, countOfSamples;
       

        ObservableCollection<Samples> collectionOfSamples = new ObservableCollection<Samples>();
        DispatcherTimer timer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(0.001) };
        #endregion

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MakeNewSamples_Click(object sender, RoutedEventArgs e)
        {
            gridWithSamples.Items.Clear();
            countOfTrueAnswer = 0;

            if (countSamples_textBox.Text != "")
                if (double.TryParse(countSamples_textBox.Text, out countOfSamples))
                { 
                    timer.Tick += new EventHandler(TimerTick);

                    for (int i = 0; i < countOfSamples; i++)
                    {
                        Samples sample = new Samples(i, "test" + i.ToString(), "", "test2");

                        collectionOfSamples.Add(sample);
                        gridWithSamples.Items.Add(sample);
                    }

                    makeNewSamples_button.IsEnabled = false;
                    timer.Start();
                }
                else
                    MessageBox.Show("Не правильные количество примеров");

        }

        private void ShowAnswer_Click(object sender, RoutedEventArgs e)
        {
            var allItems = gridWithSamples.Items;

            int indexOfDataGrid = 0;

            foreach (Samples sample in allItems)
            {
                if (sample.Answer == sample.TrueAnswer)
                {
                    collectionOfSamples[indexOfDataGrid].Status = true;
                    countOfTrueAnswer++;
                }
                else
                    collectionOfSamples[indexOfDataGrid].Status = false;

                indexOfDataGrid++;     
            }


            markOfWork_textBlock.Text = calculateMark().ToString();
            gridWithSamples.Items.Refresh();
            timer.Stop();
            timer_textBlock.Text = Math.Round(countOfTimerSeconds,3).ToString();

            makeNewSamples_button.IsEnabled = true;
            countOfTimerSeconds = 0;
        }

        private int calculateMark()
        {
            int mark = 0;
            double finalPercentage = 0;

            finalPercentage = countOfTrueAnswer / countOfSamples * 100;
  
            if (finalPercentage > 90)
                mark = 5;
            else if(finalPercentage > 75)
                mark = 4;
            else if (finalPercentage > 55)
                mark = 3;
            else
                mark = 2;

            return mark;
        }
        private void TimerTick(object sender, EventArgs e) => countOfTimerSeconds+= 0.001;
        private void CountSamples_gotFocus(object sender, RoutedEventArgs e) => countSamples_textBox.Text = "";
        private void CountSamples_lostFocus(object sender, RoutedEventArgs e)
        {
            if(countSamples_textBox.Text == "")
                countSamples_textBox.Text = "Введи кол-во примеров";
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
