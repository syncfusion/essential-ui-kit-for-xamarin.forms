﻿using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Templates
{
    /// <summary>
    /// Navigation tile template.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavigationTileTemplate : Grid
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationTileTemplate"/> class.
        /// </summary>
		public NavigationTileTemplate()
        {
            this.InitializeComponent();
        }
    }
}