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
    public partial class test : ContentPage
    {
        public test()
        {
            InitializeComponent();
        }

        private void LabelOutput(int comparsions, int permutations, System.TimeSpan time, StringBuilder arr, string nameSort)
        {
            Inf.Text ="Сравнения - " + comparsions + "\nПерестановки - " + permutations + "\nВремя - " + time + "\nОтсортированный массив - " + arr + "\nИмя сортировки - " + nameSort;
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

        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder buble = new StringBuilder(Arr.Text);
            clearString(ref buble);
            int comparsions = 0;
            int permutations = 0;
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
            stopWatch.Stop();
            LabelOutput(comparsions, permutations, stopWatch.Elapsed, buble, "Пузырьковая");
        }

        private void ChoiceButton_Click(object sender, EventArgs e)
        {
            StringBuilder Choice = new StringBuilder(Arr.Text);
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
            stopWatch.Stop();
            LabelOutput(comparsions, permutations, stopWatch.Elapsed, Choice, "Отбор");
        }

        private void InsertionButton_Click(object sender, EventArgs e)
        {
            StringBuilder Insertion = new StringBuilder(Arr.Text);
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
            stopWatch.Stop();
            LabelOutput(comparsions, permutations, stopWatch.Elapsed, Insertion, "Вставками");
        }

        private void ShellButton_Click(object sender, EventArgs e)
        {
            StringBuilder Shell = new StringBuilder(Arr.Text);
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
            stopWatch.Stop();
            LabelOutput(comparsions, permutations, stopWatch.Elapsed, Shell, "Шелл");
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
        unsafe private void QuickButton_Click(object sender, EventArgs e)
        {
            StringBuilder Quick = new StringBuilder(Arr.Text);
            clearString(ref Quick);
            int comparsions = 0;
            int permutations = 0;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            Quick = QuickRowSort(Quick, 0, Quick.Length - 1, &comparsions, &permutations);
            stopWatch.Stop();
            LabelOutput(comparsions, permutations, stopWatch.Elapsed, Quick, "Быстрая");
        }
    }
}