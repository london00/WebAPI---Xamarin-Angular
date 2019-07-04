using UdemyCourse.Mobile.Pages;
using UdemyCourse.Mobile.Pages.Udemy;
using Xamarin.Forms;

namespace UdemyCourse.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Exmple1Page();
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
