using Maui_App.Models;

namespace Maui_App.Messages
{
    public class InspectionStatusChangedMessage
    {
        public Guid InspectionId { get; }
        public InspectionStatusEnum Status { get; }

        public InspectionStatusChangedMessage(
            Guid id,
            InspectionStatusEnum status)
        {
            InspectionId = id;
            Status = status;
        }
    }
}
