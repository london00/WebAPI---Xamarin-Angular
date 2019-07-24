using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UdemyCourse.Mobile.Pages.Udemy.Examples
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class E4_CustomListView_Page : ContentPage
    {
        public ObservableCollection<People> lstPeople { get; set; }
        public E4_CustomListView_Page()
        {
            InitializeComponent();
            PopulateList();
        }

        public void PopulateList()
        {
            lstPeople = new ObservableCollection<People>();
            lstPeople.Add(new People
            {
                Name = "Geiser",
                Status = "Hi guys",
                PhotoPath = "https://picsum.photos/420/320?image=1"
            });
            lstPeople.Add(new People
            {
                Name = "John",
                Status = "It´s a nice day",
                PhotoPath = "https://picsum.photos/420/320?image=2"
            });
            lstPeople.Add(new People
            {
                Name = "Bob",
                Status = "Let´s work hard",
                PhotoPath = "https://picsum.photos/420/320?image=3"
            });

            lstNames.ItemsSource = lstPeople;
        }

        private void LstNames_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                // Use default vibration length
                Vibration.Vibrate();

                // Or use specified time
                var duration = TimeSpan.FromSeconds(1);
                Vibration.Vibrate(duration);
            }
            catch (FeatureNotSupportedException ex)
            {
                // Feature not supported on device
            }
            catch (Exception ex)
            {
                // Other error has occurred.
            }
        }

        private async void Switch_ToggledAsync(object sender, ToggledEventArgs e)
        {
            try
            {
                // Turn On
                await Flashlight.TurnOnAsync();
                Thread.Sleep(TimeSpan.FromSeconds(1));
                // Turn Off
                await Flashlight.TurnOffAsync();
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to turn on/off flashlight
            }
            finally
            {
                await Flashlight.TurnOffAsync();
            }
        }
    }
}