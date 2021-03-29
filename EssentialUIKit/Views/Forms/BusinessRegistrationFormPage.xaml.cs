﻿using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Forms
{
    /// <summary>
    /// Page to add business details such as name, email address, and phone number.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BusinessRegistrationFormPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessRegistrationFormPage" /> class.
        /// </summary>
        public BusinessRegistrationFormPage()
        {
            this.InitializeComponent();
        }
    }
}