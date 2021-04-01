using System;
using System.Reflection;
using EssentialUIKit.AppLayout.Models;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.AppLayout.Views
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TemplateHostPage
    {
        #region Fields

        private double width;
        private double height;

        #endregion

        #region  Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="TemplateHostPage" /> class.
        /// </summary>
        public TemplateHostPage(Template selectedTemplate)
        {
            this.InitializeComponent();
            this.TemplateHostView.HeightRequest = this.HostViewContainer.HeightRequest = Application.Current.MainPage.Height - 55;
            this.TemplateHostView.WidthRequest = this.HostViewContainer.WidthRequest = Application.Current.MainPage.Width;

            if (selectedTemplate != null)
            {
                this.TitleView.Text = selectedTemplate.Name;
                this.LoadPage(selectedTemplate.PageName);
            }
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
                        this.iOSSafeArea.Height = safeAreaHeight;
                    }
                    else
                    {
                        this.iOSSafeArea.Height = 0;
                    }

                    if (Device.RuntimePlatform == "iOS")
                    {
                        (this.TemplateHostView.Template as NavigationPage).CurrentPage.Layout(new Rectangle(0, 0, width, height - safeAreaHeight));
                    }
                }
            }
        }

        private void LoadPage(string pageURL)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;

            var page = (Page)Activator.CreateInstance(assembly.GetType($"EssentialUIKit.{pageURL}"));

            this.TemplateHostView.Template = new NavigationPage(page);
        }

        private void BackButtonPressed(object sender, EventArgs e)
        {
            this.Navigation.PopAsync(true);
        }

        #endregion
    }
}