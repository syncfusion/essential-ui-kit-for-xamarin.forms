using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using EssentialUIKit.AppLayout.ViewModels;
using Syncfusion.XForms.Border;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.AppLayout.Views
{
    /// <summary>
    /// UITemplate settings view.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsView
    {
        private object pageBindingContext;

        public SettingsView()
        {
            this.InitializeComponent();
            this.BindingContext = AppSettings.Instance;

            var colors = new List<Color>
            {
                Color.FromHex("#f54e5e"),
                Color.FromHex("#2f72e4"),
                Color.FromHex("#5d4cf7"),
                Color.FromHex("#06846a"),
                Color.FromHex("#d54008"),
            };

            var viewCollection = new ObservableCollection<View>();

            foreach (var color in colors)
            {
                var grid = new Grid();
                var border = new SfBorder
                {
                    Margin = new Thickness(4),
                    HorizontalOptions = LayoutOptions.Center,
                    CornerRadius = 22,
                    BorderColor = color,
                    Content = new BoxView { Color = color },
                };
                grid.Children.Add(border);
                viewCollection.Add(grid);
            }

            this.PrimaryColorsView.ItemsSource = viewCollection;
            this.UpdatePrimaryColorIndex();
            this.UpdatePrimaryColor();
            this.PrimaryColorsView.SelectionChanged += (sender, e) =>
            {
                this.PrimaryColorsView.SelectionIndicatorSettings.Color = colors[e.Index];
                AppSettings.Instance.SelectedPrimaryColor = this.PrimaryColorsView.SelectedIndex;
            };
        }

        public void Show()
        {
            this.ShowSettingsPage();
        }

        public void Show(object obj)
        {
            this.pageBindingContext = obj;
            this.ShowSettingsPage();
        }

        public void Hide()
        {
            this.ShadowView.IsVisible = false;
            var fadeAnimation = new Animation(v => this.MainContent.Opacity = v, 1, 0);
            var translateAnimation = new Animation(v => this.MainContent.TranslationY = v, 0, this.MainContent.Height, null, () => { this.IsVisible = false; });

            var parentAnimation = new Animation { { 0.5, 1, fadeAnimation }, { 0, 1, translateAnimation } };
            parentAnimation.Commit(this, "HideSettings");
        }

        public void UpdatePrimaryColorIndex()
        {
            this.PrimaryColorsView.SelectedIndex = AppSettings.Instance.SelectedPrimaryColor;
        }

        private void ShowSettingsPage()
        {
            this.IsVisible = true;
            this.MainContent.FadeTo(1);
            this.MainContent.TranslateTo(this.MainContent.TranslationX, 0);
            this.ShadowView.IsVisible = true;
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void CloseSettings(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void lightTheme_Clicked(object sender, EventArgs e)
        {
            if (this.pageBindingContext != null)
            {
                (this.pageBindingContext as TemplatePageViewModel).IsDarkTheme = false;
            }

            Application.Current.Resources.ApplyLightTheme();
            this.PrimaryColorsView.SelectedIndex = 0;
            this.UpdatePrimaryColor();
        }

        private void darkTheme_Clicked(object sender, EventArgs e)
        {
            if (this.pageBindingContext != null)
            {
                (this.pageBindingContext as TemplatePageViewModel).IsDarkTheme = true;
            }

            Application.Current.Resources.ApplyDarkTheme();
            this.PrimaryColorsView.SelectedIndex = 1;
            this.UpdatePrimaryColor();
        }

        private void PrimaryColors_SelectionChanged(object sender, Syncfusion.XForms.Buttons.SelectionChangedEventArgs e)
        {
            AppSettings.Instance.SelectedPrimaryColor = this.PrimaryColorsView.SelectedIndex;
            this.UpdatePrimaryColor();
        }

        private void UpdatePrimaryColor()
        {
            Application.Current.Resources.TryGetValue("PrimaryColor", out var primaryColor);
            Application.Current.Resources.TryGetValue("Gray-White", out var grayWhite);
            if (AppSettings.Instance.IsDarkTheme == false)
            {
                this.lightTheme.BackgroundColor = (Color)primaryColor;
                this.lightTheme.TextColor = (Color)grayWhite;
                this.darkTheme.BackgroundColor = Color.LightGray;
                this.darkTheme.TextColor = Color.Black;
            }
            else
            {
                this.lightTheme.BackgroundColor = Color.LightGray;
                this.lightTheme.TextColor = Color.Black;
                this.darkTheme.BackgroundColor = (Color)primaryColor;
                this.darkTheme.TextColor = (Color)grayWhite;
            }
        }
    }
}