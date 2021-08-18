using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WeatherReport.Models;
using WeatherReport.Services;
using Xamarin.Forms;

namespace WeatherReport.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        string temperature;
        public string Temperature
        {
            get { return temperature; }
            set { SetProperty(ref temperature, value); }
        }

        string search;
        public string Search
        {
            get { return search; }
            set { SetProperty(ref search, value); }
        }

        string placeholder;
        public string Placeholder
        {
            get { return placeholder; }
            set { SetProperty(ref placeholder, value); }
        }

        string description;
        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }

        string image = string.Empty;
        public string Image
        {
            get { return image; }
            set { SetProperty(ref image, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
