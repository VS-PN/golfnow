using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using System.Net.Http.Headers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Golfnow.Entities;
using Golfnow.ViewModels;

namespace Golfnow
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TeeTimesList : ContentPage
    {
        public TeeTimesList()
        {
            InitializeComponent();

            // Test data
            var entries = new ObservableCollection<TeeTimeEntryViewModel>
            {
                new TeeTimeEntryViewModel(new TeeTime(new DateTime(2021, 04, 25, 12, 30, 00), new Course(18))),
                new TeeTimeEntryViewModel(new TeeTime(new DateTime(2021, 03, 13, 14, 00, 00), new Course(9, "Rehhütte"))),
                new TeeTimeEntryViewModel(new TeeTime(DateTime.Now.Add(new TimeSpan(2, 0, 0, 0)), new Course(18)))
            };

            var futureEntries = entries.Where(t => t.IsPast == false);
            FutureTeeTimes.ItemsSource = futureEntries;
            FutureTeeTimesWrapper.HeightRequest = futureEntries.Count() * 60;
            
            var pastEntries = entries.Where(t => t.IsPast);
            PastTeeTimes.ItemsSource = pastEntries;
            PastTeeTimesWrapper.HeightRequest = pastEntries.Count() * 60;
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
