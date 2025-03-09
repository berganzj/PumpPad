using Microsoft.Maui.Controls;

namespace PumpPad
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new WelcomePage());
        }
    }
}
