﻿using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Maui_App.Messages;
using Maui_App.Models;
using Maui_App.Services.Common;
using Maui_App.Services.Inspections;
using Maui_App.ViewModels.Location;

namespace Maui_App.ViewModels.Inspection
{
    public partial class InspectionListViewModel : ViewModelBase, IRecipient<InspectionUpdatedMessage>, IRecipient<InspectionDeletedMessage>
    {
        private readonly IInspectionService _inspectionService;
        private readonly INavigationService _navigationService;

        [ObservableProperty] 
        private ObservableCollection<InspectionListItemViewModel> _inspections = [];

        [ObservableProperty] 
        private InspectionListItemViewModel? _selectedInspection;

        [RelayCommand]
        private async Task NavigateToSelectedDetail()
        {
            if (SelectedInspection == null) {  return; }
            var detailModel = MapToInspectionModel(SelectedInspection);
            await _navigationService.GoToEditInspection(detailModel);

            SelectedInspection = null;
        }

        [RelayCommand]
        private async Task NavigateToAddInspection()
            => await _navigationService.GoToAddInspection();

        public InspectionListViewModel(
            IInspectionService inspectionService,
            INavigationService navigationService)
        {
            _inspectionService = inspectionService;
            _navigationService = navigationService;

            WeakReferenceMessenger.Default.Register<InspectionUpdatedMessage>(this);
            WeakReferenceMessenger.Default.Register<InspectionDeletedMessage>(this);
        }

        public override async Task LoadAsync()
        {
            if (Inspections.Count == 0)
            {
                await Loading(GetInspections);
            }
        }

        private async Task GetInspections()
        {
            List<InspectionModel> inspections = await _inspectionService.GetInspections();
            List<InspectionListItemViewModel> listItems = new();
            foreach (var @inspection in inspections)
            {
                listItems.Add(MapInspectionModelToInspectionListItemViewModel(@inspection));
            }

            Inspections.Clear();
            Inspections = listItems.ToObservableCollection();
        }

        #region Mappings
        private InspectionModel MapToInspectionModel(InspectionListItemViewModel inspectionListItemViewModel)
        {
            return new InspectionModel
            {
                Id = inspectionListItemViewModel.Id,
                Name = inspectionListItemViewModel.Name ?? string.Empty,
                ImageUrl = inspectionListItemViewModel.ImageUrl,
                Status = (InspectionStatusEnum)inspectionListItemViewModel.InspectionStatus,
                Date = inspectionListItemViewModel.Date,
                Description = inspectionListItemViewModel.Description ?? string.Empty,
                Location = new LocationModel
                {
                    Id = inspectionListItemViewModel.Location!.Id,
                    LocationType = inspectionListItemViewModel.Location.LocationType,
                    Name = inspectionListItemViewModel.Location.Name
                }
            };
        }

        private InspectionListItemViewModel MapInspectionModelToInspectionListItemViewModel(InspectionModel @inspection)
        {
            var location = new LocationViewModel
            {
                Id = @inspection.Location.Id,
                LocationType = @inspection.Location.LocationType,
                Name = @inspection.Location.Name,
            };

            return new InspectionListItemViewModel(
                @inspection.Id,
                @inspection.Name,
                @inspection.Date,
                inspection.Description,
                (InspectionStatusEnum)@inspection.Status,
                @inspection.ImageUrl,
                location);
        }

        #endregion

        #region Messages
        public async void Receive(InspectionUpdatedMessage message)
        {
            Inspections.Clear();
            await GetInspections();
        }

        public void Receive(InspectionDeletedMessage message)
        {
            var deletedInspection = Inspections.FirstOrDefault(e => e.Id == message.InspectionId);
            if (deletedInspection != null)
            {
                Inspections.Remove(deletedInspection);
            }
        }
        #endregion
    }
}

