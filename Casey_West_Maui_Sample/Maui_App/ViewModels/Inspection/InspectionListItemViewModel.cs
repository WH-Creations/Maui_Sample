using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Maui_App.Messages;
using Maui_App.Models;
using Maui_App.ViewModels.Location;

namespace Maui_App.ViewModels.Inspection
{
    public partial class InspectionListItemViewModel : ObservableObject, IRecipient<InspectionStatusChangedMessage>
    {
        [ObservableProperty]
        private Guid _id;

        [ObservableProperty]
        private string _name = default!;

        [ObservableProperty]
        private double _price;

        [ObservableProperty]
        private string? _imageUrl;

        [ObservableProperty]
        private InspectionStatusEnum _inspectionStatus;

        [ObservableProperty]
        private DateTime _date;

        [ObservableProperty]
        private LocationViewModel? _location;

        public InspectionListItemViewModel(
            Guid id,
            string name,
            DateTime date,
            InspectionStatusEnum status,
            string? imageUrl = null,
            LocationViewModel? location = null)
        {
            Id = id;
            ImageUrl = imageUrl;
            Name = name;
            Date = date;
            InspectionStatus = status;
            Location = location;

            WeakReferenceMessenger.Default.Register(this);
        }

        public void Receive(InspectionStatusChangedMessage message)
        {
            if (message.InspectionId == Id)
            {
                InspectionStatus = message.Status;
            }
        }
    }
}
