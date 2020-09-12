using System;
using System.Data;
using System.Windows;

namespace Struct
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int[] stt;
        DataTable dt;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            stt = new int[Int32.Parse(crt.Text)];
            for (int i = 0; i < stt.Length; ++i)
            {
                stt[i] = 0;
            }
            rfrsh.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Primitives.ButtonBase.ClickEvent));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            for (int i = Int32.Parse(s1.Text); i < Int32.Parse(s2.Text); ++i)
            {
                stt[i] = Int32.Parse(s3.Text);
            }
            rfrsh.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Primitives.ButtonBase.ClickEvent));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int tmp = Int32.Parse(gm1.Text);
            for (int i = tmp + 1; i < Int32.Parse(gm2.Text); ++i)
            {
                if (stt[i] < stt[tmp])
                {
                    tmp = i;
                }
            }
            gm.Content = stt[tmp];
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            for (int i = Int32.Parse(ad1.Text); i < Int32.Parse(ad2.Text); ++i)
                stt[i] += Int32.Parse(ad3.Text);
            rfrsh.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Primitives.ButtonBase.ClickEvent));
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            dt = new DataTable();
            for (int i = 0; i < stt.Length; ++i)
            {
                dt.Columns.Add(i.ToString());
            }
            DataRow row = dt.NewRow();
            for (int i = 0; i < stt.Length; ++i)
            {
                row[i.ToString()] = stt[i];
            }
            dt.Rows.Add(row);
            dg.DataContext = dt.DefaultView;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            int sum = 0;
            for (int i = Int32.Parse(gs1.Text); i < Int32.Parse(gs2.Text); ++i)
            {
                sum += stt[i];
            }
            gs.Content = sum;
        }

        void add(int L, int R, int val)
        {
            for (int i = L; i < R; ++i)
                stt[i] += val;
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            for (int I = Int32.Parse(f1.Text); I < Int32.Parse(f2.Text) + 1; ++I)
            {
                // Изменяемый код ниже:
                add((3 * I) % 15, ((3 * I) % 15) + 2, I + 1);
                add(I, I + 3, -I - 1);
                
                // Конец
            }
            rfrsh.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Primitives.ButtonBase.ClickEvent));
        }
    }
}
