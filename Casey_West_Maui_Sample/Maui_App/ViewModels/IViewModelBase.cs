using CommunityToolkit.Mvvm.Input;

namespace Maui_App.ViewModels
{
    public interface IViewModelBase
    {
        IAsyncRelayCommand InitializeAsyncCommand { get; }
    }
}