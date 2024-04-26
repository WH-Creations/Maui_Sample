using Maui_App.Models;

namespace Maui_App.Services.Common
{
    public class NavigationService : INavigationService
    {
        // Centralized route definitions
        private const string AddInspectionRoute = "inspection/add";
        private const string EditInspectionRoute = "inspection/edit";
        private const string InspectionListRoute = "//inspection";

        public Task GoToAddInspection()
            => SafeNavigateAsync(AddInspectionRoute);

        public async Task GoToEditInspection(InspectionModel detailModel)
        {
            try
            {
                var navigationParameter = new Dictionary<string, object>
                {
                    { "Inspection", detailModel }
                };

                await Shell.Current.GoToAsync(EditInspectionRoute, navigationParameter);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Navigation error: {ex.Message}");
            }
        }

        public Task GoToInspectionList()
            => SafeNavigateAsync(InspectionListRoute);

        public Task GoBack()
            => SafeNavigateAsync("..");

        /// <summary>
        /// Helper method to perform navigation with error handling.
        /// </summary>
        /// <param name="route">The route to navigate to.</param>
        /// <param name="parameters">Optional parameters for the navigation.</param>
        private async Task SafeNavigateAsync(string route, IDictionary<string, object>? parameters = null)
        {
            if (parameters == null)
            {
                // Initialize with an empty dictionary
                parameters = new Dictionary<string, object>();
            }

            try
            {
                await Shell.Current.GoToAsync(route, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Navigation error: {ex.Message}");
            }
        }
    }
}
