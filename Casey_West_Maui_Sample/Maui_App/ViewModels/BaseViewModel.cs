using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace Maui_App.ViewModels
{
	internal partial class ViewModelBase : ObservableValidator, IBaseViewModel
	{
		[ObservableProperty]
		private bool _isLoading;

		public IAsyncRelayCommand InitializeAsyncCommand { get; }

		//Constructor for ViewModelBase that sets up the InitializeAsyncCommand.
		public ViewModelBase()
		{
			InitializeAsyncCommand = new AsyncRelayCommand(
				execute: async () =>
				{
					// Check to ensure we don't re-enter the loading process
					if (!IsLoading) 
					{
						IsLoading = true;
						try
						{
							await Loading(LoadAsync);
						}
						catch (Exception ex)
						{
							Debug.WriteLine($"Error loading data: {ex.Message}");
						}
						finally
						{
							IsLoading = false;
						}
					}
				},
				canExecute: () => !IsLoading // Only execute the command if not already loading
			);
		}

		/// <summary>
		/// Executes the loading process using a specified asynchronous task.
		/// </summary>
		/// <param name="unitOfWork">The unit of work to execute as part of loading.</param>
		protected async Task Loading(Func<Task> unitOfWork)
		{
			try
			{
				await unitOfWork();
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"Error during unit of work: {ex.Message}");
			}
		}

		// Placeholder method for loading data asynchronously. Should be overridden in derived classes.
		public virtual Task LoadAsync()
		{
			// No operation by default, override in subclasses
			return Task.CompletedTask;
		}
	}
}