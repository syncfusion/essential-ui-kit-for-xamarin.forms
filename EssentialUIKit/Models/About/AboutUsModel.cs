using System.ComponentModel;
using System.Runtime.Serialization;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Models.About
{
    /// <summary>
    /// Model for AboutUs Page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
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
        [DataMember(Name = "employeeName")]
        public string EmployeeName
        {
            get
            {
                return this.employeeName;
            }

            set
            {
                this.employeeName = value;
                this.OnPropertyChanged(nameof(this.EmployeeName));
            }
        }

        /// <summary>
        /// Gets or sets the designation of an employee.
        /// </summary>
        /// <value>The designation.</value>
        [DataMember(Name = "designation")]
        public string Designation
        {
            get
            {
                return this.designation;
            }

            set
            {
                this.designation = value;
                this.OnPropertyChanged(nameof(this.Designation));
            }
        }

        /// <summary>
        /// Gets or sets the image of an employee.
        /// </summary>
        /// <value>The image.</value>
        [DataMember(Name = "image")]
        public string Image
        {
            get
            {
                return App.ImageServerPath + this.image;
            }

            set
            {
                this.image = value;
                this.OnPropertyChanged(nameof(this.Image));
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
