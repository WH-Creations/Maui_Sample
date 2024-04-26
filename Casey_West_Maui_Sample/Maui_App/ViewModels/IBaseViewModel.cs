using CommunityToolkit.Mvvm.Input;

namespace Maui_App.ViewModels
{
    internal interface IBaseViewModel
    {
        // Command to initialize the ViewModel asynchronously.
        IAsyncRelayCommand InitializeAsyncCommand { get; }
    }
}
