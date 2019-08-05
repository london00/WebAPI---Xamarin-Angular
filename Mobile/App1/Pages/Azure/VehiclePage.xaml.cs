using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using UdemyDotNetCoreAngular.DTO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Json = Newtonsoft.Json.JsonConvert;

namespace UdemyCourse.Mobile.Pages.Azure
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VehiclePage : ContentPage
    {
        const string urlBase = "https://udemyangularwebapisite.azurewebsites.net";
        private HttpClient httpClient;
        private List<MakeDTO> makeDTOs;
        private Save_VehicleDTO save_VehicleDTO;
        public VehiclePage()
        {
            InitializeComponent();
            httpClient = new HttpClient();
            save_VehicleDTO = new Save_VehicleDTO();
            GetMakes();
        }

        public async void GetMakes()
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(urlBase + "/api/Makes/GetMakes");
            this.makeDTOs = Json.DeserializeObject<List<MakeDTO>>(response);
            pickerMakes.ItemsSource = this.makeDTOs.Select(x => x.Name).ToList();
        }

        private void pickerMakes_SelectedIndexChanged(object sender, EventArgs e)
        {
            var makeName = ((Picker)sender).SelectedItem.ToString();
            var selectedMake = makeDTOs.FirstOrDefault(x => x.Name == makeName);
            pickerModels.ItemsSource = selectedMake.Models.Select(x => x.Name).ToList();
        }

        private void pickerModels_SelectedIndexChanged(object sender, EventArgs e)
        {
            var makeName = pickerMakes.SelectedItem.ToString();
            var modelName = ((Picker)sender).SelectedItem.ToString();
            var selectedMake = makeDTOs.FirstOrDefault(x => x.Name == makeName);

            var selectedModel = selectedMake.Models.FirstOrDefault(x => x.Name == modelName);
            save_VehicleDTO.ModelId = selectedModel.Id;

            var response = httpClient.GetStringAsync(urlBase + "/api/Features/GetFeaturesByModel?ModelId=" + selectedModel.Id).Result;
            var features = Json.DeserializeObject<List<KeyValuePairDTO>>(response);
            stackFeatures.Children.Clear();

            foreach (var feature in features)
            {
                var radioStack = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal
                };

                var label = new Label
                {
                    Text = feature.Name
                };
                radioStack.Children.Add(label);

                var switchButton = new Switch();
                switchButton.Toggled += (_sender, _event) =>
                {
                    var _switch = (Switch)_sender;
                    var currentFeature = save_VehicleDTO.VehicleFeatures.FirstOrDefault(x => x.FeatureId == feature.Id);

                    if (_switch.IsToggled && currentFeature == null)
                    {
                        save_VehicleDTO.VehicleFeatures.Add(new VehicleFeatureDTO { FeatureId = feature.Id });
                    }
                    else if (!_switch.IsToggled && currentFeature != null)
                    {
                        save_VehicleDTO.VehicleFeatures.Remove(currentFeature);
                    }
                };
                radioStack.Children.Add(switchButton);

                stackFeatures.Children.Add(radioStack);
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}