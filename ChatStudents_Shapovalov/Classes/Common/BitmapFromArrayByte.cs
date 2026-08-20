using System.IO;
using System.Windows.Media.Imaging;

namespace ChatStudents_Shapovalov.Classes.Common
{
    public class BitmapFromArrayByte
    {
        /// <summary>Создание битмапы изображения из массивов байт</summary>
        public static BitmapImage LoadImage(byte[] imageData)
        {
            BitmapImage Image = new BitmapImage();
            using (var Stream = new MemoryStream(imageData))
            {
                Stream.Position = 0;
                Image.BeginInit();
                Image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                Image.CacheOption = BitmapCacheOption.OnLoad;
                Image.UriSource = null;
                Image.StreamSource = Stream;
                Image.EndInit();
            }

            Image.Freeze();
            return Image;
        }
    }
}
