using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.ViewModels.ErrorAndEmpty
{
    /// <summary>
    /// ViewModel for no item page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class NoItemPageViewModel : INotifyPropertyChanged
    {
        #region Fields

        private string imagePath;

        private string header;

        private string content;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="NoItemPageViewModel" /> class.
        /// </summary>
        public NoItemPageViewModel()
        {
            this.ImagePath = "NoItem.svg";
            this.Header = "NO ITEMS";
            this.Content = "You haven’t selected any items yet";
            this.GoBackCommand = new Command(this.GoBack);
        }

        #endregion

        #region Events

        /// <summary>
        /// The declaration of the property changed event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Commands

        /// <summary>
        /// Gets or sets the command that is executed when the Go back button is clicked.
        /// </summary>
        public ICommand GoBackCommand { get; set; }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the ImagePath.
        /// </summary>
        public string ImagePath
        {
            get
            {
                return this.imagePath;
            }

            set
            {
                this.imagePath = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the Header.
        /// </summary>
        public string Header
        {
            get
            {
                return this.header;
            }

            set
            {
                this.header = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the Content.
        /// </summary>
        public string Content
        {
            get
            {
                return this.content;
            }

            set
            {
                this.content = value;
                this.OnPropertyChanged();
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The PropertyChanged event occurs when changing the value of property.
        /// </summary>
        /// <param name="propertyName">Property name</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Invoked when the Go back button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void GoBack(object obj)
        {
            // Do something
        }

        #endregion
    }
}
