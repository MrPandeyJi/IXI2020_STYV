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
    public sealed partial class Cplusplus : Page
    {
        int quesCount = 1;
        int beginCount = 0;
        int intermidiateCount = 0;
        int advancedCount = 0;
        classQuiz objCurrentQues = new classQuiz();
        public Cplusplus()
        {
            this.InitializeComponent();
            getQuesInfo();
        }

        private void btNext_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)rb1.IsChecked || (bool)rb2.IsChecked || (bool)rb3.IsChecked || (bool)rb4.IsChecked)
            {
                getResults();
                getQuesInfo();
                rb1.IsChecked = false;
                rb2.IsChecked = false;
                rb3.IsChecked = false;
                rb4.IsChecked = false;
            }
            else
            {
                UtilityClass.MessageDialog("You have to select an answer", "No Answer selected");
            }
        }

        private void getResults()
        {
            if (beginCount <= 5 && !UtilityData.isBeginDone)
            {
                if ((bool)rb1.IsChecked)
                {
                    if (objCurrentQues.correctOpt == rb1.Content.ToString())
                        UtilityData.trackBeginner++;
                }
                else if ((bool)rb2.IsChecked)
                {
                    if (objCurrentQues.correctOpt == rb2.Content.ToString())
                        UtilityData.trackBeginner++;
                }
                else if ((bool)rb3.IsChecked)
                {
                    if (objCurrentQues.correctOpt == rb3.Content.ToString())
                        UtilityData.trackBeginner++;
                }
                else
                    if (objCurrentQues.correctOpt == rb4.Content.ToString())
                    UtilityData.trackBeginner++;
                if (beginCount == 5)
                {
                    quesCount = 16;
                    UtilityData.isBeginDone = true;
                    if (UtilityData.trackBeginner < 3)
                    {
                        UtilityData.currentCourse = 1;
                        this.Frame.Navigate(typeof(pgResults));
                    }
                }
                tbResult.Text = UtilityData.trackBeginner.ToString();
            }

            else if (intermidiateCount <= 5 && !UtilityData.isIntermdiateDone)
            {
                if ((bool)rb1.IsChecked)
                {
                    if (objCurrentQues.correctOpt == rb1.Content.ToString())
                        UtilityData.trackIntermidiate++;
                }
                else if ((bool)rb2.IsChecked)
                {
                    if (objCurrentQues.correctOpt == rb2.Content.ToString())
                        UtilityData.trackIntermidiate++;
                }
                else if ((bool)rb3.IsChecked)
                {
                    if (objCurrentQues.correctOpt == rb3.Content.ToString())
                        UtilityData.trackIntermidiate++;
                }
                else
                    if (objCurrentQues.correctOpt == rb4.Content.ToString())
                    UtilityData.trackIntermidiate++;
                if (intermidiateCount == 5)
                {
                    quesCount = 26;
                    UtilityData.isIntermdiateDone = true;
                    if (UtilityData.trackIntermidiate < 3)
                    {
                        UtilityData.currentCourse = 2;
                        this.Frame.Navigate(typeof(pgResults));
                    }
                }
                tbResult.Text = UtilityData.trackIntermidiate.ToString();
            }

            else if (advancedCount <= 5 && !UtilityData.isAdvancedDone)
            {
                if ((bool)rb1.IsChecked)
                {
                    if (objCurrentQues.correctOpt == rb1.Content.ToString())
                        UtilityData.trackAdvances++;
                }
                else if ((bool)rb2.IsChecked)
                {
                    if (objCurrentQues.correctOpt == rb2.Content.ToString())
                        UtilityData.trackAdvances++;
                }
                else if ((bool)rb3.IsChecked)
                {
                    if (objCurrentQues.correctOpt == rb3.Content.ToString())
                        UtilityData.trackAdvances++;
                }
                else
                    if (objCurrentQues.correctOpt == rb4.Content.ToString())
                    UtilityData.trackAdvances++;
                if (advancedCount == 5)
                {
                    quesCount = 36;
                    UtilityData.isAdvancedDone = true;

                    if (UtilityData.trackAdvances < 3)
                    {
                        UtilityData.currentCourse = 2;
                    }
                    else
                    {
                        UtilityData.currentCourse = 3;
                    }
                    UtilityClass.MessageDialog("Test Complete", "Test Complete");
                    this.Frame.Navigate(typeof(pgResults));
                }
                tbResult.Text = UtilityData.trackAdvances.ToString();
            }
        }

        private void getQuesInfo()
        {
            objCurrentQues = dbHelperClass.getQuestions(objCurrentQues, quesCount);
            quesCount++;
            tbQues.Text = objCurrentQues.q_ques;
            rb1.Content = objCurrentQues.Opt1;
            rb2.Content = objCurrentQues.Opt2;
            rb3.Content = objCurrentQues.Opt3;
            rb4.Content = objCurrentQues.Opt4;
            if (beginCount <= 5 && !UtilityData.isBeginDone)
            {
                beginCount++;

            }
            else if (intermidiateCount <= 5 && !UtilityData.isIntermdiateDone)
            {
                intermidiateCount++;
            }
            else if (advancedCount <= 5 && !UtilityData.isAdvancedDone)
            {
                advancedCount++;
            }
        }
    }
}
