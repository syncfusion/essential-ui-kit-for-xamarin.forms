﻿using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Controls
{
    /// <summary>
    /// The Parallax scroll view
    /// </summary>
    [Preserve(AllMembers = true)]
    public class ParallaxScrollView : ScrollView
    {
        #region Bindable Properties

        /// <summary>
        /// Bindable property to set the parallx header view.
        /// </summary>
        public static readonly BindableProperty ParallaxHeaderViewProperty =
           BindableProperty.Create(nameof(ParallaxScrollView), typeof(View), typeof(ParallaxScrollView), null);

        #endregion

        #region variables

        /// <summary>
        /// Gets or sets the height of the header view.
        /// </summary>
        private double height;

        #endregion

        #region Constructor

        /// <summary>
        /// Initialize the parallx scroll view.
        /// </summary>
        public ParallaxScrollView()
        {
            Scrolled += (sender, e) => this.Parallax();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the Parallx header view.
        /// </summary>
        public View ParallaxHeaderView
        {
            get => (View)this.GetValue(ParallaxHeaderViewProperty);
            set => this.SetValue(ParallaxHeaderViewProperty, value);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when scroll the view.
        /// </summary>
        public void Parallax()
        {
            if (this.ParallaxHeaderView == null)
            {
                return;
            }

            if (this.height <= 0)
            {
                this.height = this.ParallaxHeaderView.Height;
            }

            var y = -(int)((float)this.ScrollY / 2.0f);

            if (y < 0)
            {
                this.ParallaxHeaderView.Scale = 1;
                this.ParallaxHeaderView.TranslationY = y;
            }
            else if (Device.RuntimePlatform == "iOS")
            {
                var newHeight = this.height + (this.ScrollY * -1);
                this.ParallaxHeaderView.Scale = newHeight / this.height;
                this.ParallaxHeaderView.TranslationY = -(this.ScrollY / 2);
            }
            else
            {
                this.ParallaxHeaderView.Scale = 1;
                this.ParallaxHeaderView.TranslationY = 0;
            }
        }

        #endregion
    }
}