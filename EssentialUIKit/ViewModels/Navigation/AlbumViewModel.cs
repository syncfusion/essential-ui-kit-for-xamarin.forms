using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using EssentialUIKit.Models.Navigation;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.ViewModels.Navigation
{
    /// <summary>
    /// ViewModel for album page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class AlbumViewModel : BaseViewModel
    {
        #region Fields

        private ObservableCollection<Album> albumInfo;

        private Command addCommand;

        private Command viewAllCommand;

        private Command imageTapCommand;

        #endregion

        #region Constructor

        public AlbumViewModel()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the value for the album info.
        /// </summary>
        [DataMember(Name = "albumInfos")]
        public ObservableCollection<Album> AlbumInfo
        {
            get
            {
                return this.albumInfo;
            }

            set
            {
                if (this.albumInfo == value)
                {
                    return;
                }

                this.albumInfo = value;
                this.NotifyPropertyChanged();
            }
        }

        #endregion

        #region Command

        /// <summary>
        /// Gets the command that is executed when the Add button is clicked.
        /// </summary>
        public Command AddCommand
        {
            get
            {
                return this.addCommand ?? (this.addCommand = new Command(this.AddButtonClicked));
            }
        }

        /// <summary>
        /// Gets the command that is executed when the View all button is clicked.
        /// </summary>
        public Command ViewAllCommand
        {
            get { return this.viewAllCommand ?? (this.viewAllCommand = new Command(this.ViewAllButtonClicked)); }
        }

        /// <summary>
        /// Gets the image tap command.
        /// </summary>
        public Command ImageTapCommand
        {
            get { return this.imageTapCommand ?? (this.imageTapCommand = new Command(this.OnImageTapped)); }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when the Add button is clicked.
        /// </summary>
        /// <param name="obj">The object</param>
        private void AddButtonClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the View all button is clicked.
        /// </summary>
        /// <param name="obj">The object</param>
        private void ViewAllButtonClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the album image is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void OnImageTapped(object obj)
        {
            // Do Something
        }

        #endregion
    }
}