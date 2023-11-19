using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
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
            takeDataFromDB();

            gridWithSamples.Items.Clear();
            countOfTrueAnswer = 0;

            if (countSamples_textBox.Text != "" )
                if (double.TryParse(countSamples_textBox.Text, out countOfSamples))
                {
                    timer.Tick += new EventHandler(TimerTick);

                    takeDataFromDB();

                    makeNewSamples_button.IsEnabled = false;
                    timer.Start();
                }
            else
                MessageBox.Show("Не правильные количество примеров или не выбарнны примеры");
        }

        private void ShowAnswer_Click(object sender, RoutedEventArgs e)
        {
            var allItems = gridWithSamples.Items;

            var idColumn = gridWithSamples.Columns.FirstOrDefault(column => column.Header.ToString() == "TrueAnswer") as DataGridTextColumn;

            idColumn.Visibility = Visibility.Visible;

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
        private void takeDataFromDB()
        {
            using (DBContext Db = new DBContext())
            {             
                var samples = Db.samples.ToList();

                int currentCountOfSamples = 0;
                foreach (samplesFromDB sample in samples)
                {
                    Samples sampleForDataGrid = null;
                    if (unstressedVowel1_checkBox.IsEnabled & sample.idParametr == 1)
                        sampleForDataGrid = new Samples(currentCountOfSamples, sample.Samples, "", sample.TrueSamples);
                    else if (vocabularyWord2_checkBox.IsEnabled & sample.idParametr == 2)
                        sampleForDataGrid = new Samples(currentCountOfSamples, sample.Samples, "", sample.TrueSamples);
                    else if(endingsOfDeclensions3_checkBox.IsEnabled & sample.idParametr == 3)
                        sampleForDataGrid = new Samples(currentCountOfSamples, sample.Samples, "", sample.TrueSamples);
                    else if(voicelessConsonants4_checkBox.IsEnabled & sample.idParametr == 4)
                        sampleForDataGrid = new Samples(currentCountOfSamples, sample.Samples, "", sample.TrueSamples);

                    collectionOfSamples.Add(sampleForDataGrid);
                    gridWithSamples.Items.Add(sampleForDataGrid);
                    currentCountOfSamples++;

                    if(currentCountOfSamples == samples.Count) 
                        break;
                }
            }
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
