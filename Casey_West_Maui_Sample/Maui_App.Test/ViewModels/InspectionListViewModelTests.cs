using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maui_App.Messages;
using Maui_App.Models;
using Maui_App.Services.Common;
using Maui_App.Services.Inspections;
using Maui_App.ViewModels.Inspection;
using NSubstitute;
using Xunit;

namespace Maui_App.Test.ViewModels
{
    public class InspectionListViewModelTests
    {
        // Test to ensure that Inspections are loaded correctly when LoadAsync is called.
        [Fact]
        public async Task LoadAsync_WhenCalled_LoadsInspections()
        {
            // Arrange: Setup the mock services and the ViewModel.
            var inspectionService = Substitute.For<IInspectionService>();
            var navigationService = Substitute.For<INavigationService>();
            var viewModel = new InspectionListViewModel(inspectionService, navigationService);
            var mockInspections = new List<InspectionModel>
            {
                new InspectionModel { Id = Guid.NewGuid(), Name = "Test Inspection 1" }
            };
            inspectionService.GetInspections().Returns(mockInspections);  // Setup a return value for GetInspections.

            // Act: Call LoadAsync to simulate loading inspections.
            await viewModel.LoadAsync();

            // Assert: Verify that the Inspections property is populated and the GetInspections method was called.
            // Check if one inspection was loaded.
            Assert.Single(viewModel.Inspections); 
            // Validate the data of the loaded inspection.
            Assert.Equal("Test Inspection 1", viewModel.Inspections[0].Name);
            await inspectionService.Received(1).GetInspections(); 
        }

        // Test to verify that the ViewModel updates the Inspections list upon receiving an InspectionUpdatedMessage.
        [Fact]
        public async Task Receive_InspectionUpdatedMessage_UpdatesInspections()
        {
            // Arrange: Setup the necessary services and ViewModel.
            var inspectionService = Substitute.For<IInspectionService>();
            var navigationService = Substitute.For<INavigationService>();
            var viewModel = new InspectionListViewModel(inspectionService, navigationService);
            var message = new InspectionUpdatedMessage();  // Create a new message instance.

            // Act: Simulate receiving an updated message.
            viewModel.Receive(message);

            // Use a small delay to simulate the time it takes for asynchronous operations to complete.
            await Task.Delay(500);

            // Assert: Ensure that GetInspections was called to update the inspections list.
            await inspectionService.Received(1).GetInspections();
        }
    }
}
