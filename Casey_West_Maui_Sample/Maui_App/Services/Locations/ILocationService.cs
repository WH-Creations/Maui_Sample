using Maui_App.Models;

namespace Maui_App.Services.Locations
{
    public interface ILocationService
    {
        Task<List<LocationModel>> GetLocations();
    }
}
