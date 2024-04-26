using Maui_App.ViewModels.Inspection;

namespace Maui_App.Views;

public partial class InspectionListPage : BaseContentPage
{
    public InspectionListPage(InspectionListViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}