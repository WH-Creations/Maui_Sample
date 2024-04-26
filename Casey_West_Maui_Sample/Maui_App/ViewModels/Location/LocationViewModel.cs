using CommunityToolkit.Mvvm.ComponentModel;
using Maui_App.Models;

namespace Maui_App.ViewModels.Location
{
    public partial class LocationViewModel : ObservableObject
    {
        [ObservableProperty]
        private Guid _id;

        [ObservableProperty]
        private LocationTypeEnum _locationType;

        [ObservableProperty]
        private string _name = default!;

        public bool Equals(LocationViewModel? other)
        {
            if (other == null) return false;
            return Id.Equals(other.Id);
        }
    }
}
