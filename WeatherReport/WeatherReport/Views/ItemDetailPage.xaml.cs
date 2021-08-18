using System.ComponentModel;
using WeatherReport.ViewModels;
using Xamarin.Forms;

namespace WeatherReport.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}