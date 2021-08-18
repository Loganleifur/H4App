using System;
using System.Collections.Generic;
using System.ComponentModel;
using WeatherReport.Models;
using WeatherReport.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherReport.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}