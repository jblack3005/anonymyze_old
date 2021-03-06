using SkiaSharp;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace anonymyze.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UploadPage : ContentPage
    {
        public UploadPage()
        {
            InitializeComponent();
        }

        async void OnImageButtonClicked(object sender, EventArgs e)
        {
            (sender as Button).IsEnabled = false;

            // gets photo from camera roll and decodes it to bitmap then sends it to edit image
            Stream stream = await DependencyService.Get<IPhotoPickerService>().GetImageStreamAsync();
            if (stream != null)
            {
                await Navigation.PushAsync(new EditImagePage(SKBitmap.Decode(stream)));
            }

            (sender as Button).IsEnabled = true;
        }
    }
}