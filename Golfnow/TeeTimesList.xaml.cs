using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Golfnow.Entities;
using Golfnow.ViewModels;

namespace Golfnow
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TeeTimesList : ContentPage
    {
        public ObservableCollection<TeeTimeEntryViewModel> Items { get; set; }

        public TeeTimesList()
        {
            InitializeComponent();

            // Test data
            Items = new ObservableCollection<TeeTimeEntryViewModel>
            {
                new TeeTimeEntryViewModel(new TeeTime(DateTime.Now, new Course(18))),
                new TeeTimeEntryViewModel(new TeeTime(DateTime.Now, new Course(9, "Rehhütte")))
            };

            FutureTeeTimes.ItemsSource = Items;
            FutureTeeTimesWrapper.HeightRequest = Items.Count * 70;
            
            PastTeeTimes.ItemsSource = Items;
            PastTeeTimesWrapper.HeightRequest = Items.Count * 70;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
