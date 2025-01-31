
using Microsoft.Maui.Storage;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechnicalAxos_RubenRojas.Models;
using TechnicalAxos_RubenRojas.Services;
using TechnicalAxos_RubenRojas.ViewModels;

namespace TechnicalAxos_RubenRojas.Tests
{
    public class MainPageViewModelTest
    {

        [Fact]
        public void ViewModel_Initialization_SetsDefaultValues()
        {
            // Arrange
            var mockServiceRequest = new Mock<IServiceRequest>();
            var mockPickerService = new Mock<IPickerService>();
            var viewModel = new MainPageViewModel(mockServiceRequest.Object, mockPickerService.Object);

            // Assert
            Assert.NotNull(viewModel.BundleId);
            Assert.Equal("https://random.dog/af70ad75-24af-4518-bf03-fec4a997004c.jpg", viewModel.ImageSource);
            Assert.NotNull(viewModel.Countries);
            Assert.Empty(viewModel.Countries);
        }

        [Fact]
        public void LoadCountriesCommand_PopulatesCountries()
        {
            // Arrange
            var mockServiceRequest = new Mock<IServiceRequest>();
            var mockPickerService = new Mock<IPickerService>();
            var fakeData = new List<CountryModel>{
                new CountryModel { Name = new CountryNameModel { Common = "Country1", Official = "Official1" } },
                new CountryModel { Name = new CountryNameModel { Common = "Country2", Official = "Official2" } }
            };

            mockServiceRequest
                .Setup(x => x.GetDataAsync<CountryModel>("https://restcountries.com/v3.1/all"))
                .ReturnsAsync(fakeData);

            var viewModel = new MainPageViewModel(mockServiceRequest.Object, mockPickerService.Object);

            // Act
            viewModel.LoadCountriesCommand.Execute(null);

            // Assert
            Assert.Equal(2, viewModel.Countries.Count);
            Assert.Equal("Country1", viewModel.Countries[0].Name.Common);
            Assert.Equal("Country2", viewModel.Countries[1].Name.Common);
        }
        [Fact]
        public void ChangeImageCommand_UpdatesImageSource()
        {
            // Arrange
            var mockServiceRequest = new Mock<IServiceRequest>();
            var mockPickerService = new Mock<IPickerService>();
            

            // Simula que el usuario selecciona una imagen.
            string fakePath = "/path/to/image.jpg";
            mockPickerService.Setup(fp => fp.PickAsync(It.IsAny<PickOptions>()))
        .ReturnsAsync(new FileResult(fakePath));

            var viewModel = new MainPageViewModel(mockServiceRequest.Object, mockPickerService.Object);
            
            // Act
            viewModel.ChangeImageCommand.Execute(null);

            // Assert
            Assert.Equal(fakePath, viewModel.ImageSource);
        }


    }


}