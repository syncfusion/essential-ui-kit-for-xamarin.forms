using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Controls
{
    /// <summary>
    /// The Title view
    /// </summary>
    [Preserve(AllMembers = true)]
    public class TitleView : Grid
    {    
        #region Bindable Properties

        /// <summary>
        /// Gets or sets the LeadingViewProperty, and it is a bindable property.
        /// </summary>
        public static readonly BindableProperty LeadingViewProperty = BindableProperty.Create(nameof(LeadingView), typeof(View), typeof(TitleView), new ContentView(), BindingMode.Default, null, OnLeadingViewPropertyChanged);

        /// <summary>
        /// Gets or sets the TrailingViewProperty, and it is a bindable property.
        /// </summary>
        public static readonly BindableProperty TrailingViewProperty = BindableProperty.Create(nameof(TrailingView), typeof(View), typeof(TitleView), new ContentView(), BindingMode.Default, null, OnTrailingViewPropertyChanged);

        /// <summary>
        /// Gets or sets the ContentProperty, and it is a bindable property.
        /// </summary>
        public static readonly BindableProperty ContentProperty = BindableProperty.Create(nameof(Content), typeof(View), typeof(TitleView), new ContentView(), BindingMode.Default, null, OnContentPropertyChanged);

        /// <summary>
        /// Gets or sets the TitleProperty, and it is a bindable property.
        /// </summary>
        public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(TitleView), string.Empty, BindingMode.Default, null, OnTitlePropertyChanged);

        /// <summary>
        /// Gets or sets the FontFamilyProperty, and it is a bindable property.
        /// </summary>
        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(TitleView), string.Empty, BindingMode.Default, null, OnFontFamilyPropertyChanged);

        /// <summary>
        /// Gets or sets the FontAttributesProperty, and it is a bindable property.
        /// </summary>
        public static readonly BindableProperty FontAttributesProperty = BindableProperty.Create(nameof(FontAttributes), typeof(FontAttributes), typeof(TitleView), FontAttributes.None, BindingMode.Default, null, OnFontAttributesPropertyChanged);

        /// <summary>
        /// Gets or sets the FontSizeProperty, and it is a bindable property.
        /// </summary>
        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(nameof(FontSize), typeof(double), typeof(TitleView), 16d, BindingMode.Default, null, OnFontSizePropertyChanged);

        #endregion

        #region variables

        /// <summary>
        /// Gets or sets the title label.
        /// </summary>
        private Label titleLabel;

        #endregion

        #region Constructor

        public TitleView()
        {
            this.ColumnSpacing = 2;
            this.RowSpacing = 8;
            this.Padding = new Thickness(0, 8, 0, 0);

            this.ColumnDefinitions = new ColumnDefinitionCollection
            {
                new ColumnDefinition { Width = 8 },
                new ColumnDefinition(),
                new ColumnDefinition(),
                new ColumnDefinition(),
                new ColumnDefinition { Width = 8 },
            };

            this.RowDefinitions = new RowDefinitionCollection
            {
                new RowDefinition { Height = GridLength.Auto },
                new RowDefinition { Height = 1 }
            };

            var boxView = new BoxView { Color = (Color)Application.Current.Resources["Gray-200"] };

            Children.Add(this.LeadingView, 1, 0);
            Children.Add(this.Content, 2, 0);
            Children.Add(this.TrailingView, 3, 0);
            Children.Add(boxView, 0, 1);
            SetColumnSpan(boxView, 5);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the LeadingView.
        /// </summary>
        public View LeadingView
        {
            get { return (View)GetValue(LeadingViewProperty); }
            set { this.SetValue(LeadingViewProperty, value); }
        }

        /// <summary>
        /// Gets or sets the TrailingView.
        /// </summary>
        public View TrailingView
        {
            get { return (View)GetValue(TrailingViewProperty); }
            set { this.SetValue(TrailingViewProperty, value); }
        }

        /// <summary>
        /// Gets or sets the Content.
        /// </summary>
        public View Content
        {
            get { return (View)GetValue(ContentProperty); }
            set { this.SetValue(ContentProperty, value); }
        }

        /// <summary>
        /// Gets or sets the Title.
        /// </summary>
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { this.SetValue(TitleProperty, value); }
        }

        /// <summary>
        /// Gets or sets the FontFamily.
        /// </summary>
        public string FontFamily
        {
            get { return (string)GetValue(FontFamilyProperty); }
            set { this.SetValue(FontFamilyProperty, value); }
        }

        /// <summary>
        /// Gets or sets the FontAttributes.
        /// </summary>
        public FontAttributes FontAttributes
        {
            get { return (FontAttributes)GetValue(FontAttributesProperty); }
            set { this.SetValue(FontAttributesProperty, value); }
        }

        /// <summary>
        /// Gets or sets the FontSize.
        /// </summary>
        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { this.SetValue(FontSizeProperty, value); }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when the leading view is changed.
        /// </summary>
        /// <param name="bindable">The TitleView</param>
        /// <param name="oldValue">The old value</param>
        /// <param name="newValue">The new value</param>
        private static void OnLeadingViewPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var titleView = bindable as TitleView;
            var newView = (View)newValue;
            newView.HorizontalOptions = LayoutOptions.Start;
            titleView.Children.Add(newView, 1, 0);
        }

        /// <summary>
        /// Invoked when the trailing view is changed.
        /// </summary>
        /// <param name="bindable">The TitleView</param>
        /// <param name="oldValue">The old value</param>
        /// <param name="newValue">The new value</param>
        private static void OnTrailingViewPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var titleView = bindable as TitleView;
            var newView = (View)newValue;
            newView.HorizontalOptions = LayoutOptions.End;
            titleView.Children.Add(newView, 3, 0);
        }

        /// <summary>
        /// Invoked when the Content is changed.
        /// </summary>
        /// <param name="bindable">The TitleView</param>
        /// <param name="oldValue">The old value</param>
        /// <param name="newValue">The new value</param>
        private static void OnContentPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var titleView = bindable as TitleView;
            var newView = (View)newValue;

            if (!string.IsNullOrEmpty(titleView.Title))
            {
                titleView.Children.Remove(titleView.titleLabel);
            }

            titleView.Children.Add(newView, 2, 0);
        }

        /// <summary>
        /// Invoked when the Title is changed.
        /// </summary>
        /// <param name="bindable">The TitleView</param>
        /// <param name="oldValue">The old value</param>
        /// <param name="newValue">The new value</param>
        private static void OnTitlePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var titleView = bindable as TitleView;
            var newText = (string)newValue;

            if (!string.IsNullOrEmpty(newText))
            {
                titleView.titleLabel = new Label
                {
                    Text = newText,
                    TextColor = (Color)Application.Current.Resources["Gray-900"],
                    FontSize = 16,
                    Margin = new Thickness(0, 8),
                    FontFamily = Device.RuntimePlatform == Device.Android
                            ? "Montserrat-Medium.ttf#Montserrat-Medium"
                            : Device.RuntimePlatform == Device.iOS
                                ? "Montserrat-Medium"
                                : "Assets/Montserrat-Medium.ttf#Montserrat-Medium",
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                };

                if (Device.RuntimePlatform == Device.Android)
                {
                    titleView.titleLabel.LineHeight = 1.5;
                }

                titleView.Children.Remove(titleView.Content);
                titleView.Children.Add(titleView.titleLabel, 2, 0);
            }
        }

        /// <summary>
        /// Invoked when the FontFamily is changed.
        /// </summary>
        /// <param name="bindable">The TitleView</param>
        /// <param name="oldValue">The old value</param>
        /// <param name="newValue">The new value</param>
        private static void OnFontFamilyPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var titleView = bindable as TitleView;

            if (titleView.titleLabel != null)
            {
                titleView.titleLabel.FontFamily = (string)newValue;
            }
        }

        /// <summary>
        /// Invoked when the FontAttributes is changed.
        /// </summary>
        /// <param name="bindable">The TitleView</param>
        /// <param name="oldValue">The old value</param>
        /// <param name="newValue">The new value</param>
        private static void OnFontAttributesPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var titleView = bindable as TitleView;

            if (titleView.titleLabel != null)
            {
                titleView.titleLabel.FontAttributes = (FontAttributes)newValue;
            }
        }

        /// <summary>
        /// Invoked when the FontSize is changed.
        /// </summary>
        /// <param name="bindable">The TitleView</param>
        /// <param name="oldValue">The old value</param>
        /// <param name="newValue">The new value</param>
        private static void OnFontSizePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var titleView = bindable as TitleView;

            if (titleView.titleLabel != null)
            {
                titleView.titleLabel.FontSize = (double)newValue;
            }
        }

        #endregion
    }
}