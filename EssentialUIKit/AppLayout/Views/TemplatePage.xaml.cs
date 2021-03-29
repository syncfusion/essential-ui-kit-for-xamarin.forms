using System;
using EssentialUIKit.AppLayout.Models;
using EssentialUIKit.AppLayout.ViewModels;
using Syncfusion.ListView.XForms;
using Syncfusion.XForms.EffectsView;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.AppLayout.Views
{
    /// <summary>
    /// UITemplate template host page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TemplatePage
    {
        #region Fields

        private double width;
        private double height;
        private bool isNavigationInQueue;
        private Template selectedItem;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="TemplatePage" /> class.
        /// </summary>
        public TemplatePage(Category selectedCategory, bool isDarkTheme, bool isGridView)
        {
            this.InitializeComponent();
            var bindingContext = (TemplatePageViewModel)this.BindingContext;
            bindingContext.IsDarkTheme = isDarkTheme;
            bindingContext.SelectedCategory = selectedCategory;
            this.UpdateTemplatePageLayout(isGridView);
        }

        #endregion

        #region Methods

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (width != this.width || height != this.height)
            {
                this.width = width;
                this.height = height;
                bool isItemsGridView = ((TemplatePageViewModel)this.BindingContext).IsItemsGridView;

                if (width < height)
                {
                    if ((Device.RuntimePlatform == "iOS" || Device.RuntimePlatform == "Android")
                        && AppSettings.Instance.IsSafeAreaEnabled)
                    {
                        this.iOSSafeArea.Height = AppSettings.Instance.SafeAreaHeight;
                    }

                    if (isItemsGridView && this.ListView.LayoutManager is GridLayout)
                    {
                        (this.ListView.LayoutManager as GridLayout).SpanCount = 2;
                    }
                }
                else
                {
                    if ((Device.RuntimePlatform == "iOS" || Device.RuntimePlatform == "Android")
                         && AppSettings.Instance.IsSafeAreaEnabled)
                    {
                        this.iOSSafeArea.Height = 0;
                    }

                    if (isItemsGridView && this.ListView.LayoutManager is GridLayout)
                    {
                        (this.ListView.LayoutManager as GridLayout).SpanCount = 4;
                    }
                }
            }
        }

        protected override void OnAppearing()
        {
            this.ListView.SelectedItem = null;
            this.isNavigationInQueue = false;
            base.OnAppearing();
        }

        protected override bool OnBackButtonPressed()
        {
            if (this.SettingsView.IsVisible)
            {
                this.SettingsView.Hide();
                return true;
            }

            return base.OnBackButtonPressed();
        }

        private void ShowSettings(object sender, EventArgs e)
        {
            this.SettingsView.Show(this.BindingContext);
        }

        private void BackButtonPressed(object sender, EventArgs e)
        {
            this.Navigation.PopAsync(true);
        }

        private void GotoCodeViewer(object sender, EventArgs e)
        {
            Launcher.OpenAsync(new Uri("https://github.com/syncfusion/essential-ui-kit-for-xamarin.forms"));
        }

        #endregion

        private void SfEffectsView_AnimationCompleted(object sender, EventArgs e)
        {
            var effectsView = sender as SfEffectsView;
            this.selectedItem = effectsView.BindingContext as Template;
            if (this.selectedItem == null || this.isNavigationInQueue)
            {
                return;
            }

            this.isNavigationInQueue = true;
            Page page = new TemplateHostPage(this.selectedItem as Template);
            this.Navigation.PushAsync(page, true);
        }

        private void GridIcon_Clicked(object sender, EventArgs e)
        {
            if (this.GridIcon.Text == "\xe733")
            {
                this.UpdateTemplatePageLayout(true);
            }
            else
            {
                this.UpdateTemplatePageLayout(false);
            }
        }

        private void UpdateTemplatePageLayout(bool isGridView)
        {
            if (isGridView)
            {
                this.GridIcon.Text = "\xe70d";
                this.ListView.ItemSpacing = new Thickness(0);
                ((TemplatePageViewModel)this.BindingContext).IsItemsGridView = true;

                this.ListView.LayoutManager = new GridLayout() { SpanCount = 2 };

                if (this.width < this.height)
                {
                    if (this.ListView.LayoutManager is GridLayout)
                    {
                        (this.ListView.LayoutManager as GridLayout).SpanCount = 2;
                    }
                    else
                    {
                        this.ListView.LayoutManager = new GridLayout() { SpanCount = 2 };
                    }
                }
                else
                {
                    if (this.ListView.LayoutManager is GridLayout)
                    {
                        (this.ListView.LayoutManager as GridLayout).SpanCount = 4;
                    }
                    else
                    {
                        this.ListView.LayoutManager = new GridLayout() { SpanCount = 4 };
                    }
                }
            }
            else
            {
                this.GridIcon.Text = "\xe733";
                this.ListView.ItemSpacing = new Thickness(0, 8, 0, 10);
                ((TemplatePageViewModel)this.BindingContext).IsItemsGridView = false;

                if (this.ListView.LayoutManager is GridLayout)
                {
                    (this.ListView.LayoutManager as GridLayout).SpanCount = 1;
                }
                else
                {
                    this.ListView.LayoutManager = new GridLayout() { SpanCount = 1 };
                }
            }
        }
    }
}