using System.Globalization;
using MoviesApp.Services;
using Prism;
using Prism.Ioc;
using MoviesApp.ViewModels;
using MoviesApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MoviesApp
{
    public partial class App
    {
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            SetLocale(new CultureInfo("en"));
            await NavigationService.NavigateAsync("NavigationPage/MoviesPage");
        }

        public void SetLocale(CultureInfo cultureInfo)
        {
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MoviesPage, MoviesPageViewModel>();
            containerRegistry.RegisterForNavigation<MovieDetailPage, MovieDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<SearchMoviesPage, SearchMoviesPageViewModel>();

            containerRegistry.Register<IMovieService, MovieService>();
        }
    }
}
