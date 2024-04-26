using Maui_App.Models;

namespace Maui_App.Services.Inspections
{
    public interface IInspectionService
    {
        Task<List<InspectionModel>> GetInspections();
        Task<InspectionModel?> GetInspection(Guid id);
        Task<bool> UpdateInspectionStatus(Guid id, InspectionStatusEnum status);
        Task<bool> CreateInspection(InspectionModel model);
        Task<bool> EditInspection(InspectionModel model);
        Task<bool> DeleteInspection(Guid id);
    }
}
