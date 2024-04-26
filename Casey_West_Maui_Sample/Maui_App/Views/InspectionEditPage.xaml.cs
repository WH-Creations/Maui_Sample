using Maui_App.ViewModels.Inspection;

namespace Maui_App.Views;

public partial class InspectionEditPage : BaseContentPage
{
    public InspectionEditPage(InspectionEditViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}