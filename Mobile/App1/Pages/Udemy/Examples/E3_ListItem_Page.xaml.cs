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
    public partial class E3_ListItem_Page : ContentPage
    {
        public ObservableCollection<People> lstPeople { get; set; }
        public E3_ListItem_Page()
        {
            InitializeComponent();
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
            var selectedPerson = (People)e.SelectedItem;
            selectedPerson.Name += 2;
            lstPeople.Add(selectedPerson);
        }
    }

    public class People {
        public string Name { get; set; }
        public string Status { get; set; }
        public string PhotoPath { get; set; }
    }
}