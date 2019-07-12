using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCourse.Mobile.Pages.Udemy.Examples;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UdemyCourse.Mobile.Pages.Udemy.Exercises
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class E1_StackLayoutPage : ContentPage
    {
        public E1_StackLayoutPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new E2_StackLayoutPage());
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new E4_AbsoluteLayutPage());
        }
    }
}