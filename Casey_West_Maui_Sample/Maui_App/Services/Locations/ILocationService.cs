using Maui_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui_App.Services.Locations
{
    internal interface ILocationService
    {
        Task<List<LocationModel>> GetLocations();
    }
}
