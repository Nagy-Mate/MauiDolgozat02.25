using MauiDolgozat.Views;

namespace MauiDolgozat
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            Routing.RegisterRoute("AddPage", typeof(AddPage));
            Routing.RegisterRoute("DeletePage", typeof(DeletePage));
            Routing.RegisterRoute("UpdatePage", typeof(UpdatePage));
            Routing.RegisterRoute("ReportPage", typeof(ReportPage));

            InitializeComponent();
        }
    }
}
