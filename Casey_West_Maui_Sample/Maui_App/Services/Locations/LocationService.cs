using Maui_App.Models;
using Maui_App.Repositories.Locations;

namespace Maui_App.Services.Locations
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;

        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public Task<List<LocationModel>> GetLocations()
            => _locationRepository.GetLocations();
    }
}
