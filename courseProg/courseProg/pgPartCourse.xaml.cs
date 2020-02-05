using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public sealed partial class pgPartCourse : Page
    {
        ObservableCollection<classQuiz> obcQuiz = new ObservableCollection<classQuiz>();
        public pgPartCourse()
        {
            this.InitializeComponent();
        }

        private void getCourseInfo()
        {

            string html = @"<iframe width=""100%"" height=""420""  src=""http://www.youtube.com/embed/" + UtilityData.objCurrentCourse.ytb_link1 + @"?rel=0"" ></iframe>";

            this.webCourse.NavigateToString(html);
            tbHeader.Text = UtilityData.objCurrentCourse.c_name;
            tbDesc.Text = UtilityData.objCurrentCourse.c_desc;
            tbFaq1.Text = UtilityData.objCurrentCourse.faq1;
            if (tbFaq1.Text == "")
                tbFaq1.Visibility = Visibility.Collapsed;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            getCourseInfo();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //string videoID = "GhQdlIFylQ8";

            //this.webCourse.NavigateToString(html);
        }

        private void btBack_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(pgSpecCourse));
        }

        private int currentQuesCount = 0;
        private int correctAns = 0;
        private void btTestYourself_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                correctAns = 0;
                spTest.Visibility = Visibility.Visible;
                spResult.Visibility = Visibility.Collapsed;
                currentQuesCount = 0;
                gdTestQues.Visibility = Visibility.Visible;
                dbHelperClass.getTestQuestions(obcQuiz, UtilityData.objCurrentCourse.c_id);
                classQuiz objQuiz = (classQuiz)obcQuiz[0];
                tbQues.Text = objQuiz.q_ques;
                rb1.Content = objQuiz.Opt1;
                rb2.Content = objQuiz.Opt2;
                rb3.Content = objQuiz.Opt3;
                rb4.Content = objQuiz.Opt4;
                currentQuesCount++;
            }
            catch (Exception)
            {

            }
        }

        private void btSkiptoNextLesson_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btBackQues_Click(object sender, RoutedEventArgs e)
        {
            gdTestQues.Visibility = Visibility.Collapsed;
        }

        private void btNext_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)rb1.IsChecked || (bool)rb2.IsChecked || (bool)rb3.IsChecked || (bool)rb4.IsChecked)
            {
                try
                {
                    if (currentQuesCount <= 3)
                    {
                        if ((bool)rb1.IsChecked)
                        {
                            if (obcQuiz[currentQuesCount - 1].correctOpt == rb1.Content.ToString())
                                correctAns++;
                        }
                        else if ((bool)rb2.IsChecked)
                        {
                            if (obcQuiz[currentQuesCount - 1].correctOpt == rb2.Content.ToString())
                                correctAns++;
                        }
                        else if ((bool)rb3.IsChecked)
                        {
                            if (obcQuiz[currentQuesCount - 1].correctOpt == rb3.Content.ToString())
                                correctAns++;
                        }
                        else
                            if (obcQuiz[currentQuesCount - 1].correctOpt == rb4.Content.ToString())
                            correctAns++;

                        if (currentQuesCount == 3)
                        {
                            spTest.Visibility = Visibility.Collapsed;
                            spResult.Visibility = Visibility.Visible;
                            tbCorrectAns.Text = correctAns.ToString();
                            if (correctAns <= 2)
                            {
                                spRecommend.Visibility = Visibility.Visible;
                            }
                        }
                        if (currentQuesCount <= 2)
                        {
                            classQuiz objQuiz = obcQuiz[currentQuesCount];
                            tbQues.Text = objQuiz.q_ques;
                            rb1.Content = objQuiz.Opt1;
                            rb2.Content = objQuiz.Opt2;
                            rb3.Content = objQuiz.Opt3;
                            rb4.Content = objQuiz.Opt4;
                            currentQuesCount++;
                        }
                    }
                    rb1.IsChecked = false;
                    rb2.IsChecked = false;
                    rb3.IsChecked = false;
                    rb4.IsChecked = false;
                }
                catch (Exception)
                {
                }
            }
        }

        private void btChangeInstructor_Click(object sender, RoutedEventArgs e)
        {
            spTest.Visibility = Visibility.Collapsed;
            spResult.Visibility = Visibility.Visible;
            gdTestQues.Visibility = Visibility.Collapsed;
            if (correctAns == 1)
            {
                string html = @"<iframe width=""100%"" height=""420""  src=""http://www.youtube.com/embed/" + UtilityData.objCurrentCourse.ytb_link2 + @"?rel=0"" ></iframe>";

                this.webCourse.NavigateToString(html);
            }
            else
            {
                string html = @"<iframe width=""100%"" height=""420""  src=""http://www.youtube.com/embed/" + UtilityData.objCurrentCourse.ytb_link3 + @"?rel=0"" ></iframe>";

                this.webCourse.NavigateToString(html);
            }
        }
    }
}
