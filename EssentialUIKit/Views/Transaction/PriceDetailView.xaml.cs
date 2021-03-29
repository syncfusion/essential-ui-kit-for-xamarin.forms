﻿using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Transaction
{
    /// <summary>
    /// The PriceDetail View.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PriceDetailView
    {
        /// <summary>
        /// Gets or sets the ActionTextProperty, and it is a bindable property.
        /// </summary>
        public static readonly BindableProperty ActionTextProperty =
            BindableProperty.Create(nameof(ActionText), typeof(string), typeof(PriceDetailView));

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="PriceDetailView" /> class.
        /// </summary>
        public PriceDetailView()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Public properties

        /// <summary>
        /// Gets or sets the Action Text.
        /// </summary>
        public string ActionText
        {
            get { return (string)this.GetValue(ActionTextProperty); }
            set { this.SetValue(ActionTextProperty, value); }
        }

        #endregion
    }
}