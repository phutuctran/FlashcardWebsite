using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YVFlashCard.Service.Interfaces;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace YVFlashCard.Service.ServiceImpl.ImageProcessService
{
	public class ImageProcessServiceImpl : IImageProcessService
	{
		public byte[] ResizeImage(byte[] ImageBytes, int width, int height)
		{
			//using (var inputStream = new MemoryStream(ImageBytes))
			//{
			//	using (var outputStream = new MemoryStream())
			//	{
			//		using (var image = Image.FromStream(inputStream))
			//		{
			//			int _width = image.Width;
			//			int _height = image.Height;

			//			// Calculate the new size based on the aspect ratio
			//			float ratioX = (float)width / _width;
			//			float ratioY = (float)height / _height;
			//			float ratio = Math.Min(ratioX, ratioY);

			//			int newWidth = (int)(_width * ratio);
			//			int newHeight = (int)(_height * ratio);

			//			using (var scaledImage = new Bitmap(newWidth, newHeight))
			//			{
			//				using (var graphics = Graphics.FromImage(scaledImage))
			//				{
			//					graphics.CompositingQuality = CompositingQuality.HighQuality;
			//					graphics.SmoothingMode = SmoothingMode.HighQuality;
			//					graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			//					graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

			//					graphics.DrawImage(image, 0, 0, newWidth, newHeight);

			//					scaledImage.Save(outputStream, ImageFormat.Jpeg);
			//				}
			//			}
			//		}

			//		return outputStream.ToArray();
			//	}
			//}
			return ImageBytes;
		}
	}
}
