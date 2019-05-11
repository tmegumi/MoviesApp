using Android.Content;
using MoviesApp.Droid.Renderers;
using MoviesApp.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(NoBorderEntry), typeof(NoBorderEntryRenderer))]
namespace MoviesApp.Droid.Renderers
{
    public class NoBorderEntryRenderer : EntryRenderer
    {
        public NoBorderEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            Control?.SetBackgroundColor(Android.Graphics.Color.Transparent);
        }
    }
}