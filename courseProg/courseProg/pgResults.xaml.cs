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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace courseProg
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class pgResults : Page
    {
        public pgResults()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            int totalQues = 0;
            if (UtilityData.isBeginDone)
                totalQues = totalQues + 5;
            if (UtilityData.isIntermdiateDone)
                totalQues = totalQues + 5;
            if (UtilityData.isAdvancedDone)
                totalQues = totalQues + 5;

            tbQuesAttempted.Text = totalQues.ToString();
            tbCorrectAnswer.Text = (UtilityData.trackBeginner + UtilityData.trackIntermidiate + UtilityData.trackAdvances).ToString();

            btBeginner.Visibility = Visibility.Collapsed;
            btIntermidiate.Visibility = Visibility.Collapsed;
            btAdvance.Visibility = Visibility.Collapsed;
            switch (UtilityData.currentCourse)
            {
                case 1:
                    btBeginner.Visibility = Visibility.Visible;
                    break;
                case 2:
                    btIntermidiate.Visibility = Visibility.Visible;
                    break;
                case 3:
                    btAdvance.Visibility = Visibility.Visible;
                    break;
                default:
                    break;
            }
        }

        private void btBeginner_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(pgSpecCourse));
        }

        private void btIntermidiate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btAdvance_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
