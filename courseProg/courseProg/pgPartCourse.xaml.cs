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
    public sealed partial class pgPartCourse : Page
    {
        public pgPartCourse()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
            string html = @"<iframe width=""100%"" height=""420""  src=""http://www.youtube.com/embed/" + UtilityData.objCurrentCourse.c_desc + @"?rel=0"" ></iframe>";

            this.webCourse.NavigateToString(html);
            tbHeader.Text = UtilityData.objCurrentCourse.c_name;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //string videoID = "GhQdlIFylQ8";

            //this.webCourse.NavigateToString(html);
        }
    }
}
