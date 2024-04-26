using Maui_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui_App.Repositories.Locations
{
    public interface ILocationRepository
    {
        Task<List<LocationModel>> GetLocations();
    }
}
