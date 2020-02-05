using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace courseProg
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ObservableCollection<dbClasses> obcUsers = new ObservableCollection<dbClasses>();
        public MainPage()
        {
            this.InitializeComponent();
            createDatabase();
        }

        private void populatedList()
        {

        }
        string dbname = "prepdb.db";
        public async void createDatabase()
        {
            StorageFile dbFile = null;


            try
            {
                dbFile = await ApplicationData.Current.LocalFolder.GetFileAsync(dbname);
            }

            catch (Exception ex)
            {

                //string videoID = "GhQdlIFylQ8";
                //string html = @"<iframe  src=""http://www.youtube.com/embed/" + videoID + @"?rel=0"" ></iframe>";

                //this.wbVIew.NavigateToString(html);
                try
                {

                    using (var conn = new SQLiteConnection(dbname))
                    {
                        using (var statement = conn.Prepare(@"create table if not exists users (
                                                    user_id INTEGER PRIMARY KEY AUTOINCREMENT,
                                                    first_name varchar(10),
                                                    last_name varchar(10),
                                                    email_id varchar(10),
                                                    progress int
                                                    );"))
                        {
                            statement.Step();
                        }
                        using (var statement = conn.Prepare(@"create table if not exists quiz (
                                                    q_id INTEGER PRIMARY KEY AUTOINCREMENT,
                                                    q_name varchar(200),
                                                    q_topic varchar(10),
                                                    q_level varchar(10),
                                                    correct_opt varchar(10),
                                                    opt1 varchar(50),
                                                    opt2 varchar(50),
                                                    opt3 varchar(10),
                                                    opt4 varchar(50),
                                                    c_id int
                                                    );"))
                        {
                            statement.Step();
                        }
                        using (var statement = conn.Prepare(@"create table if not exists course (
                                                    c_id INTEGER PRIMARY KEY AUTOINCREMENT,
                                                    c_name varchar(200),
                                                    c_topic varchar(10),
                                                    c_level varchar(10),
                                                    ytb_link1 varchar(10),
                                                    ytb_link2 varchar(50),
                                                    ytb_link3 varchar(50),
                                                    c_exam varchar(50),
                                                    c_faq1 varchar(50),
                                                    c_faq2 varchar(50),
                                                    c_faq3 varchar(50)
                                                    );"))
                        {
                            statement.Step();
                        }
                        using (var statement = conn.Prepare(@"create table if not exists topic (
                                                    t_id INTEGER PRIMARY KEY AUTOINCREMENT,
                                                    t_name varchar(10)
                                                    );"))
                        {
                            statement.Step();
                        }
                        using (var statement = conn.Prepare(@"create table if not exists level (
                                                    l_id INTEGER PRIMARY KEY AUTOINCREMENT,
                                                    l_name varchar(10)
                                                    );"))
                        {
                            statement.Step();
                        }
                    }
                    dbHelperClass.addLevelsdb(new classLevel { l_name = "Beginner" });
                    dbHelperClass.addLevelsdb(new classLevel { l_name = "Intermediate" });
                    dbHelperClass.addLevelsdb(new classLevel { l_name = "Advanced" });
                    dbHelperClass.addTopicdb(new classTopic { t_name = "C++" });
                    dbHelperClass.addTopicdb(new classTopic { t_name = "C#" });
                    dbHelperClass.addTopicdb(new classTopic { t_name = "SQL" });
                }
                catch (Exception)
                {
                    await new MessageDialog("Error", "Error").ShowAsync();
                }
            }
        }

        private void btAddUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dbClasses obj = new dbClasses
                {
                    first_name = txbFirstName.Text,
                    last_name = txbSecondName.Text,
                    email_id = txbEmailid.Text
                };
                dbHelperClass.addUsertoDB(obj);
                UtilityClass.MessageDialog("Let's get started", string.Format("Welcome {0}", obj.first_name));
                UtilityData.objCurrentUser = obj;
                this.Frame.Navigate(typeof(pgCourses));
            }
            catch (Exception)
            {

            }
        }

        private void btSkip_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(pgCourses));
        }

        private void txbFirstName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btGoBack_Click(object sender, RoutedEventArgs e)
        {
            spAlreadyUser.Visibility = Visibility.Collapsed;
            spWelcome.Visibility = Visibility.Visible;
        }

        private void hlpAlreadyCreated_Click(object sender, RoutedEventArgs e)
        {
            obcUsers.Clear();
            dbHelperClass.getUsers(obcUsers);
            lvUsers.ItemsSource = obcUsers;
            spAlreadyUser.Visibility = Visibility.Visible;
            spWelcome.Visibility = Visibility.Collapsed;
        }

        private void lvUsers_ItemClick(object sender, ItemClickEventArgs e)
        {
            UtilityData.objCurrentUser = (dbClasses)e.ClickedItem;
            this.Frame.Navigate(typeof(pgCourses));
        }
    }
}
