using System.Drawing;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace LucideIcons.Extensions
{
    public static class ImageExtensions
    {
        public static ImageSource ToImageSource(this Image image)
        {
            using (var memory = new MemoryStream())
            {
                image.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
                memory.Position = 0;
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze(); // Damit das Bild auch threadübergreifend verwendet werden kann
                return bitmapImage;
            }
        }
    }
}