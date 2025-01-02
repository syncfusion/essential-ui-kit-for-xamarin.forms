using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Models.Navigation
{
    /// <summary>
    /// Model for the contact.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class Contact
    {
        #region Properties
        /// <summary>
        /// Gets or sets the name of the item.
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the background color for the contacts inside avatar view.
        /// </summary>
        [DataMember(Name = "backgroundColor")]
        public string BackgroundColor { get; set; }

        /// <summary>
        /// Gets or sets the names selected.
        /// </summary>
        public bool IsSelected { get; set; }

        #endregion
    }
}
