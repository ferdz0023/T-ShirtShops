using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TShirtShop.Helper
{
    public class ImageHelper
    {
        
 
        public string GetThumnailPath(string imagePathFie, string webRootPath,string extension)
        {
            string imgFileName = Path.GetFileName(imagePathFie);
            System.Drawing.Image img = System.Drawing.Image.FromFile( webRootPath + @"\" +  imgFileName);
            string filename = Guid.NewGuid().ToString() + extension;
            string filePath = Path.Combine(webRootPath + @"\Thumbnail", filename);
            int width = 320;
            int height = 240;
          
           

        
            Bitmap sourceImage = new Bitmap(img);
                using (Bitmap objBitmap = new Bitmap(width, height))
                {
                    objBitmap.SetResolution(sourceImage.HorizontalResolution, sourceImage.VerticalResolution);
                    using (Graphics objGraphics = Graphics.FromImage(objBitmap))
                    {

                        objGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                        objGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        objGraphics.DrawImage(sourceImage, 0, 0, width, height);


                        objBitmap.Save(filePath);
                    }
                }
            


            //string file = Guid.NewGuid().ToString() + Path.GetExtension(filename);
            //string path = ThumbNailPath + filename;

            return @"\images\Thumbnail\" + filename;
        }
        public string GetImagePath(IFormFileCollection formFiles,string webRootPath)
        {
            var extension = Path.GetExtension(formFiles[0].FileName);
            string filename = Guid.NewGuid().ToString() + extension;
            string filePath = Path.Combine(webRootPath, filename);
           

            using (var fileStream = new FileStream(Path.Combine(filePath), FileMode.Create))
            {
                formFiles[0].CopyTo(fileStream);
            }
        
            return @"\images\" + filename;
        }

    }
}
