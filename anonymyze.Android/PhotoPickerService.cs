using Android.Content;
using anonymyze.Droid;
using System.IO;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(PhotoPickerService))]
namespace anonymyze.Droid
{
    public class PhotoPickerService : IPhotoPickerService
    {
        public Task<Stream> GetImageStreamAsync()
        {
            Intent intent = new Intent();
            intent.SetType("image/*");
            intent.SetAction(Intent.ActionGetContent);
            
            MainActivity.Instance.StartActivityForResult(
                Intent.CreateChooser(intent, "Select Picture"),
                MainActivity.PickImageId);
            
            MainActivity.Instance.PickImageTaskCompletionSource = new TaskCompletionSource<Stream>();
            
            return MainActivity.Instance.PickImageTaskCompletionSource.Task;
        }
    }
}