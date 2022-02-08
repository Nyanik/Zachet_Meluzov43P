﻿using System;
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

namespace ProjectLearn
{
    /// <summary>
    /// Логика взаимодействия для SerList.xaml
    /// </summary>
    public partial class SerList : Page
    {
        public SerList()
        {
            InitializeComponent();
            BaseClass.Base = new Entities();
            LVServices.ItemsSource = BaseClass.Base.Service.ToList();
        }
        private void TextBlock_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            int index = Convert.ToInt32(tb.Uid);
            List<Service> TC = BaseClass.Base.Service.Where(x => x.ID == index).ToList();
            string str = "";
            foreach (Service item in TC)
            {
                str += item.Title;
            }
            tb.Text = str.Substring(0);

        }

        private void TextBlock_Loaded_1(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            int index = Convert.ToInt32(tb.Uid);
            List<Service> TC = BaseClass.Base.Service.Where(x => x.ID == index).ToList();
            string str = "";
            foreach (Service item in TC)
            {
                if (item.Discount != 0)
                {

                    int cs = Convert.ToInt32(item.Cost) - Convert.ToInt32(Convert.ToDouble(item.Cost) * Convert.ToDouble(item.Discount));
                    str += cs;
                }
                else
                {
                    int cs = Convert.ToInt32(item.Cost);
                    str += cs;
                }
            }
            tb.Text = "Цена:" + str.Substring(0) + " руб";
        }

        private void TextBlock_Loaded_2(object sender, RoutedEventArgs e)
        {

            TextBlock tb = (TextBlock)sender;
            int index = Convert.ToInt32(tb.Uid);
            List<Service> TC = BaseClass.Base.Service.Where(x => x.ID == index).ToList();
            string str = "";
            foreach (Service item in TC)
            {

                int time = item.DurationInSeconds / 60;
                str += time;
            }
            tb.Text = str.Substring(0) + " минут";
        }

        private void TextBlock_Loaded_3(object sender, RoutedEventArgs e)
        {

            TextBlock tb = (TextBlock)sender;
            int index = Convert.ToInt32(tb.Uid);
            List<Service> TC = BaseClass.Base.Service.Where(x => x.ID == index).ToList();
            string str = "";
            foreach (Service item in TC)
            {
                double dis = Convert.ToDouble(item.Discount) * 100;
                str += dis;
            }
            tb.Text = "Скидка: " + str.Substring(0) + "%";
        }


        private void Del_Click(object sender, RoutedEventArgs e)
        {
            Button B = (Button)sender;
            int ind = Convert.ToInt32(B.Uid);
            Service SerDelete = BaseClass.Base.Service.FirstOrDefault(y => y.ID == ind);
            BaseClass.Base.Service.Remove(SerDelete);
            BaseClass.Base.SaveChanges();
            MessageBox.Show("Запись удалена");
            FrameClass.FrameMain.Navigate(new SerList());
        }
        bool flag = false;
        private void Admin_Click(object sender, RoutedEventArgs e)
        {
            Avtr avtr = new Avtr();
            if (avtr.ShowDialog() == true)
            {
                if (avtr.Password == "0000")
                {
                    MessageBox.Show("Авторизация пройдена");
                    flag = true;
                }

                else
                { MessageBox.Show("Неверный пароль"); }

            }
            else
            {
                MessageBox.Show("Авторизация не пройдена");
            }
           
        }
    }
}
