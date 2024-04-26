using Maui_App.ViewModels;
using System;
using Microsoft.Maui.Controls;

namespace Maui_App.Views
{
    public class BaseContentPage : ContentPage
    {
        private bool _isInitialized = false;

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Check if context conforms to base VM interface & hasn't been initialized
            if (_isInitialized || BindingContext is not IViewModelBase viewModel)
            {
                return;
            }

            try
            {
                await viewModel.InitializeAsyncCommand.ExecuteAsync(null);

                // Mark as initialized to prevent re-initialization
                _isInitialized = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Initialization failed: {ex.Message}");
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}
