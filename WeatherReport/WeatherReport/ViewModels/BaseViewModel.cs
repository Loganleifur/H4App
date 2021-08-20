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

        string cityName;
        public string CityName
        {
            get { return cityName; }
            set { SetProperty(ref cityName, value); }
        }

        string future1;
        public string Future1
        {
            get { return future1; }
            set { SetProperty(ref future1, value); }
        }

        string futureTemp1;
        public string FutureTemp1
        {
            get { return futureTemp1; }
            set { SetProperty(ref futureTemp1, value); }
        }

        string future2;
        public string Future2
        {
            get { return future2; }
            set { SetProperty(ref future2, value); }
        }

        string futureTemp2;
        public string FutureTemp2
        {
            get { return futureTemp2; }
            set { SetProperty(ref futureTemp2, value); }
        }

        string future3;
        public string Future3
        {
            get { return future3; }
            set { SetProperty(ref future3, value); }
        }

        string futureTemp3;
        public string FutureTemp3
        {
            get { return futureTemp3; }
            set { SetProperty(ref futureTemp3, value); }
        }

        string future4;
        public string Future4
        {
            get { return future4; }
            set { SetProperty(ref future4, value); }
        }

        string futureTemp4;
        public string FutureTemp4
        {
            get { return futureTemp4; }
            set { SetProperty(ref futureTemp4, value); }
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
