using SkiaSharp;
using SkiaSharp.Views.Forms;
using System.Drawing;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace anonymyze.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditImagePage : ContentPage
    {
        SKBitmap blurredBitmap;
        public EditImagePage(SKBitmap inputImageSource)
        {
            InitializeComponent();

            // https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/graphics/skiasharp/bitmaps/drawing

            SKBitmap imageBitmap = inputImageSource;
            SKBitmap blurBitmap = new SKBitmap(9, 9);

            // creates blur rectangle
            using (SKCanvas canvas = new SKCanvas(blurBitmap))
            {
                canvas.Clear();
                canvas.DrawBitmap(imageBitmap,
                                  new SKRect(112, 238, 184, 310),   // source
                                  new SKRect(0, 0, 9, 9));          // destination

            }

            // Create full-sized bitmap on canvas and places blur on top
            blurredBitmap = new SKBitmap(imageBitmap.Width, imageBitmap.Height);

            using (SKCanvas canvas = new SKCanvas(blurredBitmap))
            {
                canvas.Clear();

                canvas.DrawBitmap(imageBitmap, new SKPoint());

                canvas.DrawBitmap(blurBitmap,
                                  new SKRect(112, 238, 184, 310));  // destination
            }

            // Create SKCanvasView to view result
            SKCanvasView canvasView = new SKCanvasView();
            canvasView.PaintSurface += OnCanvasViewPaintSurface;
        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();
            canvas.DrawBitmap(blurredBitmap, info.Rect);
        }

        void OnSaveButtonClicked(object sender, SKPaintSurfaceEventArgs args)
        {
            SKSurface surface = args.Surface;

            SKImage mainCanvasImage = surface.Snapshot();
            SKBitmap canvasBitmap = SKBitmap.Decode(mainCanvasImage.Encode());
        }
    }
}