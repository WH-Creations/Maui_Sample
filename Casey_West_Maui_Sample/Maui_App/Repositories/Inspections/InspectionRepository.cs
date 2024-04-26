using Maui_App.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Maui_App.Repositories.Inspections
{
    internal class InspectionRepository : IInspectionRepository
    {
        private readonly HttpClient _httpClient;

        // Constructor injecting the IHttpClientFactory dependency.
        public InspectionRepository(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("MauiAppApiClient");
        }

        // Retrieves a single inspection by its unique identifier.
        public async Task<InspectionModel?> GetInspection(Guid id)
        {
            try
            {
                // Send a GET request to retrieve the inspection by ID.
                InspectionModel? inspection = await _httpClient.GetFromJsonAsync<InspectionModel>(
                    $"inspections/{id}",
                    new JsonSerializerOptions(JsonSerializerDefaults.Web));

                return inspection;
            }
            catch (HttpRequestException ex)
            {
                Debug.WriteLine($"HTTP request failed in GetInspection(): {ex.Message}");
                return null;
            }
            catch (JsonException ex)
            {
                Debug.WriteLine($"JSON parsing failed in GetInspection(): {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An unexpected error occurred in GetInspection(): {ex.Message}");
                return null;
            }
        }

        // Retrieves a list of all inspections.
        public async Task<List<InspectionModel>> GetInspections()
        {
            try
            {
                // Send a GET request to retrieve all inspections.
                List<InspectionModel>? inspections = await _httpClient.GetFromJsonAsync<List<InspectionModel>>(
                    $"inspections",
                    new JsonSerializerOptions(JsonSerializerDefaults.Web));

                return inspections ?? [];
            }
            catch (HttpRequestException ex)
            {
                Debug.WriteLine($"HTTP request failed in GetInspections(): {ex.Message}");
                return [];
            }
            catch (JsonException ex)
            {
                Debug.WriteLine($"JSON parsing failed in GetInspections(): {ex.Message}");
                return [];
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An unexpected error occurred in GetInspections(): {ex.Message}");
                return [];
            }
        }

        // Updates the status of an inspection.
        public async Task<bool> UpdateStatus(Guid id, InspectionStatusEnum status)
        {
            try
            {
                // Serialize the status enum to JSON and send a PATCH request to update the inspection status.
                var content = new StringContent(JsonSerializer.Serialize(status), Encoding.UTF8, "application/json");
                var response = await _httpClient.PatchAsync($"inspections/{id}/status", content);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                Debug.WriteLine($"HTTP request failed in UpdateStatus(): {ex.Message}");
                return false;
            }
            catch (JsonException ex)
            {
                Debug.WriteLine($"JSON parsing failed in UpdateStatus(): {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An unexpected error occurred in UpdateStatus(): {ex.Message}");
                return false;
            }
        }

        // Creates a new inspection.
        public async Task<bool> CreateInspection(InspectionModel model)
        {
            try
            {
                // Serialize the model to JSON and send a POST request to create a new inspection.
                var content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync($"inspections", content);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                Debug.WriteLine($"HTTP request failed in CreateInspection(): {ex.Message}");
                return false;
            }
            catch (JsonException ex)
            {
                Debug.WriteLine($"JSON parsing failed in CreateInspection(): {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An unexpected error occurred in CreateInspection(): {ex.Message}");
                return false;
            }
        }

        // Edits an existing inspection.
        public async Task<bool> EditInspection(InspectionModel model)
        {
            try
            {
                // Serialize the model to JSON and send a PUT request to update the inspection.
                var content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync($"inspections/{model.Id}", content);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                Debug.WriteLine($"HTTP request failed in EditInspection(): {ex.Message}");
                return false;
            }
            catch (JsonException ex)
            {
                Debug.WriteLine($"JSON parsing failed in EditInspection(): {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An unexpected error occurred in EditInspection(): {ex.Message}");
                return false;
            }
        }

        // Deletes an inspection by its unique identifier.
        public async Task<bool> DeleteInspection(Guid id)
        {
            try
            {
                // Send a DELETE request to delete the inspection by ID.
                var response = await _httpClient.DeleteAsync($"inspections/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                Debug.WriteLine($"HTTP request failed in DeleteInspection(): {ex.Message}");
                return false;
            }
            catch (JsonException ex)
            {
                Debug.WriteLine($"JSON parsing failed in DeleteInspection(): {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An unexpected error occurred in DeleteInspection(): {ex.Message}");
                return false;
            }
        }
    }
}