﻿using EssentialUIKit.AppLayout;
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
        private readonly OSAppTheme currentTheme;

        private bool enableRTL;

        private bool isDarkTheme;

        private int selectedPrimaryColor;

        private bool isGridView;

        static AppSettings()
        {
            Instance = new AppSettings();
        }

        private AppSettings()
        {
            this.IsGridView = true;
            this.currentTheme = Application.Current.RequestedTheme;
            this.selectedPrimaryColor = this.currentTheme == OSAppTheme.Light ? 0 : 1;
        }

        public static AppSettings Instance { get; }

        /// <summary>
        /// Gets the AndroidSecretCode.
        /// </summary>
        public static string AndroidSecretCode => "88dda0e2-da50-466e-9aa5-36fc504d9ed3";

        /// <summary>
        /// Gets the iOSSecretCode.
        /// </summary>
        public static string IOSSecretCode => "b327e367-8f04-4efe-ad7a-85be8c828ec3";

        /// <summary>
        /// Gets the UWPSecretCode.
        /// </summary>
        public static string UWPSecretCode => "ca0577ad-4cd2-4258-a35b-465e8f4669d9";

        public bool IsSafeAreaEnabled { get; set; }

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

        public bool IsGridView
        {
            get => this.isGridView;
            set
            {
                if (this.isGridView == value)
                {
                    return;
                }

                this.isGridView = value;
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
                ThemePalette.ApplyColorSet(this.selectedPrimaryColor);
            }
        }
    }
}