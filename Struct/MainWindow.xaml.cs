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

        void set(int L, int R, int val)
        {
            for (int i = L; i < R; ++i)
            {
                stt[i] = val;
            }
        }

        int get_min(int L, int R)
        {
            int tmp = L;
            for (int i = tmp + 1; i < R; ++i)
            {
                if (stt[i] < stt[tmp])
                {
                    tmp = i;
                }
            }
            return stt[tmp];
        }

        void add(int L, int R, int val)
        {
            for (int i = L; i < R; ++i)
                stt[i] += val;
        }

        int get_sum(int L, int R)
        {
            int sum = 0;
            for (int i = L; i < R; ++i)
            {
                sum += stt[i];
            }
            return sum;
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
            set(Int32.Parse(s1.Text), Int32.Parse(s2.Text), Int32.Parse(s3.Text));
            rfrsh.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Primitives.ButtonBase.ClickEvent));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            gm.Content = get_min(Int32.Parse(gm1.Text), Int32.Parse(gm2.Text));
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            add(Int32.Parse(ad1.Text), Int32.Parse(ad2.Text), Int32.Parse(ad3.Text));
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
            gs.Content = get_sum(Int32.Parse(gs1.Text), Int32.Parse(gs2.Text));
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            // Без цикла:

            //
            for (int I = Int32.Parse(f1.Text); I < Int32.Parse(f2.Text) + 1; ++I)
            {
                // Изменяемый код в цикле ниже:
                add((3 * I) % 15, ((3 * I) % 15) + 2, I + 1);
                add(I, I + 3, -I - 1);
                
                // Конец
            }
            rfrsh.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Primitives.ButtonBase.ClickEvent));
        }
    }
}
