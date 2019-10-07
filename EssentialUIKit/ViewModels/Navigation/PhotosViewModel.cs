using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using EssentialUIKit.Models.Navigation;
using Xamarin.Forms;

namespace EssentialUIKit.ViewModels.Navigation
{
    /// <summary>
    /// Photos view model.
    /// </summary>
    [DataContract]
    public class PhotosViewModel: INotifyPropertyChanged
    {
        #region Fields

        private Command editCommand;

        private Command imageTapCommand;

        #endregion

        #region event

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the photos.
        /// </summary>
        /// <value>The photos.</value>
        [DataMember(Name = "photos")]
        public ObservableCollection<Photo> Photos { get; set; }

        /// <summary>
        /// Gets the command is executed when the add button is clicked.
        /// </summary>
        public Command EditCommand
        {
            get
            {
                return this.editCommand ?? (this.editCommand = new Command(this.EditButtonClicked));
            }
        }

        /// <summary>
        /// Gets the image tap command
        /// </summary>
        public Command ImageTapCommand
        {
            get
            {
                return this.imageTapCommand ?? (this.imageTapCommand = new Command(this.OnImageTapped));
            }
        }       

        #endregion

        #region Methods

        /// <summary>
        /// The PropertyChanged event fired when change the value of property.
        /// </summary>
        /// <param name="propertyName">Property name</param>
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Invoked when the edit button clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private void EditButtonClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the album image is clicked
        /// </summary>
        /// <param name="obj">The Object</param>
        private void OnImageTapped(object obj)
        {
            // Do Something
        }

        #endregion
    }
}
