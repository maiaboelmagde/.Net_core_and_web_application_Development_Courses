using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Lab1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void CalcAge(object sender, RoutedEventArgs e)
        {
            try
            {
                bool validInput = int.TryParse(txtBox1.Text, out int birthYear);
                if (validInput)
                {
                    int currentYear = DateTime.Now.Year;
                    int age = currentYear - birthYear;
                    if(currentYear < birthYear)
                    {
                        throw new Exception("Invalid Year !!");
                    }
                    resultTXT.Text = age.ToString();
                    resultTXT.Foreground = new SolidColorBrush(Windows.UI.Colors.Black);
                    resultTXT.FontSize = 50;
                }
                else
                {
                    resultTXT.Text = "Invalid Input !!!!";
                    resultTXT.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
                    resultTXT.FontSize = 30;
                }
            }catch(Exception ex)
            {
                resultTXT.Text = "Error : "+ex.ToString();
                resultTXT.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
                resultTXT.FontSize = 15;
            }
        }
    }
}
