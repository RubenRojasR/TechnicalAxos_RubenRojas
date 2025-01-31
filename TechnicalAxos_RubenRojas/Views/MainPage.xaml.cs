using TechnicalAxos_RubenRojas.ViewModels;

namespace TechnicalAxos_RubenRojas
{
    public partial class MainPage : ContentPage
    {

        public MainPage(MainPageViewModel mainPageViewModel)
        {
            InitializeComponent();
            BindingContext = mainPageViewModel;
        }
    }

}
