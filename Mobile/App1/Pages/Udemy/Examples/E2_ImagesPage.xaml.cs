﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UdemyCourse.Mobile.Pages.Udemy.Examples
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class E2_ImagesPage : ContentPage
    {
        public E2_ImagesPage()
        {
            InitializeComponent();
            imgExample.Source = ImageSource.FromResource("UdemyCourse.Mobile.Images.lake.jpg");
        }
    }
}