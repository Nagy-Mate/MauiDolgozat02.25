using MauiDolgozat.Views;

namespace MauiDolgozat
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            Routing.RegisterRoute("MainPage", typeof(MainPage));
            InitializeComponent();
        }
    }
}
