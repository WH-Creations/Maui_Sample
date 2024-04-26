namespace Maui_App.Services.Common
{
    public class DialogService : IDialogService
    {
        public async Task<bool> Ask(string title, string message, string trueButtonText = "Yes", string falseButtonText = "No")
        {
            try
            {
                return await Shell.Current.DisplayAlert(title, message, trueButtonText, falseButtonText);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error displaying dialog: {ex.Message}");
                return false;
            }
        }

        public async Task Notify(string title, string message, string buttonText = "OK")
        {
            try
            {
                await Shell.Current.DisplayAlert(title, message, buttonText);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error displaying notification: {ex.Message}");
            }
        }
    }
}
