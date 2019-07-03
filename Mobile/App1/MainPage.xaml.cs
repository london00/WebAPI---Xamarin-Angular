using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using UdemyDotNetCoreAngular.DTO;
using Xamarin.Forms;
using Json = Newtonsoft.Json.JsonConvert;
namespace UdemyCourse.Mobile
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            GetMakes();
        }

        public async void GetMakes()
        {
            var urlBase = "http://localhost:9999";
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(urlBase + "/api/Makes/GetMakes");
            var makes = Json.DeserializeObject<List<MakeDTO>>(response);
            lvMakes.ItemsSource = makes.Select(x => x.Name);
        }
    }
}
