using System;
using System.Collections.Generic;
using UdemyCourse.Mobile.Pages.Azure;
using UdemyCourse.Mobile.Pages.Udemy.Examples;
using UdemyCourse.Mobile.Pages.Udemy.Exercises;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UdemyCourse.Mobile.Pages.Udemy
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();
            var PagesList = new List<string>();
            PagesList.Add("Example 0 - Rest APP");
            PagesList.Add("Example 0 - Create Vehicle");
            PagesList.Add("Example 1");
            PagesList.Add("Example 2 - Embeded images");
            PagesList.Add("Excercise 1");
            PagesList.Add("Excercise 2");
            PagesList.Add("Excercise 3");
            PagesList.Add("Excercise 4");
            PagesList.Add("Excercise 5");
            PagesList.Add("Example 3 Bindable list item");
            PagesList.Add("Example 4 Custom list item");

            lstPages.ItemsSource = PagesList;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var selectedItem = lstPages.SelectedItem;

            switch (selectedItem.ToString())
            {
                case "Example 0 - Rest APP":
                    await Navigation.PushAsync(new MainPage());
                    break;
                case "Example 0 - Create Vehicle":
                    await Navigation.PushAsync(new VehiclePage());
                    break;
                case "Example 1":
                    await Navigation.PushAsync(new Exmple1Page());
                    break;
                case "Example 2 - Embeded images":
                    await Navigation.PushAsync(new E2_ImagesPage());
                    break;
                case "Excercise 1":
                    await Navigation.PushAsync(new E1_StackLayoutPage());
                    break;
                case "Excercise 2":
                    await Navigation.PushAsync(new E2_StackLayoutPage());
                    break;
                case "Excercise 3":
                    await Navigation.PushAsync(new E3_GridPage());
                    break;
                case "Excercise 4":
                    await Navigation.PushAsync(new E4_AbsoluteLayutPage());
                    break;
                case "Excercise 5":
                    await Navigation.PushAsync(new E5_ImageGaleryPage());
                    break;
                case "Example 3 Bindable list item":
                    await Navigation.PushAsync(new E3_ListItem_Page());
                    break;
                case "Example 4 Custom list item":
                    await Navigation.PushAsync(new E4_CustomListView_Page());
                    break;
                default:
                    break;
            }
        }
    }
}