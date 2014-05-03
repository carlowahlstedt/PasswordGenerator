using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;
using System.Globalization;
using System.Windows.Interop;

namespace PasswordGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@$?_-";

        public MainWindow()
        {
            InitializeComponent();

            this.Icon = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.cryptography.ToBitmap().GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            char[] chars = new char[(int)this.slider1.Value];
            Random rd = new Random();

            for (int i = 0; i <= (int)this.slider1.Value - 1; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }

            string password = new string(chars);

            this.txtPassword.Text = password;
        }

        private void slider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (this.lblSize != null)
            {
                this.lblSize.Content = this.slider1.Value.ToString();
            }
        }
    }
}
