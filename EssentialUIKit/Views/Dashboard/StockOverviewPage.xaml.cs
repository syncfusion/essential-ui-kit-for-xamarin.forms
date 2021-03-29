﻿using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Dashboard
{
    /// <summary>
    /// Page to stock details with chart.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StockOverviewPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StockOverviewPage" /> class.
        /// </summary>
        public StockOverviewPage()
        {
            this.InitializeComponent();
        }
    }
}