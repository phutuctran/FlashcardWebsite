using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YVFlashCard.Service.Interfaces
{
	public interface IImageProcessService
	{
		byte[] ResizeImage(byte[] ImageBytes, int width, int height);
	}
}
