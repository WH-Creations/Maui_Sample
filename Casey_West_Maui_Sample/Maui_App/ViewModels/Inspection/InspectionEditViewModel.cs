using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Maui_App.Messages;
using Maui_App.Models;
using Maui_App.Services.Common;
using Maui_App.Services.Inspections;
using Maui_App.Services.Locations;
using Maui_App.ViewModels.Location;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Maui_App.ViewModels.Inspection
{
    public partial class InspectionEditViewModel : ViewModelBase, IQueryAttributable
    {
        private readonly IInspectionService _inspectionService;
        private readonly ILocationService _locationService;
        private readonly INavigationService _navigationService;
        private readonly IDialogService _dialogService;

        public InspectionModel? inspectionDetail;

        #region Observable Properties
        [ObservableProperty]
        private Guid _id;

        [ObservableProperty]
        [Required]
        [MaxLength(50)]
        [NotifyDataErrorInfo]
        private string _name = string.Empty;

        [ObservableProperty]
        private string? _imageUrl = null;

        [ObservableProperty]
        [Required]
        [NotifyDataErrorInfo]
        private InspectionStatusEnum _inspectionStatus;

        [ObservableProperty]
        [Required]
        [NotifyDataErrorInfo]
        private DateTime? _date = DateTime.Now;

        [ObservableProperty]
        [MaxLength(250)]
        [NotifyDataErrorInfo]
        private string _description = string.Empty;

        [ObservableProperty]
        [Required]
        [NotifyDataErrorInfo]
        private LocationViewModel? _location;

        [ObservableProperty]
        private DateTime _minDate = DateTime.Now;

        #endregion

        public List<InspectionStatusEnum> StatusList { get; set; } =
            Enum.GetValues(typeof(InspectionStatusEnum)).Cast<InspectionStatusEnum>().ToList();

        [ObservableProperty]
        public ObservableCollection<ValidationResult> _errors = [];
        public ObservableCollection<LocationViewModel> Locations { get; set; } = [];

        #region Relay Commands

        [RelayCommand(CanExecute = nameof(CanSubmitInspection))]
        private async Task Submit()
        {
            ValidateAllProperties();
            if (Errors.Any())
            {
                return;
            }

            InspectionModel model = MapDataToInspectionModel();

            bool result = false;
            if (Id == Guid.Empty)
            {
                result = await _inspectionService.CreateInspection(model);
            }
            else
            {
                result = await _inspectionService.EditInspection(model);
            }

            MainThread.BeginInvokeOnMainThread(async () =>
            {
                if (result)
                {
                    WeakReferenceMessenger.Default.Send(new InspectionUpdatedMessage());
                    await _dialogService.Notify("Success", "The inspection has been saved.");
                    await _navigationService.GoBack();
                }
                else
                {
                    await _dialogService.Notify("Failed", "Saving the inspection failed.");
                }
            });
        }

        [RelayCommand(CanExecute = nameof(CanDeleteInspection))]
        public async Task DeleteInspection()
        {
            if (await _dialogService.Ask("Delete Inspection", "Are you sure you want to delete this inspection?"))
            {
                if (await _inspectionService.DeleteInspection(Id))
                {
                    WeakReferenceMessenger.Default.Send(new InspectionDeletedMessage(Id));
                    await _navigationService.GoBack();
                }
            }
        }
        #endregion

        private bool CanSubmitInspection() => !HasErrors;
        private bool CanDeleteInspection() => Id != Guid.Empty;

        public InspectionEditViewModel(
            IInspectionService inspectionService,
            ILocationService locationService,
            INavigationService navigationService,
            IDialogService dialogService)
        {
            _inspectionService = inspectionService;
            _locationService = locationService;
            _navigationService = navigationService;
            _dialogService = dialogService;

            ErrorsChanged += AddInspectionViewModel_ErrorsChanged;
        }

        public override async Task LoadAsync()
        {
            await Loading(
                 async () =>
                 {
                     var locations = await _locationService.GetLocations();
                     MainThread.BeginInvokeOnMainThread(() => MapLocations(locations));

                     if (inspectionDetail == null && Id != Guid.Empty)
                     {
                         inspectionDetail = await _inspectionService.GetInspection(Id);
                     }

                     MainThread.BeginInvokeOnMainThread(() =>
                     {
                         MapInspection(inspectionDetail);
                         DeleteInspectionCommand.NotifyCanExecuteChanged();
                         ValidateAllProperties();
                     });
                 });
        }

        private void AddInspectionViewModel_ErrorsChanged(object? sender, DataErrorsChangedEventArgs e)
        {
            Errors.Clear();
            GetErrors().ToList().ForEach(Errors.Add);
            SubmitCommand.NotifyCanExecuteChanged();
        }

        #region Mappings
        private void MapLocations(List<LocationModel> locations)
        {
            foreach (var location in locations)
            {
                Locations.Add(new LocationViewModel
                {
                    Id = location.Id,
                    LocationType = location.LocationType,
                    Name = location.Name
                });
            }
        }

        private void MapInspection(InspectionModel? model)
        {
            if (model is not null)
            {
                Id = model.Id;
                Name = model.Name;
                ImageUrl = model.ImageUrl;
                InspectionStatus = (InspectionStatusEnum)model.Status;
                Date = model.Date;
                Description = model.Description ?? string.Empty;
                Location = Locations.FirstOrDefault(c => c.Id == model.Location.Id && c.Name == model.Location.Name);
            }
        }

        private InspectionModel MapDataToInspectionModel()
        {
            return new InspectionModel
            {
                Id = Id,
                Name = Name ?? string.Empty,
                ImageUrl = ImageUrl,
                Status = (InspectionStatusEnum)InspectionStatus,
                Date = Date!.Value,
                Description = Description ?? string.Empty,
                Location = new LocationModel
                {
                    Id = Location!.Id,
                    LocationType = Location.LocationType,
                    Name = Location.Name
                }
            };
        }
        #endregion

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.Count > 0)
            {
                inspectionDetail = query["Inspection"] as InspectionModel;
            }
        }
    }

}
