using ShelterEvidency.Database;
using ShelterEvidency.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ShelterEvidency.Models
{
    public class ImageModel
    {
        #region Properties/Atributes
        public BitmapImage Image { get; set; }
        public string ImagePath { get; set; }
        #endregion

        public string SaveImage()
        {
            if (ImagePath != null)
            {
                string path, fileName;

                while (true)
                {
                    try
                    {
                        fileName = RandomStringGenerator.RandomString(10) + ".jpg";
                        path = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "AnimalImages", fileName);
                        System.IO.File.Copy(ImagePath, path);
                        return path;
                    }
                    catch (IOException e)
                    {
                        throw e;
                    }
                }

            }
            else
                return null;
        }

        public void GetImage(string imagePath)
        {
            if(imagePath != null)
            {
                ImagePath = imagePath;
                Image = new BitmapImage(new Uri(ImagePath));
            }
        }
    }
}
