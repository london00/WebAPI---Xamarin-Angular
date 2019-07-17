using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}