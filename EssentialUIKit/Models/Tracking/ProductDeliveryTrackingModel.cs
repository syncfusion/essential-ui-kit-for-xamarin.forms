using System.Runtime.Serialization;
using Syncfusion.XForms.ProgressBar;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Models.Tracking
{
    /// <summary>
    /// Model for ProductDeliveryTrackingModel
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class ProductDeliveryTrackingModel
    {
        #region Fields

        private string status;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        [DataMember(Name = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the title status.
        /// </summary>
        [DataMember(Name = "titlestatus")]
        public string TitleStatus { get; set; }

        /// <summary>
        /// Gets or sets the order status.
        /// </summary>
        [DataMember(Name = "orderstatus")]
        public string OrderStatus { get; set; }

        /// <summary>
        /// Gets or sets the progress value.
        /// </summary>
        [DataMember(Name = "progressvalue")]
        public double ProgressValue { get; set; }

        /// <summary>
        /// Gets or sets the step status.
        /// </summary>
        [DataMember(Name = "stepstatus")]
        public string Status
        {
            get
            {
                return this.status;
            }

            set
            {
                this.status = value;
                if (this.status != null)
                {
                    this.StepStatus = this.Status == "InProgress" ? StepStatus.InProgress : this.Status == "Completed" ? StepStatus.Completed : StepStatus.NotStarted;
                }
            }
        }

        /// <summary>
        /// Gets or sets the step status.
        /// </summary>
        public StepStatus StepStatus { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        [DataMember(Name = "date")]
        public string Date { get; set; }

        /// <summary>
        /// Gets or sets the order date.
        /// </summary>
        [DataMember(Name = "orderdate")]
        public string OrderDate { get; set; }

        #endregion
    }
}
