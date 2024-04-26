using Maui_App.Models;

namespace Maui_App.Services.Common
{
    internal interface INavigationService
    {
        Task GoToInspectionDetail(Guid selectedInspectionId);
        Task GoToAddInspection();
        Task GoToEditInspection(InspectionModel detailModel);
        Task GoToInspectionList();
        Task GoBack();
    }
}
