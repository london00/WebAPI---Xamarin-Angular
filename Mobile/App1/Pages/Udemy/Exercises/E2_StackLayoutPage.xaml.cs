using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UdemyCourse.Mobile.Pages.Udemy.Exercises
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class E2_StackLayoutPage : ContentPage
    {
        public E2_StackLayoutPage()
        {
            InitializeComponent();
            var gesture = new TapGestureRecognizer();
            gesture.Tapped += OnLabelClicked;
            gesture.NumberOfTapsRequired = 1;
            lblLike.GestureRecognizers.Add(gesture);
        }

        private void OnLabelClicked(object sender, EventArgs e)
        {
            DisplayAlert("Done!", "Thanks for give me a like!!", "Cancel");
        }
    }
}