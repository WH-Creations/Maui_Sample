using Maui_App.Models;
using Maui_App.Repositories.Inspections;

namespace Maui_App.Services.Inspections
{
    public class InspectionService : IInspectionService
    {
        private readonly IInspectionRepository _inspectionRepository;

        public InspectionService(IInspectionRepository inspectionRepository)
        {
            _inspectionRepository = inspectionRepository;
        }

        public Task<List<InspectionModel>> GetInspections()
            => _inspectionRepository.GetInspections();

        public Task<InspectionModel?> GetInspection(Guid id)
            => _inspectionRepository.GetInspection(id);

        public Task<bool> UpdateInspectionStatus(Guid id, InspectionStatusEnum status)
            => _inspectionRepository.UpdateStatus(id, status);

        public Task<bool> CreateInspection(InspectionModel model)
            => _inspectionRepository.CreateInspection(model);

        public Task<bool> EditInspection(InspectionModel model)
            => _inspectionRepository.EditInspection(model);

        public Task<bool> DeleteInspection(Guid id)
            => _inspectionRepository.DeleteInspection(id);
    }
}
