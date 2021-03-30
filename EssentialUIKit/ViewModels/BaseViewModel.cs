using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.ViewModels
{
    /// <summary>
    /// This viewmodel extends in another viewmodels.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Fields

        private Command<object> backButtonCommand;

        #endregion

        #region Event handler

        /// <summary>
        /// Occurs when the property is changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Commands

        /// <summary>
        /// Gets the command that will be executed when an item is selected.
        /// </summary>
        public Command<object> BackButtonCommand
        {
            get
            {
                return this.backButtonCommand ?? (this.backButtonCommand = new Command<object>(this.BackButtonClicked));
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The PropertyChanged event occurs when changing the value of property.
        /// </summary>
        /// <param name="propertyName">The PropertyName</param>
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            this.NotifyPropertyChanged(propertyName);

            return true;
        }

        /// <summary>
        /// Invoked when an back button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void BackButtonClicked(object obj)
        {
            if (Device.RuntimePlatform == Device.UWP && Application.Current.MainPage.Navigation.NavigationStack.Count > 1)
            {
                Application.Current.MainPage.Navigation.PopAsync();
            }
            else if (Device.RuntimePlatform != Device.UWP && Application.Current.MainPage.Navigation.NavigationStack.Count > 0)
            {
                Application.Current.MainPage.Navigation.PopAsync();
            }
        }

        #endregion
    }
}
