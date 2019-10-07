using EssentialUIKit.AppLayout.Views;
#if EnableAppCenterAnalytics
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
#endif
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit
{
    /// <summary>
    /// The UITemplate Application
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class App
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="App" /> class.
        /// </summary>
        public App()
        {
#if EnableAppCenterAnalytics
            // AppCenter.Start(
            //    $"ios={AppSettings.IOSSecretCode};android={AppSettings.AndroidSecretCode};uwp={AppSettings.UWPSecretCode}",
            //    typeof(Analytics),
            //    typeof(Crashes));
#endif

            InitializeComponent();

            // this.MainPage = new AppShell();
            this.MainPage = new NavigationPage(new HomePage());
        }

        #endregion

        #region Properties

        public static string BaseImageUrl { get; } = "https://cdn.syncfusion.com/essential-ui-kit-for-xamarin.forms/common/uikitimages/";

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when your app starts
        /// </summary>
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        /// <summary>
        /// Invoked when your app sleeps
        /// </summary>
        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        /// <summary>
        /// Invoked when your app resumes
        /// </summary>
        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        #endregion
    }
}