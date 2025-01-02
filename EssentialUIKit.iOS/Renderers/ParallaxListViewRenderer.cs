using EssentialUIKit.AppLayout.Controls;
using EssentialUIKit.iOS;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ParallaxListView), typeof(ParallaxListViewRenderer))]

namespace EssentialUIKit.iOS
{
    public class ParallaxListViewRenderer : ListViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                (e.NewElement as ParallaxListView).WidthInPixel =
                    UIScreen.MainScreen.Scale * UIScreen.MainScreen.Bounds.Width;
                if (this.Control != null)
                {
                    this.Control.Delegate = new TableViewDelegate(e.NewElement as ParallaxListView, Control);
                }

                this.Control.Bounces = false;
            }
        }

        public class TableViewDelegate : UITableViewDelegate
        {
            private ParallaxListView listView;

            private UITableView natviewView;

            public TableViewDelegate(ParallaxListView listView, UITableView nativewView)
            {
                this.listView = listView;
                this.natviewView = nativewView;
            }

            public override void Scrolled(UIScrollView scrollView)
            {
                if (this.natviewView.ContentOffset.Y > 0)
                {
                    ParallaxListView.OnScrollChanged(this.listView, new ScrollChangedEventArgs((int)(-this.natviewView.ContentOffset.Y * UIScreen.MainScreen.Scale)));
                }
            }

            public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
            {
                ParallaxListView.OnSelectionChanged(this.listView, indexPath.Row);
            }
        }
    }
}