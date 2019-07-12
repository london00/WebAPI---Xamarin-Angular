using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using UdemyDotNetCoreAngular.DTO;
using Xamarin.Forms;
using Json = Newtonsoft.Json.JsonConvert;
namespace UdemyCourse.Mobile.Pages
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        const string urlBase = "http://localhost:9999";
        private HttpClient httpClient;

        private List<MakeDTO> makeDTOs = new List<MakeDTO>();

        public MainPage()
        {
            InitializeComponent();
            httpClient = new HttpClient();
        }

        public async void GetMakes()
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(urlBase + "/api/Makes/GetMakes");
            this.makeDTOs = Json.DeserializeObject<List<MakeDTO>>(response);
            lvMakes.ItemsSource = this.makeDTOs.Select(x => x.Name);
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            GetMakes();
        }

        private void LvMakes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var makeName = e.SelectedItem.ToString();
            var selectedMake = makeDTOs.FirstOrDefault(x => x.Name == makeName);
            lvModels.ItemsSource = selectedMake.Models.Select(x => x.Name);
        }

        private void LvModels_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var makeName = lvMakes.SelectedItem.ToString();
            var modelName = e.SelectedItem.ToString();
            var selectedMake = makeDTOs.FirstOrDefault(x => x.Name == makeName);
            var selectedModel = selectedMake.Models.FirstOrDefault(x => x.Name == modelName);
            var response = httpClient.GetStringAsync(urlBase + "/api/Features/GetFeaturesByModel?ModelId=" + selectedModel.Id).Result;
            var features = Json.DeserializeObject<List<KeyValuePairDTO>>(response);
            DisplayAlert($"Features for {modelName}", string.Join(", ", features.Select(x=> x.Name).ToList()), "Close");
        }
    }
}
