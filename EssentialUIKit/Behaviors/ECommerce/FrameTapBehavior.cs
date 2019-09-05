using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EssentialUIKit.Behaviors.ECommerce
{
    /// <summary>
    /// This class extends the behavior of the frame to invoke a command when an event occurs.
    /// </summary>
    public class FrameTapBehavior : Behavior<Frame>
    {
        #region Fields

        TapGestureRecognizer tapGestureRecognizer;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the CommandParameterProperty, and it is a bindable property.
        /// </summary>
        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create("CommandParameter", typeof(object), typeof(FrameTapBehavior));

        /// <summary>
        /// Gets or sets the CommandParameter.
        /// </summary>
        public object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
            set { this.SetValue(CommandParameterProperty, value); }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when added frame to the page.
        /// </summary>
        /// <param name="bindableFrame">The Frame</param>
        protected override void OnAttachedTo(Frame bindableFrame)
        {
            base.OnAttachedTo(bindableFrame);
            tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += TapGestureRecognizer_Tapped;
            bindableFrame.GestureRecognizers.Add(tapGestureRecognizer);
        }

        /// <summary>
        /// Invoked when frame is tapped.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">EventArgs</param>
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Application.Current.Resources.TryGetValue("Gray-200", out var retVal);
            ((Frame)sender).BackgroundColor = (Color)retVal;

            await Task.Delay(100);

            ((Frame)sender).BackgroundColor = Color.Transparent;
        }

        /// <summary>
        /// Invoked when exit from the view
        /// </summary>
        /// <param name="bindableFrame">The Frame</param>
        protected override void OnDetachingFrom(Frame bindableFrame)
        {
            base.OnDetachingFrom(bindableFrame);
            tapGestureRecognizer.Tapped -= TapGestureRecognizer_Tapped;
        }

        #endregion
    }

}
