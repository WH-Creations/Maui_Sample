using Maui_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui_App.Repositories.Inspections
{
    public interface IInspectionRepository
    {
        Task<List<InspectionModel>> GetInspections();
        Task<InspectionModel?> GetInspection(Guid id);
        Task<bool> UpdateStatus(Guid id, InspectionStatusEnum status);
        Task<bool> CreateInspection(InspectionModel model);
        Task<bool> EditInspection(InspectionModel model);
        Task<bool> DeleteInspection(Guid id);
    }
}
