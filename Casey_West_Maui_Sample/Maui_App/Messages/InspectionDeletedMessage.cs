namespace Maui_App.Messages
{
    public class InspectionDeletedMessage
    {
        public Guid InspectionId { get; }

        public InspectionDeletedMessage(Guid id)
        {
            InspectionId = id;
        }
    }
}
