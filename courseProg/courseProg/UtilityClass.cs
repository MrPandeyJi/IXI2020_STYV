using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace courseProg
{
    public class UtilityClass
    {
        public static async void MessageDialog(string text, string title)
        {
            ContentDialog cntMessage = new ContentDialog
            {
                Title = title,
                Content = text,
                PrimaryButtonText = "Close"
            };
            await cntMessage.ShowAsync();
        }

    }
}
