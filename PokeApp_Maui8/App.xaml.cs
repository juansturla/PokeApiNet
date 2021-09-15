using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;
using PokeApp_Maui8.Services;
using Application = Microsoft.Maui.Controls.Application;

namespace PokeApp_Maui8
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Microsoft.Maui.Controls.DependencyService.Register<PokeDataStore>();
            MainPage = new AppShell();
        }
    }
}
