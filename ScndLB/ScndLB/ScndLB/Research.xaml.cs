using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScndLB
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Research : ContentPage
    {
        int mode;
        int comparsions;
        int permutations;
        int min_comparsions = 1000;
        int min_permutations=1000;

        System.TimeSpan time;
        public Research()
        {
            InitializeComponent();
        }

        private unsafe void Swap(ref StringBuilder arr, int frst, int scnd)
        {
            char temp = arr[frst];
            arr[frst] = arr[scnd];
            arr[scnd] = temp;
        }

        private unsafe void clearString(ref StringBuilder str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                {
                    str.Remove(i, 1);
                }
            }
        }


        private void SwitchFirst(object sender,EventArgs e)
        {
            First.IsVisible= true;
            Diap.IsVisible= true;
            Second.IsVisible = false;
            NumNum.IsVisible = false;
            Third.IsVisible = false;
            NumNotSorted.IsVisible = false;
            Fourth.IsVisible = false;
            AnotherDiap.IsVisible = false;
            mode = 1;
        }

        private void SwitchScnd(object sender, EventArgs e)
        {
            First.IsVisible = true;
            Diap.IsVisible = true;
            Second.IsVisible = true;
            NumNum.IsVisible = true;
            Third.IsVisible = true;
            NumNotSorted.IsVisible = true;
            Fourth.IsVisible = false;
            AnotherDiap.IsVisible = false;
            mode = 3;
        }

        private void SwitchThrd(object sender, EventArgs e)
        {
            First.IsVisible = true;
            Diap.IsVisible = true;
            Second.IsVisible = true;
            NumNum.IsVisible = true;
            Third.IsVisible = false;
            NumNotSorted.IsVisible = false;
            Fourth.IsVisible = false;
            AnotherDiap.IsVisible = false;
            mode = 2;
        }
        private void SwitchFourth(object sender, EventArgs e)
        {
            First.IsVisible = true;
            Diap.IsVisible = true;
            Second.IsVisible = true;
            NumNum.IsVisible = true;
            Third.IsVisible = false;
            NumNotSorted.IsVisible = false;
            Fourth.IsVisible = true;
            AnotherDiap.IsVisible = true;
            mode = 4;
        }

        private void StartResearch(object sender, EventArgs e)
        {
            StringBuilder array;
            int rangeNum;
            int size;
            var rand = new Random(); ;
            int scndRng;
            switch (mode)
            {
                case 1:
                    rangeNum = int.Parse(Diap.Text);
                    array = new StringBuilder();
                    for (int i = 0; i < rangeNum; i++)
                    {
                        array.Append(Convert.ToString(i));
                    }
                    Name_Sort.Text = research(Convert.ToString(array));
                    Name_Sort.IsVisible = true;
                    break;
                case 2:
                    rangeNum = int.Parse(Diap.Text);
                    size = int.Parse(NumNum.Text);
                    rand = new Random();
                    array = new StringBuilder();
                    for (int i = 0; i < size; i++)
                    {
                        array.Append(Convert.ToString(rand.Next(1, rangeNum)));
                    }
                    Name_Sort.Text = research(Convert.ToString(array));
                    array = button1_Click(Convert.ToString(array));
                    Name_Sort.IsVisible= true;
                    break;
                case 3:
                    rangeNum = int.Parse(NumNotSorted.Text);
                    size = int.Parse(NumNum.Text);
                    scndRng = int.Parse(Diap.Text);
                    array = new StringBuilder();
                    for (int i = 0; i < size - rangeNum; i++)
                    {
                        array.Append(Convert.ToString(i));

                    }
                    rand = new Random();
                    for (int i = rangeNum; i < size; i++)
                    {
                        array.Append(Convert.ToString(rand.Next(1, scndRng)));

                    }
                    Name_Sort.Text = research(Convert.ToString(array));
                    if (Name_Sort.Text == "Пузырек")
                    {
                        array = button1_Click(Convert.ToString(array));
                    }
                    if (Name_Sort.Text == "Выбор")
                    {
                        array = ChoiceButton_Click(Convert.ToString(array));
                    }
                    if (Name_Sort.Text == "Вставка")
                    {
                        array = InsertionButton_Click(Convert.ToString(array));
                    }
                    if (Name_Sort.Text == "Шелл")
                    {
                        array = ShellButton_Click(Convert.ToString(array));
                    }
                    if (Name_Sort.Text == "Быстрая")
                    {
                        array = QuickButton_Click(Convert.ToString(array));
                    }
                    Name_Sort.IsVisible = true;
                    break;
                case 4:
                    rangeNum = int.Parse(Diap.Text);
                    size = int.Parse(NumNum.Text);
                    scndRng = int.Parse(AnotherDiap.Text);
                    array = new StringBuilder();
                    for (int i = 0; i < size - scndRng; i++)
                    {
                        array.Append(Convert.ToString(i));

                    }
                    rand = new Random();
                    for (int i = scndRng; i < size; i++)
                    {
                        array.Append(Convert.ToString(rand.Next(1, rangeNum)));

                    }
                    Name_Sort.Text = research(Convert.ToString(array));
                    if (Name_Sort.Text == "Пузырек")
                    {
                        array = button1_Click(Convert.ToString(array));
                    }
                    if (Name_Sort.Text == "Выбор")
                    {
                        array = ChoiceButton_Click(Convert.ToString(array));
                    }
                    if (Name_Sort.Text == "Вставка")
                    {
                        array = InsertionButton_Click(Convert.ToString(array));
                    }
                    if (Name_Sort.Text == "Шелл")
                    {
                        array = ShellButton_Click(Convert.ToString(array));
                    }
                    if (Name_Sort.Text == "Быстрая")
                    {
                        array = QuickButton_Click(Convert.ToString(array));
                    }
                    Name_Sort.IsVisible = true;
                    break;
                default:
                    break;
            }
            Diap.Text = null;
            NumNum.Text = null;
            NumNotSorted.Text = null;
            AnotherDiap.Text = null;
        }

        private StringBuilder button1_Click(string txt)
        {
            comparsions = 0;
            permutations= 0;
            StringBuilder buble = new StringBuilder(txt);
            bool notOver = true;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            while (notOver)
            {
                notOver = false;
                for (int i = 0; i < buble.Length - 1; i++)
                {
                    comparsions += 1;
                    if (Convert.ToInt32(buble[i]) > Convert.ToInt32(buble[i + 1]))
                    {
                        permutations += 1;
                        notOver = true;
                        Swap(ref buble, i, i + 1);
                    }
                }
            }
            time = stopWatch.Elapsed;
            stopWatch.Stop();
            if (min_comparsions > comparsions)
            {
                min_comparsions = comparsions;
            }
            if (min_permutations > permutations)
            {
                min_permutations = permutations;
            }
            return buble;
        }

        private StringBuilder ChoiceButton_Click(string txt)
        {
            StringBuilder Choice = new StringBuilder(txt);
            clearString(ref Choice);
            int comparsions = 0;
            int permutations = 0;
            int pos;
            int min;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            for (int k = 0; k < Choice.Length; k++)
            {
                pos = k;
                min = Choice[pos];
                for (int j = k + 1; j <= Choice.Length - 1; j++)
                {
                    if (min > Choice[j])
                    {
                        comparsions += 1;
                        min = Choice[j];
                        pos = j;
                    }
                    else
                    {
                        comparsions += 1;
                    }
                }
                if (pos != k)
                {
                    permutations += 1;
                    Swap(ref Choice, k, pos);
                }
            }
            time = stopWatch.Elapsed;
            stopWatch.Stop();
            if (min_comparsions > comparsions)
            {
                min_comparsions = comparsions;
            }
            if (min_permutations > permutations)
            {
                min_permutations = permutations;
            }
            return Choice;
        }

        private StringBuilder InsertionButton_Click(string txt)
        {
            StringBuilder Insertion = new StringBuilder(txt);
            clearString(ref Insertion);
            int comparsions = 0;
            int permutations = 0;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            for (int k = 0; k < Insertion.Length; k++)
            {
                for (int j = k; j > 0; j--)
                {
                    comparsions += 1;
                    if (Insertion[j - 1] > Insertion[j])
                    {
                        permutations += 1;
                        Swap(ref Insertion, j - 1, j);
                    }
                }
            }
            time = stopWatch.Elapsed;
            stopWatch.Stop();
            if (min_comparsions > comparsions)
            {
                min_comparsions = comparsions;
            }
            if (min_permutations > permutations)
            {
                min_permutations = permutations;
            }
            return Insertion;
        }

        private StringBuilder ShellButton_Click(string txt)
        {
            StringBuilder Shell = new StringBuilder(txt);
            clearString(ref Shell);
            int comparsions = 0;
            int permutations = 0;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            int step = Shell.Length / 2;
            int j = 0;
            while (step > 0)
            {
                for (int i = 0; i < Shell.Length - step; i++)
                {
                    j = i;
                    while (j >= 0)
                    {
                        if (Shell[j] > Shell[j + step])
                        {
                            permutations += 1;
                            Swap(ref Shell, j, j + step);
                        }
                        j--;
                    }
                    comparsions += 1;
                }
                step /= 2;
            }
            time = stopWatch.Elapsed;
            stopWatch.Stop();
            if (min_comparsions > comparsions)
            {
                min_comparsions = comparsions;
            }
            if (min_permutations > permutations)
            {
                min_permutations = permutations;
            }
            return Shell;
        }

        unsafe StringBuilder QuickRowSort(StringBuilder vct, int first, int last, int* numOfComparsion, int* numOfPermutation)
        {
            int mid;
            int f = first, l = last;
            mid = Convert.ToInt32(vct[(f + l) / 2]);
            while (f < l)
            {
                if (Convert.ToInt32(vct[f]) < mid)
                {
                    *numOfComparsion += 1;
                    while (Convert.ToInt32(vct[f]) < mid)
                    {
                        f++;
                    }
                }
                else
                {
                    *numOfComparsion += 1;
                }
                if (Convert.ToInt32(vct[l]) > mid)
                {
                    *numOfComparsion += 1;
                    while (Convert.ToInt32(vct[l]) > mid)
                    {
                        l--;
                    }
                }
                else
                {
                    *numOfComparsion += 1;
                }
                if (f <= l)
                {
                    *numOfPermutation += 1;
                    Swap(ref vct, f, l);
                    f++;
                    l--;
                }
            }
            if (first < l) QuickRowSort(vct, first, l, numOfComparsion, numOfPermutation);
            if (f > last) QuickRowSort(vct, f, last, numOfComparsion, numOfPermutation);
            return vct;
        }
        unsafe private StringBuilder QuickButton_Click(string txt)
        {
            StringBuilder Quick = new StringBuilder(txt);
            clearString(ref Quick);
            int comparsions = 0;
            int permutations = 0;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            Quick = QuickRowSort(Quick, 0, Quick.Length - 1, &comparsions, &permutations);
            time = stopWatch.Elapsed;
            stopWatch.Stop();
            if (min_comparsions > comparsions)
            {
                min_comparsions = comparsions;
            }
            if (min_permutations > permutations)
            {
                min_permutations = permutations;
            }
            return Quick;
        }


        private string research(string txt)
        {
            System.TimeSpan time1;
            System.TimeSpan time2;
            System.TimeSpan time3;
            System.TimeSpan time4;
            System.TimeSpan time5;
            string sortStr = "Пузырек";
            button1_Click(txt);
            time1 = time;
            ChoiceButton_Click(txt);
            time2 = time;
            InsertionButton_Click(txt);
            time3 = time;
            ShellButton_Click(txt);
            time4 = time;
            QuickButton_Click(txt);
            time5 = time;
            if ((time1 < time2) || (time1 < time3) || (time1 < time4) || (time1 < time5))
            {
                sortStr = "Лучшая сортировка - Пузырек. Время сортировки - " + time1 + " Сравнения - " + min_comparsions + " Перестановки - " + min_permutations;
            }
            if ((time2 < time1) || (time2 < time3) || (time2 < time4) || (time2 < time5))
            {
                sortStr = "Лучшая сортировка - Выбор. Время сортировки - " + time2 + " Сравнения - " + min_comparsions + " Перестановки - " + min_permutations;
            }
            if ((time3 < time1) || (time3 < time2) || (time3 < time4) || (time3 < time5))
            {
                sortStr = "Лучшая сортировка - Вставка. Время сортировки - " + time3 + " Сравнения - " + min_comparsions + " Перестановки - " + min_permutations;
            }
            if ((time4 < time1) || (time4 < time2) || (time4 < time3) || (time4 < time5))
            {
                sortStr = "Лучшая сортировка - Шелл. Время сортировки - " + time4 + " Сравнения - " + min_comparsions + " Перестановки - " + min_permutations;
            }
            if ((time5 < time1) || (time5 < time2) || (time5 < time3) || (time5 < time4))
            {
                sortStr = "Лучшая сортировка - Быстрая. Время сортировки - " + time5 + " Сравнения - " + min_comparsions + " Перестановки - " + min_permutations;
            }
            return sortStr;
        }
    }
}