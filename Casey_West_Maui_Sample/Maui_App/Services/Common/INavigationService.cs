﻿using Maui_App.Models;

namespace Maui_App.Services.Common
{
    public interface INavigationService
    {
        Task GoToAddInspection();
        Task GoToEditInspection(InspectionModel detailModel);
        Task GoToInspectionList();
        Task GoBack();
    }
}
