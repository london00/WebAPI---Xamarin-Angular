using UdemyCourse.Mobile.Pages;
using UdemyCourse.Mobile.Pages.Udemy;
using UdemyCourse.Mobile.Pages.Udemy.Exercises;
using Xamarin.Forms;

namespace UdemyCourse.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new E1_StackLayoutPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
