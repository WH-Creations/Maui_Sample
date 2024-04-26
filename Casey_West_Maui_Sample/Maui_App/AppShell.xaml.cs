using Maui_App.Views;

namespace Maui_App
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("//inspection", typeof(InspectionListPage));
            Routing.RegisterRoute("inspection/detail", typeof(InspectionDetailPage));
            Routing.RegisterRoute("inspection/add", typeof(InspectionEditPage));
            Routing.RegisterRoute("inspection/edit", typeof(InspectionEditPage));
        }
    }
}
