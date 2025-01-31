using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TechnicalAxos_RubenRojas.Models;
using TechnicalAxos_RubenRojas.Services;

namespace TechnicalAxos_RubenRojas.ViewModels
{
    public class MainPageViewModel : BindableObject
    {
        private string _bundleId;
        private string _imageSource;
        private ObservableCollection<CountryModel> _countries;
        private readonly IServiceRequest _serviceRequest;

        public string BundleId
        {
            get => _bundleId;
            set { _bundleId = value; OnPropertyChanged(); }
        }

        public string ImageSource
        {
            get => _imageSource;
            set { _imageSource = value; OnPropertyChanged(); }
        }

        public ObservableCollection<CountryModel> Countries
        {
            get => _countries;
            set { _countries = value; OnPropertyChanged(); }
        }

        public ICommand ChangeImageCommand { get; }
        public ICommand LoadCountriesCommand { get; }

        public MainPageViewModel(IServiceRequest serviceRequest)
        {
            _serviceRequest = serviceRequest;
            BundleId = AppInfo.PackageName;
            ImageSource = "https://random.dog/af70ad75-24af-4518-bf03-fec4a997004c.jpg";
            Countries = new ObservableCollection<CountryModel>();
            ChangeImageCommand = new Command(SelectImage);
            LoadCountriesCommand = new Command(async () => await LoadCountries());
            LoadCountriesCommand.Execute(null);
        }

        private async void SelectImage()
        {
            var result = await FilePicker.PickAsync(new PickOptions { FileTypes = FilePickerFileType.Images });
            if (result != null)
            {
                ImageSource = result.FullPath;
            }
        }

        private async Task LoadCountries()
        {
            string path = "https://restcountries.com/v3.1/all";
            var response = await _serviceRequest.GetDataAsync<CountryModel>(path);
            if (response.Count > 0)
            {
                Countries.Clear();

                foreach (var country in response)
                {
                    Countries.Add(country);
                }
            }
        }
    }
}
