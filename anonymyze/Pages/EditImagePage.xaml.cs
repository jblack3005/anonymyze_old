using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace anonymyze.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditImagePage : ContentPage
    {
        public EditImagePage(ImageSource inputImageSource)
        {
            InitializeComponent();

            image.Source = inputImageSource;
        }
    }
}