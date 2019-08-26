using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using EssentialUIKit.Models.Navigation;

namespace EssentialUIKit.ViewModels.Navigation
{
    /// <summary>
    /// ViewModel for album page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class AlbumViewModel : INotifyPropertyChanged
    {
        #region Fields

        private ObservableCollection<Album> albumInfo;

        #endregion

        #region Constructor

        public AlbumViewModel()
        {
            this.AlbumInfo = new ObservableCollection<Album>();
            var randomNum = new Random(0123456789);
            var albumNames = new[]
                {"Favourites", "WhatsApp", "Work", "Facebook", "People", "Place", "Wildlife", "Food"};

            for (var i = 0; i < albumNames.Length; i++)
            {
                var review = new Album
                {
                    AlbumName = albumNames[i],
                    AlbumImage = App.BaseImageUrl + "Album" + (i + 1) + ".png",
                    TotalPhotos = randomNum.Next(50, 500) + " Photos",
                    Category = i < 4 ? "MY ALBUM" : "OTHER ALBUM",
                };

                this.AlbumInfo.Add(review);
            }

            this.AddCommand = new Command(this.AddButtonClicked);
            this.ViewAllCommand = new Command(this.ViewAllButtonClicked);
            this.ImageTapCommand = new Command<object>(this.OnImageTapped);
        }

        #endregion

        #region Event

        /// <summary>
        /// The declaration of the property changed event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the value for the album info.
        /// </summary>
        public ObservableCollection<Album> AlbumInfo
        {
            get { return this.albumInfo; }

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
        /// Gets or sets the command that is executed when the Add button is clicked.
        /// </summary>
        public Command AddCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the View all button is clicked.
        /// </summary>
        public Command ViewAllCommand { get; set; }

        /// <summary>
        /// Gets or sets the image tap command.
        /// </summary>
        public Command<object> ImageTapCommand { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// The PropertyChanged event occurs when changing the value of property.
        /// </summary>
        /// <param name="propertyName">Property name</param>
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

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