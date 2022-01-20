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
        SKBitmap imageBitmap;
        public EditImagePage(SKBitmap inputImageSource)
        {
            InitializeComponent();

            imageBitmap = inputImageSource;

            // https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/graphics/skiasharp/bitmaps/drawing
            using (SKCanvas canvas = new SKCanvas(inputImageSource))
            {
                using(SKPaint paint = new SKPaint())
                {
                    paint.Style = SKPaintStyle.Stroke;
                    paint.Color = SKColors.Black;
                    paint.StrokeWidth = 60;
                    paint.StrokeCap = SKStrokeCap.Round;

                    using (SKPath path = new SKPath())
                    {
                        path.MoveTo(380, 390);
                        path.CubicTo(560, 390, 560, 280, 500, 280);

                        path.MoveTo(320, 390);
                        path.CubicTo(140, 390, 140, 280, 200, 280);

                        canvas.DrawPath(path, paint);
                    }
                }
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
            canvas.DrawBitmap(imageBitmap, info.Rect);
        }
    }
}