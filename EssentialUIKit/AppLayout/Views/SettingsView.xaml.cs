using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Syncfusion.XForms.Border;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.AppLayout.Views
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsView
    {
        public SettingsView()
        {
            InitializeComponent();
            BindingContext = AppSettings.Instance;
            
            var colors = new List<Color>
            {
                Color.FromHex("#f54e5e"),
                Color.FromHex("#2f72e4"),
                Color.FromHex("#5d4cf7"),
                Color.FromHex("#06846a"),
                Color.FromHex("#d54008")
            };

            var viewCollection = new ObservableCollection<View>();

            foreach (var color in colors)
            {
                var grid = new Grid();
                var border = new SfBorder
                {
                    Margin = new Thickness(3),
                    HorizontalOptions = LayoutOptions.Center,
                    CornerRadius = 22,
                    BorderWidth = 0,
                    Content = new BoxView { Color = color }
                };
                grid.Children.Add(border);
                viewCollection.Add(grid);
            }

            PrimaryColorsView.ItemsSource = viewCollection;
            PrimaryColorsView.SelectedIndex = AppSettings.Instance.SelectedPrimaryColor;
            PrimaryColorsView.SelectionChanged += (sender, e) =>
            {
                PrimaryColorsView.SelectionIndicatorSettings.Color = colors[e.Index];
            };
        }
        
        public void Show()
        {
            IsVisible = true;
            MainContent.FadeTo(1);
            MainContent.TranslateTo(MainContent.TranslationX, 0);
            ShadowView.IsVisible = true;
        }

        public void Hide()
        {
            ShadowView.IsVisible = false;
            var fadeAnimation = new Animation(v => MainContent.Opacity = v, 1, 0);
            var translateAnimation = new Animation(v => MainContent.TranslationY = v, 0, MainContent.Height, null, () => { IsVisible = false; });

            var parentAnimation = new Animation { { 0.5, 1, fadeAnimation }, { 0, 1, translateAnimation } };
            parentAnimation.Commit(this, "HideSettings");
        }

        private void ApplySettings(object sender, EventArgs e)
        {
            AppSettings.Instance.SelectedPrimaryColor = PrimaryColorsView.SelectedIndex;
            this.Hide();
        }
        
        private void Button_OnClicked(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void CloseSettings(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}