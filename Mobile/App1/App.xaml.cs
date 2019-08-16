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
            // TODO: Use localstorage or sqlite to store credentials.
            if (Properties.ContainsKey("token"))
            {
                MainPage = new NavigationPage(new MenuPage()) {
                    BarBackgroundColor = Color.Black,
                    BarTextColor = Color.White
                };
            }
            else
            {
                MainPage = new LogInPage();
            }
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
