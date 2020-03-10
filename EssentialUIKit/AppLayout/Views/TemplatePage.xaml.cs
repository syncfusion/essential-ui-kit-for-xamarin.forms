using System;
using EssentialUIKit.AppLayout.Models;
using EssentialUIKit.AppLayout.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.AppLayout.Views
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TemplatePage
    {
        #region Fields

        private double width;
        private double height;
        private bool isNavigationInQueue;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="TemplatePage" /> class.
        /// </summary>
        public TemplatePage(Category selectedCategory)
        {
            InitializeComponent();
            ((TemplatePageViewModel) BindingContext).SelectedCategory = selectedCategory;
        }

        #endregion

        #region Methods

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if ((Device.RuntimePlatform == "iOS" || Device.RuntimePlatform == "Android") &&
                AppSettings.Instance.IsSafeAreaEnabled)
            {
                if (width != this.width || height != this.height)
                {
                    var safeAreaHeight = AppSettings.Instance.SafeAreaHeight;
                    this.width = width;
                    this.height = height;

                    if (width < height)
                    {
                        iOSSafeArea.Height = safeAreaHeight;
                    }
                    else
                    {
                        iOSSafeArea.Height = 0;
                    }
                }
            }
        }

        protected override void OnAppearing()
        {
            this.isNavigationInQueue = false;
            base.OnAppearing();
        }

        protected override bool OnBackButtonPressed()
        {
            if (SettingsView.IsVisible)
            {
                SettingsView.Hide();
                return true;
            }

            return base.OnBackButtonPressed();
        }

        private void ShowSettings(object sender, EventArgs e)
        {
            SettingsView.Show();
        }

        private void BackButtonPressed(object sender, EventArgs e)
        {
            Navigation.PopAsync(true);
        }

        private void ListView_OnSelectionChanged(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null || this.isNavigationInQueue)
            {
                return;
            }

            this.isNavigationInQueue = true;
            Navigation.PushAsync(new TemplateHostPage(e.SelectedItem as Template));
        }

       private void GotoCodeViewer(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://github.com/syncfusion/essential-ui-kit-for-xamarin.forms"));
        }

       #endregion
    }
}