using EssentialUIKit.AppLayout;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit
{
    /// <summary>
    /// Application settings
    /// </summary>
    [Preserve(AllMembers = true)]
    public class AppSettings
    {
        private bool enableRTL;

        private bool isDarkTheme;

        private int selectedPrimaryColor;

        static AppSettings()
        {
            Instance = new AppSettings();
        }

        public static AppSettings Instance { get; }

        public bool IsSafeAreaEnabled { get; set; } = false;

        public double SafeAreaHeight { get; set; }

        public bool EnableRTL
        {
            get => this.enableRTL;
            set
            {
                if (value == this.enableRTL)
                {
                    return;
                }

                this.enableRTL = value;
                Application.Current.MainPage.FlowDirection =
                    this.enableRTL ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;
            }
        }

        /// <summary>
        /// Gets the AndroidSecretCode.
        /// </summary>
        public string AndroidSecretCode => "88dda0e2-da50-466e-9aa5-36fc504d9ed3";

        /// <summary>
        /// Gets the iOSSecretCode.
        /// </summary>
        public string IOSSecretCode => "b327e367-8f04-4efe-ad7a-85be8c828ec3";

        /// <summary>
        /// Gets the UWPSecretCode.
        /// </summary>
        public string UWPSecretCode => "ca0577ad-4cd2-4258-a35b-465e8f4669d9";

        public bool IsDarkTheme
        {
            get => this.isDarkTheme;
            set
            {
                if (this.isDarkTheme == value)
                {
                    return;
                }

                this.isDarkTheme = value;
                if (this.isDarkTheme)
                {
                    // Dark Theme
                    Application.Current.Resources.ApplyDarkTheme();
                }
                else
                {
                    // Light Theme
                    Application.Current.Resources.ApplyLightTheme();
                }
            }
        }

        public int SelectedPrimaryColor
        {
            get => this.selectedPrimaryColor;
            set
            {
                if (this.selectedPrimaryColor == value)
                {
                    return;
                }

                this.selectedPrimaryColor = value;
                Extensions.ApplyColorSet(this.selectedPrimaryColor);
            }
        }
    }
}