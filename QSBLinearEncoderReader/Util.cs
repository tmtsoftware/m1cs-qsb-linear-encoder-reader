using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSBLinearEncoderReader
{
    internal static class Util
    {
        public static Icon IconError = ResizeIconForErrorProvider(SystemIcons.Error);
        public static Icon IconWarning = ResizeIconForErrorProvider(SystemIcons.Warning);

        public static string FormatFilename(string filenameBase, DateTime datetime)
        {
            string year = String.Format("{0:D4}", datetime.Year);
            string month = String.Format("{0:D2}", datetime.Month);
            string day = String.Format("{0:D2}", datetime.Day);
            string hour = String.Format("{0:D2}", datetime.Hour);
            string minute = String.Format("{0:D2}", datetime.Minute);
            string second = String.Format("{0:D2}", datetime.Second);

            return filenameBase
                .Replace("%Y", year)
                .Replace("%m", month)
                .Replace("%d", day)
                .Replace("%H", hour)
                .Replace("%M", minute)
                .Replace("%S", second);
        }

        public static Icon ResizeIconForErrorProvider(Icon icon)
        {
            Size size = new Size(16, 16);
            Bitmap bitmap = new Bitmap(size.Width, size.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(icon.ToBitmap(), new Rectangle(Point.Empty, size));
            }
            return Icon.FromHandle(bitmap.GetHicon());
        }
    }
}
