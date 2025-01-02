using System.ComponentModel;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Models.About
{
    /// <summary>
    /// Model for About us templates.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class AboutUsModel : INotifyPropertyChanged
    {
        #region Fields

        private string employeeName;

        private string designation;

        private string image;

        #endregion

        #region EventHandler

        /// <summary>
        /// EventHandler of property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the name of an employee.
        /// </summary>
        /// <value>The name.</value>
        public string EmployeeName
        {
            get
            {
                return this.employeeName;
            }

            set
            {
                this.employeeName = value;
                this.OnPropertyChanged(nameof(EmployeeName));
            }
        }

        /// <summary>
        /// Gets or sets the designation of an employee.
        /// </summary>
        /// <value>The designation.</value>
        public string Designation
        {
            get
            {
                return this.designation;
            }

            set
            {
                this.designation = value;
                this.OnPropertyChanged(nameof(Designation));
            }
        }

        /// <summary>
        /// Gets or sets the image of an employee.
        /// </summary>
        /// <value>The image.</value>
        public string Image
        {
            get
            {
                return this.image;
            }

            set
            {
                this.image = value;
                this.OnPropertyChanged(nameof(Image));
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The PropertyChanged event occurs when changing the value of property.
        /// </summary>
        /// <param name="propertyName">The PropertyName</param>
        protected void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
