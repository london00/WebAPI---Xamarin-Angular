using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UdemyCourse.Mobile.Pages.Udemy
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogInPage : ContentPage
    {
        const string urlBase = "https://udemyangularwebapisite.azurewebsites.net";
        private HttpClient httpClient;
        private double width;
        private double height;

        public LogInPage()
        {
            InitializeComponent();
            httpClient = new HttpClient();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var email = txtEmail.Text;
            var password = txtPassword.Text;
            if (string.IsNullOrWhiteSpace(email))
            {
                DisplayAlert("Login failed", "Email is required", "Ok");
            }
            else if (string.IsNullOrWhiteSpace(password))
            {
                DisplayAlert("Login failed", "Password is required", "Ok");
            }
            else
            {
                isRememberChecked.IsEnabled = txtPassword.IsEnabled = txtEmail.IsEnabled = btnLogIn.IsEnabled = false;
                LogInAsync();
            }
        }

        public async Task LogInAsync()
        {
            var credentials = new
            {
                Email = txtEmail.Text,
                Password = txtPassword.Text
            };

            var postCredentialRequest = await httpClient.PostAsync(urlBase + "/api/auth/Login", new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(credentials), Encoding.UTF8, "application/json"));
            if (postCredentialRequest.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var response = await postCredentialRequest.Content.ReadAsStringAsync();
                if (isRememberChecked.IsToggled)
                {
                    var token = Newtonsoft.Json.JsonConvert.DeserializeObject<Token>(response);
                    Application.Current.Properties["token"] = token;
                    //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "");
                    //httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                }
                Application.Current.MainPage = new NavigationPage(new MenuPage());
            }
            else if (postCredentialRequest.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                DisplayAlert("Login failed", "Email or password incorrect", "Ok");
                isRememberChecked.IsEnabled = txtPassword.IsEnabled = txtEmail.IsEnabled = btnLogIn.IsEnabled = true;
            }
        }

        private class Token
        {
            public string token { get; set; }
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (width != this.width || height != this.height)
            {
                this.width = width;
                this.height = height;
                if (width > height)
                {
                    outerStack.Orientation = StackOrientation.Horizontal;
                    innerStack.WidthRequest = (this.width / 3) * 2;
                }
                else
                {
                    outerStack.Orientation = StackOrientation.Vertical;
                    innerStack.MinimumWidthRequest = 0;
                }
            }
        }
    }
}