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
    public sealed partial class pgSpecCourse : Page
    {
        ObservableCollection<classCourse> obcCourse = new ObservableCollection<classCourse>();
        public pgSpecCourse()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            obcCourse.Clear();
            dbHelperClass.getBeginQuest(obcCourse);
            gdvCourse.ItemsSource = obcCourse;
            switch (UtilityData.currentCourse)
            {
                case 1:
                    tbHeader.Text = "Beginner Course";
                    break;
                case 2:
                    tbHeader.Text = "Intermidiate Course";
                    break;
                case 3:
                    tbHeader.Text = "Advanced Course";
                    break;
                default:
                    break;
            }
        }

        private void gdvCourse_ItemClick(object sender, ItemClickEventArgs e)
        {
            UtilityData.objCurrentCourse = (classCourse)e.ClickedItem;
            this.Frame.Navigate(typeof(pgPartCourse));
        }
    }
}
