using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UdemyCourse.Mobile.Pages.Udemy.Exercises
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class E5_ImageGaleryPage : ContentPage
    {
        [Bindable(BindableSupport.Yes)]
        public int ImageIndex { get; set; }
        private const string IMAGE_URL = "https://picsum.photos/420/320?image=";
        public E5_ImageGaleryPage()
        {
            InitializeComponent();
            ChangeImage();
        }

        private void ChangeImage()
        {
            try
            {
                lblIndexImage.Text = $"Image number: {ImageIndex} ";
                imgBackground.Source = new UriImageSource
                {
                    Uri = new Uri(IMAGE_URL + ImageIndex),
                    CachingEnabled = false
                };
            }
            catch (Exception e)
            {
                DisplayAlert("Error", e.Message, "Close");
            }
        }

        private void Button_Plus_Clicked(object sender, EventArgs e)
        {
            if (ImageIndex == 0)
            {
                btnMinus.IsEnabled = true;
            }

            ImageIndex++;
            ChangeImage();
        }

        private void Button_Minus_Clicked(object sender, EventArgs e)
        {
            if (ImageIndex >= 1)
            {
                ImageIndex--;
                ChangeImage();

                if (ImageIndex == 0)
                {
                    btnMinus.IsEnabled = false;
                }
            }
        }
    }
}