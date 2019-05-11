namespace MoviesApp.Views
{
    public partial class MovieDetailPage
    {
        public MovieDetailPage()
        {
            InitializeComponent();
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            // Adjust image height according the width
            ImageBackdrop.WidthRequest = width;
            ImageBackdrop.HeightRequest = width / 1.779; //given that image is 500 x 281
        }
    }
}