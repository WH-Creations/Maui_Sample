using Android.Util;
using Maui_App.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Maui_App.Repositories.Locations
{
    internal class LocationRepository : ILocationRepository
    {
        private readonly HttpClient _httpClient;

        // Constructor that accepts an IHttpClientFactory and initializes the _httpClient.
        public LocationRepository(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("MauiAppApiClient");
        }

        // Asynchronous method to retrieve all locations from the API.
        public async Task<List<LocationModel>> GetLocations()
        {
            try
            {
                // Attempts to retrieve locations from the API using the GET method. Deserializes JSON response to a list of LocationModel.
                List<LocationModel>? locations = await _httpClient.GetFromJsonAsync<List<LocationModel>>(
                    "locations",
                    new JsonSerializerOptions(JsonSerializerDefaults.Web));

                // Return the list of locations or a new empty list if the result is null.
                return locations ?? [];
            }
            catch (HttpRequestException ex)
            {
                Debug.WriteLine($"HTTP request failed in GetLocations(): {ex.Message}");
                return [];
            }
            catch (JsonException ex)
            {
                Debug.WriteLine($"JSON parsing failed in GetLocations(): {ex.Message}");
                return [];
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An unexpected error occurred in GetLocations(): {ex.Message}");
                throw;
            }
        }
    }
}
