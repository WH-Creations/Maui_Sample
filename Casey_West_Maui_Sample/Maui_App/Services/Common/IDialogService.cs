namespace Maui_App.Services.Common
{
    /* 
     * 
     * 
     * I used this file to showcase how I might add comments to functions w/ many paramters & return values
     * 
     * 
     */ 

    /// <summary>
    /// Provides an abstraction layer for presenting dialogs to the user.
    /// </summary>
    public interface IDialogService
    {
        /// <summary>
        /// Asks a yes/no question with customizable button texts.
        /// </summary>
        /// <param name="title">The title of the dialog.</param>
        /// <param name="message">The message of the dialog.</param>
        /// <param name="trueButtonText">Text for the 'Yes' button. Default is 'Yes'.</param>
        /// <param name="falseButtonText">Text for the 'No' button. Default is 'No'.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating the user's choice.</returns>
        Task<bool> Ask(string title, string message, string trueButtonText = "Yes", string falseButtonText = "No");

        /// <summary>
        /// Displays a notification dialog with a single button.
        /// </summary>
        /// <param name="title">The title of the notification.</param>
        /// <param name="message">The message of the notification.</param>
        /// <param name="buttonText">Text for the button. Default is 'OK'.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task Notify(string title, string message, string buttonText = "OK");
    }
}
