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
using System.Windows.Shapes;

namespace Login
{
    /// <summary>
    /// Interaction logic for Welcome.xaml
    /// </summary>
    public partial class Welcome : Window
    {
   
        string _imagedirectory = @"C:\Users\rushabhg\Documents\Visual Studio 2012\Projects\Login\Login\Images";
        Random ran = new Random();
        public Welcome()
        {
            InitializeComponent();
        }


        private void goButton_Click_1(object sender, RoutedEventArgs e)
        {
            string[] imagepath = System.IO.Directory.GetFiles(_imagedirectory, "*.jpg");
            BitmapImage bitmapimage = new BitmapImage(new Uri(imagepath[ran.Next(imagepath.Length)]));
            image.Source = bitmapimage;
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Logout Successfully......!!!!!!");
            Login1 log = new Login1();
            log.Show();
            Close();
        }
  

    }
}
